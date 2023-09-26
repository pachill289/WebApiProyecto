using CapaEntidad.Models;
using CapaTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.UserManager {
    public class UserManager {
        private dbContext _context;

        public UserManager(dbContext context) {
            _context = context;
        }
        //GET
        public List<Usuario> GetUsers() {
            //Se crea una lista de modelos de tipo usuario
            List<Usuario> response = new List<Usuario>();
            //Se recupera a partir del dbContext todos los usuarios con la ayuda de EntityFramework 5.0
            var dataList = _context.Usuarios.ToList();
            //Luego se llena la lista de usuarios
            dataList.ForEach(row => response.Add(new Usuario() {
                Ci = row.Ci,
                Nombre = row.Nombre,
                Clave = row.Clave,
                fechaNacimiento = row.fechaNacimiento
            }));
            return response;
        }
        //POST
        public void InsertUser(Usuario usModel) {
            Encriptacion nuevaEcriptacion = new();
            Usuarios nuevoUsuario = new Usuarios();
            nuevoUsuario.Ci = usModel.Ci;
            nuevoUsuario.Clave = Encoding.Default.GetString(nuevaEcriptacion.Encriptar(usModel.Clave));
            nuevoUsuario.Nombre = usModel.Nombre;
            nuevoUsuario.fechaNacimiento = usModel.fechaNacimiento;
            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();
        }
        // PUT
        public bool UpdateUser(string id, Usuario usModel) {
            Encriptacion nuevaEncriptacion = new Encriptacion();
            var usuarioExistente = _context.Usuarios.FirstOrDefault(us => us.Ci == id);

            if (usuarioExistente != null) {
                usuarioExistente.Ci = usModel.Ci;
                usuarioExistente.Clave = Encoding.Default.GetString(nuevaEncriptacion.Encriptar(usModel.Clave));
                usuarioExistente.Nombre = usModel.Nombre;
                usuarioExistente.fechaNacimiento = usModel.fechaNacimiento;

                _context.SaveChanges();
                return true; // Indicar que la actualización fue exitosa
            }
            else {
                return false; // Indicar que no se encontró el usuario a actualizar
            }
        }
    }
}
