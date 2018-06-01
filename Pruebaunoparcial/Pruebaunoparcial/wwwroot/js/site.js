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
<<<<<<< HEAD



    var grabaCurso = () => {
        var curso = document.getElementById("curso").value;
        var CursoId = document.getElementById("CursoId").value;
        if (CursoId == '') {
            estudioId = '0';
            var accion = 'Curso/ControladorGuardaCurso';
        } else {
            var accion = 'curso/ControladorEditaCurso';
        }
        var graba = new ClaseCurso(curso, accion);
        graba.GuardarCurso(CursoId);
    }

    var ListaCurso = () => {
        var accion = 'Curso/ControladorListaCurso';
        var estudio = new ClaseEstudio('', accion);
        estudio.ListaCurso();
    }

    var CargaCurso = (CursoId) => {
        var accion = 'Curso/ControladorUnCurso';

        var uncurso = new ClaseCurso('', accion);
        unestudio.CargarEstudio(CursoId);
    }

    var eliminaCurso = (id) => {
        var accion = 'Curso/ControladorEliminarCurso';
        var eliminacurso = new ClaseCurso('', accion);
        var res = confirm('Desea Eliminar el registro');

        if (res == true) {
            eliminacurso.EliminarCurso(id);
            alert('Reguistro Eliminado');

        } else {
            alert('Usted cancelo la eliminacion del reguistro');
        }
    }


} 
}
=======
}


var grabaempleos = () => {
    var cargo = document.getElementById('Cargo').value;
    var empresa = document.getElementById('Empresa').value;
    var fechaini = document.getElementById('Fecha_ini').value;
    var fechafin = document.getElementById('Fecha_fin').value;
    var mediador = document.getElementsById('Mediador').value;
    var emplosid = document.getElementsById('EmpleoId').value;
    if (emplosid === '') {
        emplosid = '0';
        var accion = 'Empleos/ControladorGurdaempleo';
    } else {
        var accion = 'Empleos/ControladoreditaEmpleos'
    }
    var graba = new ClaseEmpleo(empleo, accion);
    graba.Guardarempleo(emplosid);
}

var listaempleos =() => {
    var accion = "Empleos/Controladorlistaempleos";
    var empleo = new ClaseEmpleo('', accion);
    empleo.listadeempleo();
}

var eliminaempleos = (id) => {
    var accion = 'Empleos/Controladoreliminaempleos';
    var eliminaempleo = new ClaseEmpleo('', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaempleo.EliminaEmpleo(id);
        alert('Registro eliminado');
    } else {
        alert('Usted cancelo la eliminacion del registro');
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
        DesempleadoId == 0;
        var accion = 'Desempleado/ControladorGuardaDesempleado';
    }
    else {
        var accion = 'Desempleado/ControladorEditaDesempleado';
    }
    var graba = new ClaseDesempleado(tiempo,fecha_ini,fecha_fin, accion);
    graba.GuardarDesempleado(DesempleadoId);
}

var ListaDesempleado = () => {
    var accion = 'Desempleado/ControladorListaDesempleados';
    var Desempleado = new ClaseDesempleado('', accion);
    Desempleado.ListadeDesempleados();
}
var CargaDesempleado = (DesempleadoId) => {
    var accion = 'Desempleado/ControladorUnDesempleado';
    var unDesempleado = new ClaseDesempleado('', accion);
    unDesempleado.CargarDesempleado(DesempleadoId);
}
var eliminaDesempleado = (id) => {
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

//les queda 05 minutos hora actual 19:25
>>>>>>> 1c02e5266baec5150b7393e0159d8272f6bef625
