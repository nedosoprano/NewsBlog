using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsBlogDAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        public async Task<bool> CreateAsync(string name, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser()
            {
                UserName = name
            };

            IdentityResult result = await manager.CreateAsync(user, password);

            await manager.AddToRoleAsync(user.Id, "User");

            return result.Succeeded;
        }

        public async Task<ClaimsIdentity> LoginAsync(string name, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var user = await manager.FindAsync(name, password);

            if (user == null) return null;

            return manager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}
