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
    }
}
