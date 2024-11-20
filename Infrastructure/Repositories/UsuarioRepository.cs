using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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
            Usuario? usuario = await _context.usuarios.Include(usuario => usuario.Endereco).FirstOrDefaultAsync(u => u.Id == usuarioId);

            return usuario;
        }

        public async Task<bool> HasUsuario(string email, string username)
        {
            return await _context.usuarios.AnyAsync(u => u.Email == email || u.Username == username);
        }

        public async Task<bool> ExisteUsuarioComCpf(string cpf)
        {
            return await _context.usuarios.AnyAsync(u => u.CPF == cpf);
        }

        public async Task<bool> ExisteUsuarioComRg(string rg)
        {
            return await _context.usuarios.AnyAsync(u => u.RG == rg);
        }

        public async Task AtualizaUsuario(Usuario usuario)
        {
            await _context.SaveChangesAsync();
        }
    }
}
