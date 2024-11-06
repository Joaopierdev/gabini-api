namespace usuario.DTOs
{
    public class EnderecoDTO
    {
        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string? Complemento { get; private set; }
        public string NumeroCasa { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public string Estado { get; private set; }
    }
}
