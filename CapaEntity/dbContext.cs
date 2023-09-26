using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class dbContext : DbContext
    {
        public dbContext (DbContextOptions<dbContext> options) : base (options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
