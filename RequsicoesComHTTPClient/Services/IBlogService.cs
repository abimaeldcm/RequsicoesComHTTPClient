using RequsicoesComHTTPClient.Models;

namespace RequsicoesComHTTPClient.Services
{
    public interface IBlogService
    {
        Task<List<Post>> BuscarPostsAsync();
        Task<List<User>> BuscarUsuariosAsync();
    }
}
