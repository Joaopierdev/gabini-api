using Microsoft.AspNetCore.Mvc;
using usuario.DTOs;
using usuario.Models;
using usuario.Service;
using Microsoft.AspNetCore.Authorization;

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


        [HttpPost]
        public async Task<ActionResult<Usuario>> CadastroUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            Usuario usuario = await _usuarioService.CriarUsuario(usuarioDTO);

            return usuario;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuario()
        {
            string usuarioId = _authService.GetAuthenticatedUserId(User);
            Usuario usuario = await _usuarioService.GetUsuario(usuarioId);

            return usuario;
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> EditUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            string usuarioId = _authService.GetAuthenticatedUserId(User);
            Usuario usuario = _usuarioService.EditarUsuario(usuarioId, usuarioDTO);
        }
    }
}
