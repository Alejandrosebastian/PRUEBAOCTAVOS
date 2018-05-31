using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;

namespace Pruebaunoparcial.Models
{
    public class empleadoModels
    {
        ApplicationDbContext _context;

        public empleadoModels(ApplicationDbContext contexto){
            _context = contexto;
        }

        public List<object> listaseguimiento() {
            string resultado = "";
            List<object> listaresultado = new List<object>();
            var seguimientos = (from m in _context.Empleado
                                join tm in _context.Contacto on m.EmpleadoId equals tm.EmpleadoId
                                join u in _context.Usuario on tm.UsuarioId equals u.UsuarioId
                                select new
                                {
                                    tm.Fecha,
                                    tm.Motivo,
                                    tm.Observacion,
                                    m.Nombre,
                                    m.Apellido,
                                    m.Cedula,
                                    m.Direccion,
                                    m.Email,
                                    m.Tipo_gabinete
                                }).OrderBy(tm => tm.Fecha ).ToList();
            foreach (var item in seguimientos)
            {
                resultado += "<tr>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>" + item.Motivo + "</td>" +
                    "<td>" + item.Observacion + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Apellido + "</td>" +
                    "<td>" + item.Cedula + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Email + "</td>" +
                    "<td>" + item.Tipo_gabinete + "</td>" +
                    "<td>" +
                    "<a class= 'btn btn-success'> Editar </td> " +
                    "<a class= 'btn btn-info'> Detalles </td>" +
                    "<a class= 'btn btn-alert'> Eliminar </td>" +
                    "</td>"
                    + "</tr>";
            }
            object[] datos = { resultado };
            listaresultado.Add(datos);
            return listaresultado;

        }
        public List<IdentityError> ModelograbarSeguimiento(string nombre, string apellido, int cedula, string direccion, int telefono, string email, string tipogabinete)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetoemple = new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                Cedula = cedula,
                Direccion = direccion,
                Telefono = telefono,
                Email=email,
                Tipo_gabinete=tipogabinete
            };
            try
            {
                _context.Empleado.Add(Objetoemple);
                _context.SaveChanges();
                dato = new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                };
            }
            catch (Exception ex)
            {
                dato = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            Lista.Add(dato);
            return Lista;
        }
    }

   

}
