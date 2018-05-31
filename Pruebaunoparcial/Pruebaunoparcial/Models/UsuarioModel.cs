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
                            join ud in _contexto.);
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
                       "<td>" + item.Minusvalido + "</td>" +
                       "<td>" + item.Porcentaje + "</td>" +
                       "<td>" + item.Identificacion + "</td>" +
                       "<td>" + item.N_Identificacion + "</td>" +
                       "<td>" + item.Permiso_Trabajo + "</td>" +
                       "<td>" + item.Permiso_Recidencia + "</td>" +
                       "<td>" + item.Empadronado + "</td>" +
                       "<td>" + item.Tipo_Licencia + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success'" +
                    "data-toggle='modal'" +
                    "data-target='#IngresoSexo'" +
                    " onclick='cargasexo(" + item.UsuarioId + ")' >Editar</a>" +
                    "<a class='btn btn-info'>Detalles</a>" +
                    "<a class='btn btn-danger' onclick='eliminasexo(" + item.UsuarioId + ")'>Eliminar</a>" +
                    "</td></tr>";
            }
            object[] dato = { resultado };
            ListaUsuarios.Add(dato);
            return ListaUsuarios;
        }
    }
}
