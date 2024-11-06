using usuario.Models;

namespace usuario.DTOs
{
    public class CadastroUsuarioDTO
    {
        public string Username { get; set; }
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
        public EnderecoDTO? Endereco { get; private set; }
    }
}
