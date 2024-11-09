using Core.Models;
using System.Security.Claims;

namespace Core.Service
{
    public interface IAuthService
    {
        public Task<string> Login(string UsernameOrEmail, string senha);

        public Task<Usuario> GetUserByEmailOrUsernameAndPassword(string UsernameOrEmail, string senha);

        public string GetAuthenticatedUserId(ClaimsPrincipal User);
    }
}
