
class ClaseJSusuario {
    constructor(nombre, apellido, fecha_nacimiento, sexo, nacionalidad, fecha_alta, direccion, email, telefono, estado_civil, numero_hijos,
        numero_seguridad_social,tipo, porcentaje, identificacion, n_identificacion, permiso_trabajo, permiso_recidencia, empadronado, tipo_licencia, accion) {
        this.nombre = nombre;
        this.apellido = apellido;
        this.fecha_nacimiento = fecha_nacimiento;
        this.sexo = sexo;
        this.nacionalidad = nacionalidad;
        this.fecha_alta = fecha_alta;
        this.direccion = direccion;
        this.email = email;
        this.telefono = telefono;
        this.estado_civil = estado_civil |;
        this.numero_hijos = numero_hijos;
        this.numero_seguridad_social = numero_seguridad_social;
        this.tipo = tipo;
        this.porcentaje = porcentaje;
        this.identificacion = identificacion;
        this.n_identificacion = n_identificacion;
        this.permiso_trabajo = permiso_trabajo;
        this.permiso_recidencia = permiso_recidencia;
        this.empadronado = empadronado;
        this.tipo_licencia = tipo_licencia;
        this.accion = accion;
    }
    GuardarUsuario(idUsu)
    {
        var nombre = this.nombre;
        var apellido = this.apellido;
        var fecha_nacimiento = this.fecha_nacimiento;
        var sexo = this.sexo;
        var nacionalidad = this.nacionalidad;
        var fecha_alta = this.fecha_alta;
        var direccion = this.direccion;
        var email = this.email;
        var telefono = this.telefono;
        var estado_civil = this.estado_civil;
        var numero_hijos = this.numero_hijos;
        var numero_seguridad_social = this.numero_seguridad_social;
        var tipo = this.tipo;
        var porcentaje = this.porcentaje;
        var identificacion = this.identificacion;
        var n_identificacion = this.n_identificacion;
        var permiso_trabajo = this.permiso_trabajo;
        var permiso_recidencia = this.permiso_recidencia;
        var empadronado = this.empadronado;
        var tipo_licencia = this.tipo_licencia;
        var accion = this.accion;
        var resultado = '';
        if (idUsu === '0')
        {
            $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data:
                    {
                        nombre, apellido, fecha_nacimiento, sexo, nacionalidad,
                        fecha_alta, direccion, email, telefono, estado_civil, numero_hijos,
                        numero_seguridad_social, tipo, porcentaje, identificacion, n_identificacion,
                        permiso_trabajo, permiso_recidencia, empadronado, tipo_licencia
                    },
                    success: (respuesta) =>
                    {
                        if (respuesta[0].code == 'Save') {
                            this.limpiarcajas();
                        }
                    }
                });
        }
        else {
               $.ajax(
                {
                    type: "POST",
                    url: accion,
                       data: {
                           idUsu, nombre, apellido, fecha_nacimiento, sexo, nacionalidad,
                           fecha_alta, direccion, email, telefono, estado_civil, numero_hijos,
                           numero_seguridad_social, tipo, porcentaje, identificacion, n_identificacion,
                           permiso_trabajo, permiso_recidencia, empadronado, tipo_licencia
                       },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'Save') {
                            this.limpiarcajas();
                        }
                    }
                });
        }


    
    }

    ListadeUsuario() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaUsuario').html(val[0]);
                });
            }
        });

    }

    cargarUsuario(usuarioid) {
        var accion = this.accion;
        $.post(
            accion,
            { usuarioid },
            (respuesta) => {
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('apellido').value = respuesta[0].apellido;
                document.getElementById('fecha_nacimiento').value = respuesta[0].fecha_nacimiento;
                document.getElementById('sexo').value = respuesta[0].sexo;
                document.getElementById('nacionalidad').value = respuesta[0].nacionalidad;
                document.getElementById('fecha_alta').value = respuesta[0].fecha_alta;
                document.getElementById('direccion').value = respuesta[0].direccion;
                document.getElementById('email').value = respuesta[0].email;
                document.getElementById('telefono').value = respuesta[0].telefono;
                document.getElementById('estado_civil').value = respuesta[0].estado_civil;
                document.getElementById('numero_hijos').value = respuesta[0].numero_hijos;
                document.getElementById('numero_seguridad_social').value = respuesta[0].numero_seguridad_social;
                document.getElementById('tipo').value = respuesta[0].tipo;
                document.getElementById('porcentaje').value = respuesta[0].porcentaje;
        document.getElementById('identificacion').value = respuesta[0].identificacion;
        document.getElementById('n_identificacion').value = respuesta[0].n_identificacion;
        document.getElementById('permiso_trabajo').value = respuesta[0].permiso_trabajo;
        document.getElementById('permiso_recidencia').value = respuesta[0].permiso_recidencia;
        document.getElementById('empadronado').value = respuesta[0].empadronado;
        document.getElementById('tipo_licencia').value = respuesta[0].tipo_licencia;
                               document.getElementById('sexoId').value = respuesta[0].sexoId;
            }

        )
    }
    eliminarUsu(usuid) {
        var accion = this.accion;
        $.ajax(
            {
                type: "POST",
                url: accion,
                data: { usuid },
                success: (respuesta) => {
                    if (respuesta[0].code == 'Save') {
                        this.limpiarcajas();
                    }
                }
            });
    }
    limpiarcajas() {
        document.getElementById('nombre').value = '';
        document.getElementById('apellido').value = '';
        document.getElementById('fecha_nacimiento').value ='';
        document.getElementById('sexo').value = '';
        document.getElementById('nacionalidad').value = '';
        document.getElementById('fecha_alta').value = '';
        document.getElementById('direccion').value = '';
        document.getElementById('email').value = '';
        document.getElementById('telefono').value = '';
        document.getElementById('estado_civil').value = '';
        document.getElementById('numero_hijos').value = '';
        document.getElementById('numero_seguridad_social').value = '';
        document.getElementById('tipo').value = '';
        document.getElementById('porcentaje').value = '';
        document.getElementById('identificacion').value ='';
        document.getElementById('n_identificacion').value = '';
        document.getElementById('permiso_trabajo').value = '';
        document.getElementById('permiso_recidencia').value = '';
        document.getElementById('empadronado').value = '';
        document.getElementById('tipo_licencia').value = '';
        document.getElementById('sexoId').value = '';
        
        $('#nombre').value = '';
        $('#apellido').value = '';
        $('#fecha_nacimiento').value = '';
        $('#sexo').value = '';
        $('#nacionalidad').value = '';
        $('#fecha_alta').value = '';
        $('#direccion').value = '';
        $('#email').value = '';
        $('#telefono').value = '';
        $('#estado_civil').value = '';
        $('#numero_hijos').value = '';
        $('#numero_seguridad_social').value = '';
        $('#tipo').value = '';
        $('#porcentaje').value = '';
        $('#identificacion').value = '';
        $('#n_identificacion').value = '';
        $('#permiso_trabajo').value = '';
        $('#permiso_recidencia').value = '';
        $('#empadronado').value = '';
        $('#tipo_licencia').value = '';      
        $('#IngresoUsuario').modal('hide');
        ListaUsuarios();
    }

}
