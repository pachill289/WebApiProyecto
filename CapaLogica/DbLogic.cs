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
        //GET
        public List<Usuario> GetUsers()
        {
            //Se crea una lista de modelos de tipo usuario
            List<Usuario> response = new List<Usuario>();
            //Se recupera a partir del dbContext todos los usuarios con la ayuda de EntityFramework 5.0
            var dataList = _context.Usuarios.ToList();
            //Luego se llena la lista de usuarios
            dataList.ForEach(row => response.Add(new Usuario()
            {
                Ci = row.Ci,
                Nombre = row.Nombre,
                Clave = row.Clave,
                fechaNacimiento = row.fechaNacimiento
            }));
            return response;
        }
        //POST
        public void InsertUser (Usuario usModel)
        {
            Encriptacion nuevaEcriptacion = new();
            Usuarios nuevoUsuario = new Usuarios();
            nuevoUsuario.Ci = usModel.Ci;
            nuevoUsuario.Clave = Encoding.Default.GetString(nuevaEcriptacion.Encriptar(usModel.Clave));
            nuevoUsuario.Nombre = usModel.Nombre;
            nuevoUsuario.fechaNacimiento = usModel.fechaNacimiento;
            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();
        }
    }
}
