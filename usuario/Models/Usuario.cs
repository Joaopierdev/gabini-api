using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace usuario.Models
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; private set; }
        public string Username {  get; set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Senha { get; private set; }
        public string Genero { get; private set; }
        public string Telefone { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public string? ImagemPerfil { get; private set; }
        public Endereco Endereco { get; private set; }

        public Usuario() { }

        public Usuario(string id,string username, string nome, string sobrenome, string email, DateTime dataNascimento, string senha, string genero, string telefone, string rg, string cpf, string imagemPerfil, Endereco endereco)
        {
            Id = id;
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
    }
}
