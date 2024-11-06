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

        public async Task<Usuario?> GetUserByEmailOrUsernameAndPassword(string UsernameOrEmail, string senha)
        {
            return await _context.usuarios.FirstOrDefaultAsync(usuario => usuario.Email == UsernameOrEmail || usuario.Username == UsernameOrEmail && usuario.Senha == senha);
        }


    }
}
