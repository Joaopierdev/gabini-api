using Core.Models;

namespace Core.Repositories
{
    public interface IAuthRepository
    {
        public Task<Usuario?> GetUserByEmailOrUsernameAndPassword(string UsernameOrEmail, string senha);
    }
}
