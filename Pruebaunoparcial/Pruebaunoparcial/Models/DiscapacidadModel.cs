using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;

namespace Pruebaunoparcial.Models
{
    public class DiscapacidadModel
    {
        private ApplicationDbContext _contexto;
         
        public DiscapacidadModel (ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ModeloGrabaDiscapacidad(string discapacidad)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var ObjetoDiscapacidad = new Discapacidad
            {
                Tipo = discapacidad


            };
            try
            {
                _contexto.Discapacidad.Add(ObjetoDiscapacidad);
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

        public List<object[]> ModeloListaDiscapacidad()
        {
            List<object[]> ListaDiscapacidad = new List<object[]>();
            var resultado = _contexto.Discapacidad.ToList();
            string html = "";
            foreach (var item in resultado)
            {
                html += "<tr>" +
                    "<td>" + item.Tipo + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' " +
                    "data-toggle='modal' data-target='#IngresoDiscapacidad' " +
                    " onclick='CargaDiscapacidad(" + item.DiscapacidadId + ")'>" +
                    "Editar" +
                    "</a>" +
                    "<a class='btn btn-info'>Tipo</a>" +
                    "<a class='btn btn-danger'" +
                    "onclick='eliminaDiscapacidad(" + item.DiscapacidadId + ")'>" +
                    "Eliminar" +
                    "</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            ListaDiscapacidad.Add(dato);
            return ListaDiscapacidad;
        }

        public List<IdentityError> ModeloEditarDiscapacidad(int discapacidadid, string tipo)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();

            var discapacidad = new Discapacidad
            {
                Tipo = tipo,
                DiscapacidadId = discapacidadid
            };
            try
            {
                _contexto.Discapacidad.Update(discapacidad);
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

        public List<IdentityError> ModeloEliminarDiscapacidad(int discapacidadId)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var discapacidad = new Discapacidad { DiscapacidadId = discapacidadId };
            try
            {
                _contexto.Discapacidad.Remove(discapacidad);
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
            ListaEliminar.Add(dato);
            return ListaEliminar;
        }


    }
}