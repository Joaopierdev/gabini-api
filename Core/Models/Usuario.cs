using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.DTOs;

namespace Core.Models
{
    public class Usuario
    {
        public string Id { get; private set; }
        public string Username { get; set; }
        public string Nome { get;  set; }
        public string Sobrenome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Senha { get;  set; }
        public string Genero { get;  set; }
        public string Telefone { get;  set; }
        public string RG { get;  set; }
        public string CPF { get;  set; }
        public string? ImagemPerfil { get;  set; }
        public Endereco Endereco { get;  set; }

        public Usuario() { }

        public Usuario(
            string username, 
            string nome, 
            string sobrenome, 
            string email, 
            DateTime dataNascimento, 
            string senha,
            string genero, 
            string telefone, 
            string rg,
            string cpf, 
            string imagemPerfil, 
            Endereco endereco
        )
        {
            Username = username;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Senha = senha;
            Genero = genero;
            Telefone = telefone;
            RG = rg;
            CPF = cpf;
            ImagemPerfil = imagemPerfil;
            Endereco = endereco; 
        }

        public UsuarioOutputDTO ToOutputDTO()
        {
            UsuarioOutputDTO usuarioDTO = new(
                Id = this.Id,
                Username = this.Username,
                Nome = this.Nome,
                Sobrenome = this.Sobrenome,
                Email = this.Email,
                DataNascimento = this.DataNascimento,
                Genero = this.Genero,
                Telefone = this.Telefone,
                RG = this.RG,
                CPF = this.CPF,
                ImagemPerfil = this.ImagemPerfil,
                Endereco = this.Endereco
            );

            return usuarioDTO;
        }
    }
}
