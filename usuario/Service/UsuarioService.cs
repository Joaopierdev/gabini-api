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
            Usuario usuario = await GetUsuarioById(usuarioId);

            return usuario;
        }

        public async Task<Usuario> GetUsuarioById(string usuarioId)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuarioById(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Não foi possível encontrar o usuário");
            }

            return usuario;
        }


        public async Task<Usuario> CriaUsuario(CadastroUsuarioDTO usuarioDTO)
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

            usuario = await SalvaUsuario(usuario);

            return usuario;
        }

        public async Task<Usuario> EditaUsuario(string usuarioId, CadastroUsuarioDTO usuarioDTO)
        {
            Usuario usuario = await GetUsuarioById(usuarioId);
            usuario = await EditaDadosUsuario(usuario, usuarioDTO);
            usuario = await AtualizaUsuario(usuario);

            return usuario;
        }

        public async Task<Usuario> EditaDadosUsuario(Usuario usuario, CadastroUsuarioDTO usuarioDTO)
        {
            usuario.Username = usuarioDTO.Username;
            usuario.Nome = usuarioDTO.Nome;
            usuario.Sobrenome = usuarioDTO.Sobrenome;
            usuario.Email = usuarioDTO.Email;
            usuario.DataNascimento = usuarioDTO.DataNascimento;
            usuario.Genero = usuarioDTO.Genero;
            usuario.Telefone = usuarioDTO.Telefone;
            usuario.RG = usuarioDTO.RG;
            usuario.CPF = usuarioDTO.CPF;
            usuario.Endereco.CEP = usuarioDTO.Endereco.CEP;
            usuario.Endereco.Logradouro = usuarioDTO.Endereco.Logradouro;
            usuario.Endereco.Complemento = usuarioDTO.Endereco.Complemento;
            usuario.Endereco.NumeroCasa = usuarioDTO.Endereco.NumeroCasa;
            usuario.Endereco.Bairro = usuarioDTO.Endereco.Bairro;
            usuario.Endereco.Localidade = usuarioDTO.Endereco.Localidade;
            usuario.Endereco.Estado = usuarioDTO.Endereco.Estado;

            return usuario;

        }

        public async Task<Usuario> SalvaUsuario(Usuario usuario)
        {
            usuario = await _usuarioRepository.SalvaUsuario(usuario);

            return usuario;
        }

        public async Task<Usuario> AtualizaUsuario(Usuario usuario)
        {
            await _usuarioRepository.AtualizaUsuario(usuario);

            return usuario;
        }
    }
}
