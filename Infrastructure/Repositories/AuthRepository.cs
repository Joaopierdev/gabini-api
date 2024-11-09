using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
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
