using Microsoft.EntityFrameworkCore;
using usuario.Models;

namespace usuario.Repositories
{
    public class AuthRepository
    {
        private readonly UsuarioDbContext _context;

        public AuthRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUserByEmailOrUsernameAndPassword(string email, string username, string senha)
        {
            return await _context.usuarios.FirstOrDefaultAsync(usuario => usuario.Email == email || usuario.Username == username && usuario.Senha == senha);
        }


    }
}
