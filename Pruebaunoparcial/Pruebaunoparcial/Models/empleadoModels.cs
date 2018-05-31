using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;

namespace Pruebaunoparcial.Models
{
    public class empleadoModels
    {
        ApplicationDbContext _conjuntodedatos;

        public empleadoModels(ApplicationDbContext _context){
            _conjuntodedatos = _context;
        }

        public List<object> listaseguimiento() {
            string resultado = "";
            List<object> listaresultado = new List<object>();
            var seguimientos = (from m in _conjuntodedatos.Empleado
                                join tm in _conjuntodedatos.Contacto on m.EmpleadoId equals tm.EmpleadoId
                                join u in _conjuntodedatos.Usuario on tm.UsuarioId equals u.UsuarioId
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
    }
}
