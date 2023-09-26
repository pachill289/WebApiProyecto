using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Models
{
    public class Usuario
    {
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
