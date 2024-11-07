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

        public async Task<Usuario> SalvaUsuario(Usuario usuario)
        {
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario?> GetUsuarioById(string usuarioId)
        {
            Usuario? usuario = await _context.usuarios.Include(usuario => usuario.Endereco).FirstOrDefaultAsync(u => u.Id ==  usuarioId);

            return usuario;
        }

        public async Task AtualizaUsuario(Usuario usuario)
        {
            await _context.SaveChangesAsync();
        }
    }
}
