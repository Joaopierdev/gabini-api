using Microsoft.EntityFrameworkCore;
using usuario.Models;

namespace usuario.Repositories
{
    public class UsuarioRepository
    {
        private readonly UsuarioDbContext _context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> SalvarUsuario(Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario?> getUsuarioById(string usuarioId)
        {
            Usuario? usuario = await _context.usuarios.FirstOrDefaultAsync(u => u.Id ==  usuarioId);

            return usuario;
        }
    }
}
