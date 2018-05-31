using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;
namespace Pruebaunoparcial.Models
{
    public class UsuarioModel
    {
        private ApplicationDbContext _contexto;
        public UsuarioModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<object[]> ModeloListaUsuarios()
        {
            string resultado = "";
            List<object[]> ListaUsuarios = new List<object[]>();
            var usuarios = (from u in _contexto.Usuario


                            join ud in _contexto.Usuario_discapacidad on u.UsuarioId equals ud.UsuarioId
                            join d in _contexto.Discapacidad on ud.DiscapacidadId equals d.DiscapacidadId
                            select new
                            {
                                u.Nombre,
                                u.Apellido,
                                u.Fecha_Nacimiento,
                                u.Sexo,
                                u.Nacionalidad,
                                u.Fecha_Alta,
                                u.Direccion,
                                u.Email,
                                u.Telefono,
                                u.EstadoCivil,
                                u.NumeroHijos,
                                u.NumeroSeguridadSocial,
                                d.Tipo,
                                ud.Porcentaje,
                                u.Identificacion,
                                u.N_Identificacion,
                                u.Permiso_Trabajo,
                                u.Permiso_Recidencia,
                                u.Empadronado,
                                u.Tipo_Licencia
                            }).OrderBy(u=> u.Nombre).ToList();

            foreach (var item in usuarios)
            {
                resultado += "<tr>"+
                       "<td>" + item.Nombre + "</td>" +
                       "<td>" + item.Apellido + "</td>" +
                       "<td>" + item.Fecha_Nacimiento + "</td>" +
                       "<td>" + item.Sexo + "</td>" +
                       "<td>" + item.Nacionalidad + "</td>" +
                       "<td>" + item.Fecha_Alta + "</td>" +
                       "<td>" + item.Direccion+ "</td>" +
                       "<td>" + item.Email + "</td>" +
                       "<td>" + item.Telefono + "</td>" +
                       "<td>" + item.EstadoCivil + "</td>" +
                       "<td>" + item.NumeroHijos + "</td>" +
                       "<td>" + item.NumeroSeguridadSocial + "</td>" +
                      "<td>" + item.Tipo + "</td>" +
                       "<td>" + item.Porcentaje + "</td>" +
                       "<td>" + item.Identificacion + "</td>" +
                       "<td>" + item.N_Identificacion + "</td>" +
                       "<td>" + item.Permiso_Trabajo + "</td>" +
                       "<td>" + item.Permiso_Recidencia + "</td>" +
                       "<td>" + item.Empadronado + "</td>" +
                       "<td>" + item.Tipo_Licencia + "</td>" +
                    "<td>" +
                    "<a class= 'btn btn-success'> Editar </td> " +
                    "<a class= 'btn btn-info'> Detalles </td>" +
                    "<a class= 'btn btn-alert'> Eliminar </td>" +
                    "</td></tr>";
            }
            object[] dato = { resultado };
            ListaUsuarios.Add(dato);
            return ListaUsuarios;
        }
    }
}
