using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(string name, string password);

        Task<ClaimsIdentity> LoginAsync(string name, string password);
    }
}
