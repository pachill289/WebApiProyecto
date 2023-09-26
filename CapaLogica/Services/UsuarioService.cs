using CapaDatos;
using CapaDatos.UserManager;
using CapaEntidad.Models;
using CapaLogica.Contracts;
using CapaTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Services
{
    public class UsuarioService : IUsuarioService
    {
        //Inyección de dependencias
        private readonly UserManager _context;

        public UsuarioService(UserManager context)
        {
            _context = context;
        }
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _context.GetUsers();
        }
        public void RegistrarUsuario(Usuario us)
        {
            _context.InsertUser(us);
        }
    }
}
