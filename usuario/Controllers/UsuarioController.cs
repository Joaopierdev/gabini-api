using Microsoft.AspNetCore.Mvc;
using usuario.DTOs;
using usuario.Models;
using usuario.Service;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly AuthService _authService;
        
        public UsuarioController(UsuarioService usuarioService, AuthService authService)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UsuarioOutputDTO>> CadastroUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            Usuario usuario = await _usuarioService.CriaUsuario(usuarioDTO);

            return usuario.ToOutputDTO();
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioOutputDTO>> GetUsuario()
        {
            string usuarioId = _authService.GetAuthenticatedUserId(User);
            Usuario usuario = await _usuarioService.GetUsuario(usuarioId);

            return usuario.ToOutputDTO();
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioOutputDTO>> EditaUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            string usuarioId = _authService.GetAuthenticatedUserId(User);
            Usuario usuario = await _usuarioService.EditaUsuario(usuarioId, usuarioDTO);

            return usuario.ToOutputDTO();
        }
    }
}
