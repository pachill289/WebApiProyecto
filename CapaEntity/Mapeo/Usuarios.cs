using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key,Required]
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public DateTime fechaNacimiento { get; set; }
    }
}
