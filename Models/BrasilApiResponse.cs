namespace TesteHttpClient.Models
{
    public class BrasilApiResponse
    {
        public string cep { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string neighborhood { get; set; } = string.Empty;
        public string street { get; set; } = string.Empty;
    }
}
