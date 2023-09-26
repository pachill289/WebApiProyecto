using CapaEntidad.Models;
using CapaTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Contracts
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObtenerUsuarios();
        void RegistrarUsuario(Usuario us);
    }
}
