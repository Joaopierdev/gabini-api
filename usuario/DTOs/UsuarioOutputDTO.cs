using System.Globalization;
using usuario.Models;

namespace usuario.DTOs
{
    public class UsuarioOutputDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Telefone { get;  set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string? ImagemPerfil { get; set; }
        public EnderecoDTO Endereco { get; set; }
    
        public UsuarioOutputDTO(
            string id, 
            string username, 
            string nome, 
            string sobrenome,
            string email, 
            DateTime dataNascimento, 
            string genero, 
            string telefone, 
            string rG, 
            string cPF, 
            string? imagemPerfil, 
            EnderecoDTO endereco
        )
        {
            Id = id;
            Username = username;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Telefone = telefone;
            RG = rG;
            CPF = cPF;
            ImagemPerfil = imagemPerfil;
            Endereco = endereco;
        }
    }
}
