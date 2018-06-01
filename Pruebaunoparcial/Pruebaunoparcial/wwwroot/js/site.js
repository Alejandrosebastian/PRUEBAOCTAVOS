// Write your JavaScript code.
var grabarseguimiento = () => {
    var nombre = document.getElementById('nombre').value;
    var apellido = document.getElementById('apellido').value;
    var cedula = document.getElementById('cedula').value;
    var direccion = document.getElementById('direccion').value;
    var telefono = document.getElementById('telefono').value;
    var email = document.getElementById('email').value;
    var tipodegabinete = document.getElementById('tipodegabinete').value;
    var accion = 'Empleados/ControladorGuardaEmpleado';
    var graba = new claseepleado(nombre, accion);    
    graba.GuardarEmple;
}

var grabaEstudio = () => {
    var estudio = document.getElementById("estudio").value;
    var estudioId = document.getElementById("estudioId").value;
    if (estudioId == '') {
        estudioId = '0';
        var accion = 'Estudio/ControladorGuardaEstudio';
    } else {
        var accion = 'Estudio/ControladorEditaEstudio';
    }
    var graba = new ClaseEstudio(estudio, accion);
    graba.GuardarEstudio(estudioId);
}

var ListaEstudio = () => {
    var accion = 'Estudio/ControladorListaEstudio';
    var estudio = new ClaseEstudio('', accion);
    estudio.ListadeEstudio();
}

var CargaEstudio = (estudioId) => {
    var accion = 'Estudio/ControladorUnEstudio';

    var unestudio = new ClaseEstudio('', accion);
    unestudio.CargarEstudio(estudioId);
}

var eliminaEstudio = (id) => {
    var accion = 'Estudio/ControladorEliminarEstudio';
    var eliminaestudio = new ClaseEstudio('', accion);
    var res = confirm('Desea Eliminar el registro');

    if (res == true) {
        eliminaestudio.EliminarEstudio(id);
        alert('Reguistro Eliminado');

    } else {
        alert('Usted cancelo la eliminacion del reguistro');
    }
}

var grabaDiscapacidad = () => {
    var discapacidad = document.getElementById("discapacidad").value;
    var discapacidadId = document.getElementById("discapacidadId").value;
    if (discapacidadId == '') {
        discapacidadId = '0';
        var accion = 'Discapacidad/ControladorGuardaDiscapacidad';
    } else {
        var accion = 'Discapacidad/ControladorEditaDiscapacidad';
    }
    var graba = new ClaseDiscapacidad(discapacidad, accion);
    graba.GuardarDiscapacidad(discapacidadId);
}

var ListaDiscapacidad = () => {
    var accion = 'Discapacidad/ControladorListaDiscapacidad';
    var discapacidad = new ClaseDiscapacidad('', accion);
    discapacidad.ListaDediscapacidad();
}

var CargaDiscapacidad = (discapacidadId) => {
    var accion = 'Discapacidad/ControladorUnDiscapacidad';

    var undiscapacidad = new ClaseDiscapacidad('', accion);
    undiscapacidad.CargarDiscapacidad(discapacidadId);
}

var eliminaDiscapacidad = (id) => {
    var accion = 'Discapacidad/ControladorEliminarDiscapacidad';
    var eliminadiscapacidad = new ClaseDiscapacidad('', accion);
    var res = confirm('Desea Eliminar el registro');

    if (res == true) {
        eliminadiscapacidad.EliminarDiscapacidad(id);
        alert('Reguistro Eliminado');

    } else {
        alert('Usted cancelo la eliminacion del reguistro');
    }
}
$().ready(() => {
    //mostrardatosjs();
    // listaClientes(1,'null');
    ListaDesempleado();
    ListaUsuarios();
});

