using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace usuario.Models
{
    public class Endereco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; private set; }
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string? Complemento { get; private set; }
        public string NumeroCasa { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco() { }

        public Endereco(string cep, string logradouro, string? complemento, string numeroCasa, string bairro, string localidade, string estado)
        {
            CEP = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            NumeroCasa = numeroCasa;
            Bairro = bairro;
            Localidade = localidade;
            Estado = estado;
        }
    }
}
