﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DMS.Data.EF.Models;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //For admin Only
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                return Ok();
            }
            return Ok($"Hi you are an {currentUser.Role}");
        }

        private UserModel? GetCurrentUser()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    UserName = userClaims.First(x => x.Type == ClaimTypes.NameIdentifier).Value,
                    Role = userClaims.First(x => x.Type == ClaimTypes.Role).Value
                };
            }
            return null;
        }
    }
}

// https://www.c-sharpcorner.com/article/jwt-token-creation-authentication-and-authorization-in-asp-net-core-6-0-with-po/
// https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/
// 