var grabaDesempleado = () => {
    var tiempo = document.getElementById('tiempo').value;
    var fecha_ini = document.getElementById('fecha_ini').vale;
    var fecha_fin = document.getElementById('fecha_fin').vale;
    var DesempleadoId = document.getElementById('DesempleadoId').value;


    if (DesempleadoId == '') {
        sexoId == 0;
        var accion = 'Desempleado/ControladorGuardaDesempleado';
    }
    else {
        var accion = 'Desempleado/ControladorEditaDesempleado';
    }
    var graba = new ClaseDesempleado(tiempo,fecha_ini,fecha_fin, accion);
    graba.GuardarDesempleado(DesempleadoId);
}

var ListaSexo = () => {
    var accion = 'Desempleado/ControladorListaDesempleados';
    var Desempleado = new ClaseDesempleado('', accion);
    Desempleado.ListadeDesempleados();
}
var CargaSexo = (sexoId) => {
    var accion = 'Desempleado/ControladorUnDesempleado';
    var unDesempleado = new ClaseDesempleado('', accion);
    unDesempleado.CargarSexo(DesempleadoId);
}
var eliminaSexo = (id) => {
    var accion = 'Sexos/ControladorEliminarDesempleado';
    var eliminaDesempleado = new ClaseSexo('', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminasexo.EliminarDesempleado(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}


//usuario
var grabaUsuario = () => {

   var nombre = document.getElementById('nombre').value;
    var apellido= document.getElementById('apellido').value ;
    var fecha_nacimiento = document.getElementById('fecha_nacimiento').value;
    var sexo = document.getElementById('sexo').value ;
    var nacionalidad = document.getElementById('nacionalidad').value;
    var fecha_alta =  document.getElementById('fecha_alta').value;
    var direccion =  document.getElementById('direccion').value ;
    var email =  document.getElementById('email').value;
    var telefono =  document.getElementById('telefono').value;
    var estado_civil =  document.getElementById('estado_civil').value;
    var numero_hijos =  document.getElementById('numero_hijos').value;
    var numero_seguridad_social  =  document.getElementById('numero_seguridad_social').value;
    var tipo =  document.getElementById('tipo').value;
    var porcentaje = document.getElementById('porcentaje').value ;
    var identificacion =  document.getElementById('identificacion').value;
    var n_identificacion = document.getElementById('n_identificacion').value;
    var permiso_trabajo = document.getElementById('permiso_trabajo').value;
    var permiso_recidencia = document.getElementById('permiso_recidencia').value;
    var empadronado = document.getElementById('empadronado').value ;
    var tipo_licencia = document.getElementById('tipo_licencia').value;
    var UsuarioId = document.getElementById('UsuarioId').value;
     if (UsuarioId === '') {
         UsuarioId = '0';
         var accion = 'Usuarios/ControladorGuardarUsuario';
    } else {

         var accion = 'Usuarios/Controladoreditarusuario';
    }
    var graba = new ClaseJSusuario(nombre, apellido, fecha_nacimiento, sexo, nacionalidad,
        fecha_alta, direccion, email, telefono, estado_civil, numero_hijos,
        numero_seguridad_social, tipo, porcentaje, identificacion, n_identificacion,
        permiso_trabajo, permiso_recidencia, empadronado, tipo_licencia, accion);
        graba.GuardarUsuario(UsuarioId);
}


var ListaUsuarios = () => {
    var accion = 'Usuarios/Controladorlistausuario';
    var Usuario = new ClaseJSusuario('', accion);
    Usuario.ListadeUsuarios();

}

var cargausuario = (usuarioid) => {
    var accion = 'ControladorunUsuario';
    var unusuario = new ClaseJSusuario('', accion);
    unusuario.cargarusuario(usuarioid)
}

var eliminausu = (usuid) => {
    var accion = 'Usuarios/ControladorEliminaUsuario';
    var eliminarusu = new ClaseJSusuario('', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminarusu.eliminausu(usuid);
        alert('Registro eliminado');
    }
    else {
        alert('Usted cancelo la eliminacion del registro');
    }
}