using Microsoft.AspNetCore.Mvc;
using TesteHttpClient.Models;
using TesteHttpClient.Services;

namespace TesteHttpClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {

        private readonly ICepService _service;

        public CepController(ICepService service)
        {
            _service = service;
        }

        [HttpGet("get/{cep}/{provider}")]
        public async Task<object> GetCep(string cep, string provider)
        {
            try
            {
                var response = await _service.GetAsync(cep, provider);

                return Ok(response);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
