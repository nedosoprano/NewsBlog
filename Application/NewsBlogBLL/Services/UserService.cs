using NewsBlogDAL.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsBlogBLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(string name, string password)
        {
            bool result;

            try 
            { 
                result = await _userRepository.CreateAsync(name, password); 
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public async Task<ClaimsIdentity> LoginAsync(string name, string password)
        {
            return await _userRepository.LoginAsync(name, password);
        }
    }
}
