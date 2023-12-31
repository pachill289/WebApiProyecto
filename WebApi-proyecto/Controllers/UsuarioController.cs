﻿using CapaDatos;
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
        [Route("ObtenerUsuarios")]
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
        [HttpGet]
        [Route("BuscarUsuario/{id}")]
        public IActionResult BuscarUsuario(string id)
        {
            Response res = new Response();
            try
            {
                Usuarios usuario = _context.SearchUser(id);
                res.ErrorCode = 0;
                if (usuario == null)
                {
                    res.ErrorCode = -1;
                }
                return Ok(usuario);
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
        [Route("RegistrarUsuario")]
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
        [HttpPut("ActualizarUsuario/{id}")]
        public IActionResult Put(string id, [FromBody] Usuario usModel)
        {
            Response res = new Response();
            try {
                _context.UpdateUser(id, usModel);
                res.ErrorCode = 0;
                return Ok(res.ErrorCode);
            } catch (Exception e) {
                res.ErrorCode = -1;
                res.Description = e.Message;
                return BadRequest();
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("EliminarUsuario/{id}")]
        public IActionResult Delete(string id)
        {
            Response res = new Response();
            try
            {
                _context.DeleteUserById(id);
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
    }
}
