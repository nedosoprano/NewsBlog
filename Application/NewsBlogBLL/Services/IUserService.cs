using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    public interface IUserService
    {
        Task<bool> CreateAsync(string name, string password);

        Task<ClaimsIdentity> LoginAsync(string name, string password);
    }
}
