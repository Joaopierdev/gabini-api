using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace usuario.Models
{
    public class Endereco
    {
        public string Id { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string? Complemento { get;  set; }
        public string NumeroCasa { get;  set; }
        public string Bairro { get;  set; }
        public string Localidade { get;  set; }
        public string Estado { get;  set; }

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
