using Microsoft.AspNetCore.Mvc;
using RequsicoesComHTTPClient.Models;
using RequsicoesComHTTPClient.Services;
using System.Text;
using System.Text.Json;

namespace RequsicoesComHTTPClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IHttpClientFactory _httpClientFactory;

        public RequisicaoController(IBlogService blogService, IHttpClientFactory httpClientFactory)
        {
            _blogService = blogService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Posts")]
        public async Task<ActionResult<List<Post>>> Posts()
        {

            return await _blogService.BuscarPostsAsync();

        }
        [HttpGet("Users")]
        public async Task<ActionResult<List<User>>> Users()
        {

            var client = _httpClientFactory.CreateClient("a");

            HttpResponseMessage response = await client.GetAsync("/users");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
