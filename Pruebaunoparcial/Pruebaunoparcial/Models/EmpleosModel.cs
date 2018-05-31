using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;

namespace Pruebaunoparcial.Models
{
    public class EmpleosModel
    {
        ApplicationDbContext _context;
        public EmpleosModel(ApplicationDbContext _contexto)
        {
            _context = _contexto;
        }
       public List<IdentityError> listaempleo (string cargo, string empresa, DateTime fechaini, DateTime fechafin, string mediador )
        {
            List<IdentityError> lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var ObjetoEmpleo = new Empleo
            {
                Cargo = cargo,
                Empresa = empresa,
                Fecha_ini = fechaini,
                Fecha_fin = fechafin,
                Mediador = mediador
             };
            try
            {
                _context.Empleo.Add(ObjetoEmpleo);
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
            lista.Add(dato);
            return lista;
        }
        public List<object[]> ModelolistaEmpleo()
        {
            List<object[]> listaempleo = new List<object[]>();
            var resultado = _context.Empleo.ToList();
            string html = "";
            foreach (var item in resultado)
            {
                html += "<tr>" +
                    "<td>" + item.Cargo + "</td>" +
                    "<td>" + item.Empresa + "</td>" +
                    "<td>" + item.Fecha_ini + "</td>" +
                    "<td>" + item.Fecha_fin + "</td>" +
                    "<td>" + item.Mediador + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' " +
                    "data-toggle='modal' data-target='#IngresoEstudio' " +
                    " onclick='CargaEstudio(" + item.EmpleoId + ")'>" +
                    "Editar" +
                    "</a>" +
                    "<a class='btn btn-info'>Detalle</a>" +
                    "<a class='btn btn-danger'" +
                    "onclick='eliminaEstudio(" + item.EmpleoId + ")'>" +
                    "Eliminar" +
                    "</a>" +
                    "</td></tr>";
            }
            object[] dato = { html };
            listaempleo.Add(dato);
            return listaempleo;

        }
        public List<IdentityError> ModeloEditarEmpleo(string cargo, string empresa, DateTime fechaini, DateTime fechafin, string mediador)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();

            var empleo = new Empleo
            {
             Cargo = cargo,
             Empresa = empresa,
             Fecha_ini = fechaini,
             Fecha_fin = fechafin,
             Mediador = mediador
            };
            try
            {
                _context.Empleo.Update(empleo);
                _context.SaveChanges();
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
        public List<IdentityError> ModeloEliminarempleo(int empleoid)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();

            var empleo = new Empleo { EmpleoId = empleoid };
            try
            {
                _context.Empleo.Remove(empleo);
                _context.SaveChanges();
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
