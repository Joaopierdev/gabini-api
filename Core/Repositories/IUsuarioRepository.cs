using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> SalvaUsuario(Usuario usuario);

        public Task<Usuario?> GetUsuarioById(string usuarioId);

        public Task AtualizaUsuario(Usuario usuario);

        public Task<bool> HasUsuario(string email, string username);

        public Task<bool> ExisteUsuarioComCpf(string cpf);

        public Task<bool> ExisteUsuarioComRg(string rg);
    }
}
