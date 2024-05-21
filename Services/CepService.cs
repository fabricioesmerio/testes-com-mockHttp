using Newtonsoft.Json;
using System.Net.Http.Headers;
using TesteHttpClient.Models;

namespace TesteHttpClient.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public CepService(
            HttpClient httpClient
            ) 
        {
            _httpClient = httpClient;
        }

        public async Task<CepResponseDto> GetAsync(string cep, string provider)
        {

            var response = provider == "via"
                ? await GetCepViaCep(cep)
                : await GetCepBrasilApi(cep);

            return response;

        }

        private async Task<CepResponseDto> GetCepBrasilApi(string cep)
        {
            _httpClient.BaseAddress = new Uri("https://brasilapi.com.br/api/cep/v1/");
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Get, $"{cep}");
            var responseBody = await _httpClient.SendAsync(request);
            var bar = JsonConvert.DeserializeObject<BrasilApiResponse>(await responseBody.Content.ReadAsStringAsync());

            if (bar is null) 
                return new CepResponseDto();

             return new CepResponseDto() 
            {
                City = bar.city,
                State = bar.state,
                Street = bar.street
            };
        }

        private async Task<CepResponseDto> GetCepViaCep(string cep)
        {
            _httpClient.BaseAddress = new Uri($"https://viacep.com.br/ws/{cep}/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            var request = new HttpRequestMessage(HttpMethod.Get, "");
            var responseBody = await _httpClient.SendAsync(request);
            var vcr = JsonConvert.DeserializeObject<ViaCepResponse>(await responseBody.Content.ReadAsStringAsync());

            if (vcr is null) return new CepResponseDto();

            return new CepResponseDto()
            {
                City = vcr.localidade,
                State = vcr.uf,
                Street = vcr.logradouro,
            };
        }
    }
}
