using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Service;

namespace Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IImagemService _imageService;
        public UsuarioService(IUsuarioRepository usuarioRepository, IImagemService imagemService)
        {
            _usuarioRepository = usuarioRepository;
            _imageService = imagemService;
        }

        public async Task<Usuario> GetUsuario(string usuarioId)
        {
            Usuario usuario = await GetUsuarioById(usuarioId);

            return usuario;
        }
        private async Task<Usuario> GetUsuarioById(string usuarioId)
        {
            Usuario? usuario = await _usuarioRepository.GetUsuarioById(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Não foi possível encontrar o usuário");
            }

            return usuario;
        }

        private async Task HasUsuario(string email, string username)
        {
            bool existeUsuario = await _usuarioRepository.HasUsuario(email, username);

            if (existeUsuario)
            {
                throw new Exception("E-mail ou username já existe");
            }
        }

        private async Task ValidaUsuarioPeloCpf(string cpf)
        {
            bool usuarioComCPF = await _usuarioRepository.ExisteUsuarioComCpf(cpf);

            if (usuarioComCPF)
            {
                throw new Exception("Já existe um usuário cadastrado com este CPF");
            }
        }

        private async Task ValidaUsuarioPeloRg(string rg)
        {
            bool usuarioComRg = await _usuarioRepository.ExisteUsuarioComRg(rg);

            if (usuarioComRg)
            {
                throw new Exception("Já existe um usuário cadastrado com este RG");
            }
        }


        public async Task<Usuario> CriaUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            await HasUsuario(usuarioDTO.Email, usuarioDTO.Username);
            await ValidaUsuarioPeloRg(usuarioDTO.RG);


            bool isCpf = await IsCpf(usuarioDTO.CPF);
            if (!isCpf)
            {
                throw new Exception("CPF inválido");
            }
            await ValidaUsuarioPeloCpf(usuarioDTO.CPF);

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
                usuarioDTO.RG.Replace(".", "").Replace("-", ""),
                usuarioDTO.CPF.Replace(".", "").Replace("-", ""),
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

        public async Task<string> AtualizaImagemUsuario(string usuarioId, FileData fileData)
        {
            Usuario usuario = await GetUsuarioById(usuarioId);

            string uploadedFileUrl = await _imageService.UploadImagem(fileData, "usuarios", usuarioId);

            usuario.ImagemPerfil = uploadedFileUrl;
            
            await _usuarioRepository.AtualizaUsuario(usuario);

            return uploadedFileUrl;
        }

        public async Task<bool> IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
