using TesteHttpClient.Models;

namespace TesteHttpClient.Services
{
    public interface ICepService
    {
        Task<CepResponseDto> GetAsync(string cep, string provider);
    }
}
