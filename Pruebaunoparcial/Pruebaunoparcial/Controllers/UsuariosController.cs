using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pruebaunoparcial.Data;
using Pruebaunoparcial.Models;
using Microsoft.AspNetCore.Identity;
namespace Pruebaunoparcial.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UsuarioModel claseUsuario;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
            claseUsuario = new UsuarioModel(context);
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }
        public List<IdentityError> ControladorGuardarUsuario(string nombre, string apellido, DateTime fecha_nacimiento, string sexo, string nacionalidad,
         DateTime fecha_alta, string direccion, string email, string telefono, string estado_civil, int numero_hijos,
        int numero_seguridad_social, string tipo, string porcentaje, string identificacion, string n_identificacion,
        string permiso_trabajo, string permiso_recidencia, string empadronado, string tipo_licencia)
        {
            return claseUsuario.ModelGrabarUsuario( nombre,  apellido,fecha_nacimiento,  sexo,  nacionalidad,
          fecha_alta,  direccion,  email, telefono,  estado_civil,  numero_hijos,
         numero_seguridad_social,  tipo, porcentaje, identificacion,  n_identificacion,
         permiso_trabajo,  permiso_recidencia, empadronado, tipo_licencia);
        }

        public List<object[]>Controladorlistausuario()
        {
            return claseUsuario.ModeloListaUsuarios();
        }
        public List<IdentityError> Controladoreditarusuario(int usuarioId, string nombre, string apellido, DateTime fecha_nacimiento, string sexo, string nacionalidad,
         DateTime fecha_alta, string direccion, string email, string telefono, string estado_civil, int numero_hijos,
        int numero_seguridad_social, string tipo, string porcentaje, string identificacion, string n_identificacion,
        string permiso_trabajo, string permiso_recidencia, string empadronado, string tipo_licencia)
        {
         return claseUsuario.ModeloEditarUsuario(usuarioId, nombre, apellido, fecha_nacimiento, sexo, nacionalidad,
         fecha_alta, direccion, email, telefono, estado_civil, numero_hijos,numero_seguridad_social, tipo, porcentaje,
         identificacion, n_identificacion, permiso_trabajo, permiso_recidencia, empadronado, tipo_licencia);
        }
        public List<Usuario> ControladorunUsuario(int usuarioId)
        {
            var usuario = (from u in _context.Usuario
                           where u.UsuarioId == usuarioId
                           select u).ToList();
            return usuario;
        }
        public List<IdentityError>ControladorEliminaUsuario(int usuarioId)
        {
            return claseUsuario.ModeloeliminarUsuario(usuarioId);
        }
       
    }
}
