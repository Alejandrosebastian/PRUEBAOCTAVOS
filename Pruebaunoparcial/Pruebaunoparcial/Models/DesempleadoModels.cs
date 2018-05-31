using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Pruebaunoparcial.Data;
using Pruebaunoparcial.Models;

namespace Pruebaunoparcial.Models
{
    public class DesempleadoModels
    {
        private ApplicationDbContext _contexto;

        public DesempleadoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaDesempleo(String tiempo,DateTime fecha_in, DateTime fecha_fin)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var ObjetosDesempleado = new Desempleado
            {
                tiempo = tiempo,
                fecha_fin = fecha_fin,
                fecha_ini = fecha_in
            };
            try
            {
                _contexto.Desempleado.Add(ObjetosDesempleado);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "save",
                    Description = "save"
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
        public List<object[]> ModeloListaDesempleado()
        {
            List<object[]> ListaDesempleado = new List<object[]>();
            var resultado = _contexto.Desempleado.ToList();
            //var resultado = from s in _contexto.Sexos select s;
            //var resultado = from s in _contexto.Sexos select new { s.Detalle, s.SexoId };
            var html = "";
            foreach (var item in resultado)
            {
                html += "<tr>" +
                    "<td>" + item.tiempo + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoDesempleados' onclick='CargaDesempleado(" + item.tiempo + ")'>Editar</a>" +
                    "<a class='btn btn-info' >Detalle</a>" +
                    "<a class='btn btn-danger' onclick='eliminaSexo(" + item.DesempleadoId + ")'>Eliminar</a>" +
                    "<td>" + item.fecha_ini + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoDesempleados' onclick='CargaDesempleado(" + item.fecha_ini + ")'>Editar</a>" +
                    "<a class='btn btn-info' >Detalle</a>" +
                    "<a class='btn btn-danger' onclick='eliminaDesempleado(" + item.DesempleadoId + ")'>Eliminar</a>" +
                    "<td>" + item.fecha_fin + "</td>" +
                    "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoSexos' onclick='CargaDesempleado(" + item.fecha_fin + ")'>Editar</a>" +
                    "<a class='btn btn-info' >Detalle</a>" +
                    "<a class='btn btn-danger' onclick='eliminaSexo(" + item.DesempleadoId + ")'>Eliminar</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            ListaDesempleado.Add(dato);
            return ListaDesempleado;
        }

        public List<IdentityError> ModeloEditarDesempleado(int DesempleadoId, string time, DateTime fecha_in, DateTime fecha_fin)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var desempleado = new Desempleado
            {
                tiempo = time,
                fecha_fin = fecha_fin,
                fecha_ini = fecha_in,
                DesempleadoId = DesempleadoId
            };
            try
            {
                _contexto.Desempleado.Update(desempleado);
                _contexto.SaveChanges();
                regresa = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                regresa = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaEditar.Add(regresa);
            return ListaEditar;
        }

        public List<IdentityError> ModeloEliminarDesmpleado(int DesempleadoId)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var desempleado = new Desempleado  { DesempleadoId = DesempleadoId};
            try
            {
                _contexto.Desempleado.Remove(desempleado);
                _contexto.SaveChanges();
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
            ListaEliminar.Add(dato);
            return ListaEliminar;
        }
    }
}
