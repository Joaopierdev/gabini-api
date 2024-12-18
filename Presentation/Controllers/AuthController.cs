﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Core.DTOs;
using Core.Service;

namespace usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUsuarioDTO LoginUsuarioDTO)
        {
            string token = await _authService.Login(LoginUsuarioDTO.UsernameOrEmail, LoginUsuarioDTO.Senha);

            return token;
        }

        [HttpGet]
        public string GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            string? userId = User.Claims.First(u => u.Type == "id")?.Value;
            if (userId == null)
            {
                throw new Exception("User not found on token JWT");
            }

            return userId;
        }
    }
}