using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pruebaunoparcial.Data;
using Microsoft.AspNetCore.Identity;


namespace Pruebaunoparcial.Models
{
    public class CursoModel
    {
        private ApplicationDbContext _contexto;
        public CursoModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<object[]> ModeloListaCursos()
        {
            
            List<object[]> ListaCursos = new List<object[]>();

            var Cursos = _contexto.Curso.ToList();
            string html = "";
            foreach (var item in Cursos)
               
            {
                html += "<tr>" +
               "<td>" + item.fecha_ini + "</td>" +
                "<td>" + item.Fecha_fin + "</td>" +
                 "<td>" + item.obsevacion + "</td>" +
                  "<td>" + item.entidad + "</td>" +
                      "<td>" +
                      "<a class='btn btn-success' " +
                      "data-toggle='modal' data-target='#IngresoCurso' " +
                      " onclick='CargaCurso(" + item.CursoId + ")'>" +
                      "Editar" +
                      "</a>" +
                      "<a class='btn btn-info'>Detalle</a>" +
                      "<a class='btn btn-danger'" +
                      "onclick='eliminaCurso(" + item.CursoId + ")'>" +
                      "Eliminar" +
                      "</a>" +
                      "</td></tr>";


            }
            object[] dato = { html };
            ListaCursos.Add(dato);
            return ListaCursos;

        }
    }
}