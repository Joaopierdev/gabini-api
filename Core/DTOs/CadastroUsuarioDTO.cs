using Core.Models;

namespace Core.DTOs
{
    public class CadastroUsuarioDTO
    {
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string? ImagemPerfil { get; set; }
        public EnderecoDTO Endereco { get; set; }
    }
}
