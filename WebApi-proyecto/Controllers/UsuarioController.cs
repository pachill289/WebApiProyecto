using CapaDatos;
using CapaDatos.UserManager;
using CapaEntidad.Models;
using CapaTools;
using CapaLogica;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_proyecto.DataContract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager _context;
        public UsuarioController (dbContext context)
        {
            _context = new UserManager(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        [Route("api/[controller]/ObtenerUsuarios")]
        public IActionResult Get()
        {
           Response res = new Response();
           try
           {
                IEnumerable<Usuario> usuarios = _context.GetUsers();
                res.ErrorCode = 0;
                if(usuarios.Any())
                {
                    res.ErrorCode = -1;
                }
                return Ok(_context.GetUsers());
            }
            catch (Exception e)
            {
                
                res.ErrorCode = -1;
                res.Description = e.Message;
                return BadRequest();
            }
        }

        // GET api/<UsuarioController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<UsuarioController>
        [HttpPost]
        [Route("api/[controller]/RegistrarUsuario")]
        public IActionResult Post([FromBody] Usuario usModel)
        {
            Response res = new Response();
            try
            {
                _context.InsertUser(usModel);
                res.ErrorCode = 0;
                return Ok(res.ErrorCode);
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.Description = e.Message;
                return BadRequest();
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
