using PAEAppMaui.Models;

namespace PAEAppMaui.Services
{
    public interface ILoginInterface
    {
        Task<User> Login(string email, string password);
    }
}
