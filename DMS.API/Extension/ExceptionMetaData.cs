namespace DMS.API.Extension;

using Newtonsoft.Json;

public class ExceptionMetaData
{
    public int Code { get; set; }

    [JsonProperty("error_type")]
    public string ErrorType { get; set; } = null!;

    [JsonProperty("error_message")]
    public string ErrorMessage { get; set; } = null!;

    [JsonProperty("call_stack")]
    public string CallStack { get; set; } = null!;
}

public class ExceptionResponse
{
    public ExceptionMetaData MetaData { get; set; } = null!;

    public ExceptionResponse() : this(new ExceptionMetaData())
    {
    }

    public ExceptionResponse(ExceptionMetaData metaData)
    {
        MetaData = metaData;
    }
}