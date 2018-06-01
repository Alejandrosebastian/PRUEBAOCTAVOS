﻿// Write your JavaScript code.
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