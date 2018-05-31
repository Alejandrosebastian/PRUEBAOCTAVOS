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
        //GUARDAR
        public List<IdentityError> ModelGrabarUsuario(string nombre, string apellido, DateTime fecha_nacimiento, string sexo, string nacionalidad,
         DateTime fecha_alta, string direccion, string email, string telefono, string estado_civil, int numero_hijos,
        int numero_seguridad_social, string tipo, string porcentaje, string identificacion, string n_identificacion,
        string permiso_trabajo, string permiso_recidencia, string empadronado, string tipo_licencia)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetousuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Fecha_Nacimiento = fecha_nacimiento,
                Sexo = sexo,
                Nacionalidad = nacionalidad,
                Fecha_Alta = fecha_alta,
                Direccion = direccion,
                Email = email,
                Telefono = telefono,
                EstadoCivil = estado_civil,
                NumeroHijos = numero_hijos,
                NumeroSeguridadSocial = numero_seguridad_social,
                Identificacion = identificacion,
                N_Identificacion = n_identificacion,
                Permiso_Trabajo = permiso_trabajo,
                Permiso_Recidencia = permiso_recidencia,
                Empadronado = empadronado,
                Tipo_Licencia = tipo_licencia
            };
            try
            {
                _contexto.Usuario.Add(Objetousuario);
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
            Lista.Add(dato);
            return Lista;
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
        ///EDITAR
        public List<IdentityError> ModeloEditarUsuario(int usuarioId ,string nombre, string apellido,DateTime fecha_nacimiento,string sexo,string nacionalidad,
         DateTime fecha_alta, string direccion,string  email,string telefono,string estado_civil,int numero_hijos,
        int numero_seguridad_social, string tipo,string porcentaje,string identificacion,string n_identificacion,
        string permiso_trabajo,string permiso_recidencia,string empadronado,string tipo_licencia)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var usuario = new Usuario
            {
                UsuarioId=usuarioId,
                Nombre = nombre,
                Apellido = apellido,
                Fecha_Nacimiento = fecha_nacimiento,
                Sexo = sexo,
                Nacionalidad = nacionalidad,
                Fecha_Alta = fecha_alta,
                Direccion=direccion,
                Email=email,
                Telefono=telefono,
                EstadoCivil=estado_civil,NumeroHijos =numero_hijos,
                NumeroSeguridadSocial=numero_seguridad_social,
                Identificacion=identificacion, N_Identificacion=n_identificacion,
               Permiso_Trabajo=permiso_trabajo, Permiso_Recidencia=permiso_recidencia, Empadronado=empadronado, Tipo_Licencia=tipo_licencia
            };
            try
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();
                regresa = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }catch (Exception ex)
            {
                regresa = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaEditar.Add(regresa);
            return ListaEditar ;
        }
        ///ELIMINAR
        public List<IdentityError> ModeloeliminarUsuario(int usuarioid)
        {
            List<IdentityError> listaeliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var usuario = new Usuario
            {
                UsuarioId = usuarioid
            };
            try
            {
                _contexto.Usuario.Remove(usuario);
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
            listaeliminar.Add(dato);
            return listaeliminar;
        }
    }
}
