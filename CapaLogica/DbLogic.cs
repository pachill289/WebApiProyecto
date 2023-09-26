using CapaDatos;
using CapaDatos.UserManager;
using CapaEntidad.Models;
using CapaTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class DbLogic
    {
        
        //Inyección de dependencias
        private dbContext _context;

        public DbLogic (dbContext context)
        {
            _context = context;
        }
        
    }
}
