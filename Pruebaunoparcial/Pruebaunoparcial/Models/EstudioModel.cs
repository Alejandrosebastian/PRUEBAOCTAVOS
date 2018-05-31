using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;

namespace Pruebaunoparcial.Models
{
    public class EstudioModel
    {
        private ApplicationDbContext _contexto;
        public EstudioModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ModeloGrabaEstudio(string estudio)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var ObjetoEstudio = new Estudio
            {
                Detalle = estudio


            };
            try
            {
                _contexto.Estudio.Add(ObjetoEstudio);
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

        public List<object[]> ModeloListaEstudio()
        {
            List<object[]> ListaEstudio = new List<object[]>();
            var resultado = _contexto.Estudio.ToList();
            string html = "";
            foreach (var item in resultado)
            {
                html += "<tr>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' " +
                    "data-toggle='modal' data-target='#IngresoEstudio' " +
                    " onclick='CargaEstudio(" + item.EstudioId + ")'>" +
                    "Editar" +
                    "</a>" +
                    "<a class='btn btn-info'>Detalle</a>" +
                    "<a class='btn btn-danger'" +
                    "onclick='eliminaEstudio(" + item.EstudioId + ")'>" +
                    "Eliminar" +
                    "</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            ListaEstudio.Add(dato);
            return ListaEstudio;
        }

        public List<IdentityError> ModeloEditarEstudio(int estudioid, string detalle)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();

            var estudio = new Estudio
            {
                Detalle = detalle,
                EstudioId = estudioid
            };
            try
            {
                _contexto.Estudio.Update(estudio);
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

        public List<IdentityError> ModeloEliminarEstudio(int estudioId)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var estudio = new Estudio { EstudioId = estudioId };
            try
            {
                _contexto.Estudio.Remove(estudio);
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