namespace TesteHttpClient.Models
{
    public class ViaCepResponse
    {
        public string cep { get; set; } = string.Empty;
        public string logradouro { get; set; } = string.Empty;
        public string complemento { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string localidade { get; set; } = string.Empty;
    }
}
