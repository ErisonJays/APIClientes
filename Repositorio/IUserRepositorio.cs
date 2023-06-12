using APIClientes.Modelos;

namespace APIClientes.Repositorio
{
    public interface IUserRepositorio
    {
        Task<int> Register(User user, string password);
        Task<string> Login(string username, string password);
        Task<bool> UserExiste(string username);
    }
}
