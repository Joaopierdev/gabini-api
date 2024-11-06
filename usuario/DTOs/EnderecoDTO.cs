using System.Globalization;

namespace usuario.DTOs
{
    public class EnderecoDTO
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Estado { get; set; }

        public EnderecoDTO(string cep, string logradouro, string complemento, string numeroCasa, string bairro, string localidade, string estado)
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
