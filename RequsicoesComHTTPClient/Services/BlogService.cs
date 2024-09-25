using Newtonsoft.Json;
using RequsicoesComHTTPClient.Models;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace RequsicoesComHTTPClient.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;

        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> BuscarPostsAsync()
        {
            var response = await _httpClient.GetAsync("/posts");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<Post>>(responseBody);
                return responseObj;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<User>> BuscarUsuariosAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/users");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var responseObj = JsonConvert.DeserializeObject<List<User>>(responseBody);

                return responseObj;
            }
            else
            {
                return null;
            }
        }
    }


}
