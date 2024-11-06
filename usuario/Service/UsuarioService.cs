using usuario.DTOs;
using usuario.Models;
using usuario.Repositories;

namespace usuario.Service
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuario(string usuarioId)
        {
            Usuario usuario = await getUsuarioById(usuarioId);

            return usuario;
        }

        public async Task<Usuario?> getUsuarioById(string usuarioId)
        {
            Usuario? usuario = await _usuarioRepository.getUsuarioById(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Não foi possível encontrar o usuário");
            }

            return usuario;
        }


        public async Task<Usuario> CriarUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            Endereco endereco = new Endereco(
                usuarioDTO.Endereco.CEP,
                usuarioDTO.Endereco.Logradouro,
                usuarioDTO.Endereco.Complemento,
                usuarioDTO.Endereco.NumeroCasa,
                usuarioDTO.Endereco.Bairro,
                usuarioDTO.Endereco.Localidade,
                usuarioDTO.Endereco.Estado
            );

            Usuario usuario = new Usuario(
                usuarioDTO.Username,
                usuarioDTO.Nome,
                usuarioDTO.Sobrenome,
                usuarioDTO.Email,
                usuarioDTO.DataNascimento,
                usuarioDTO.Senha,
                usuarioDTO.Genero,
                usuarioDTO.Telefone,
                usuarioDTO.RG,
                usuarioDTO.CPF,
                usuarioDTO.ImagemPerfil,
                endereco
            );

            usuario = await _usuarioRepository.SalvarUsuario(usuario);

            return usuario;
        }

        public async Task<Usuario> EditarUsuario(string usuarioId, CadastroUsuarioDTO usuarioDTO)
        {
            Usuario usuario = await getUsuarioById(usuarioId);
        }
    }
}
