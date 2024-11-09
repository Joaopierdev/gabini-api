using Core.Models;
using Core.DTOs;

namespace Core.Service
{
    public interface IUsuarioService
    {
        public Task<Usuario> GetUsuario(string usuarioId);

        public Task<Usuario> GetUsuarioById(string usuarioId);

        public Task<Usuario> CriaUsuario(CadastroUsuarioDTO usuarioDTO);

        public Task<Usuario> EditaUsuario(string usuarioId, CadastroUsuarioDTO usuarioDTO);

        public Task<Usuario> EditaDadosUsuario(Usuario usuario, CadastroUsuarioDTO usuarioDTO);

        public Task<Usuario> SalvaUsuario(Usuario usuario);

        public Task<Usuario> AtualizaUsuario(Usuario usuario);
    }
}
