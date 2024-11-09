using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Models;
using Core.Service;
using Microsoft.AspNetCore.Authorization;

namespace usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthService _authService;

        public UsuarioController(IUsuarioService usuarioService, IAuthService authService)
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
