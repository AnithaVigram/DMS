﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DMS.API.Extension;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly IOptions<MvcNewtonsoftOptions> _jsonOptions;
    private readonly IWebHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next,
        //IOptions<MvcNewtonsoftOptions> jsonOptions,
        IWebHostEnvironment env)
    {
        this._next = next;
        //this._jsonOptions = jsonOptions;
        this._env = env;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, logger);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ExceptionHandlingMiddleware> logger)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        int statusCode = StatusCodes.Status500InternalServerError;

        var result = new ExceptionMetaData
        {
            ErrorType = ex.GetType().ToString(),
        };

        var msg = "An unhandled error occured";
        var stack = string.Empty;

        if (_env.IsDebugInfoAllowed())
        {
            msg = ex.GetBaseException()?.Message ?? "An unhandled error occurred";
            stack = ex.StackTrace ?? "No stack trace available";
            result.CallStack = stack;
        }

        if (ex is DbUpdateConcurrencyException)
        {
            result.Code = StatusCodes.Status400BadRequest;
            result.ErrorMessage = "Concurrency Expection. Only one user allowed to edit content at a time";

            logger.LogWarning(ex, $"{result.ErrorMessage} - {stack}");
        }
        else if (ex is UnauthorizedAccessException)
        {
            result.Code = StatusCodes.Status401Unauthorized;
            result.ErrorMessage = "Unauthorized access";

            logger.LogWarning(ex, $"{result.ErrorMessage} - {stack}");
        }
        else if (ex is ArgumentNullException)
        {
            result.Code = StatusCodes.Status400BadRequest;
            result.ErrorMessage = "Argument cannot be null";

            logger.LogWarning(ex, $"{result.ErrorMessage} - {stack}");
        }
        else
        {
            result.Code = statusCode;
            result.ErrorMessage = $"{msg}";

            logger.LogError(ex, $"Expection occured: {result.ErrorMessage} - {stack}");
        }

        context.Response.StatusCode = result.Code;

        var errorResponse = new ExceptionResponse(result);
        var jsonResult = JsonConvert.SerializeObject(errorResponse,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(jsonResult);
    }
}
