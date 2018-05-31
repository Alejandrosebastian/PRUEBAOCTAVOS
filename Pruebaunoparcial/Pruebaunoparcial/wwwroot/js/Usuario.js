
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
                    data{},
                    success: (respuesta) =>
                    {
                        if (respuesta[0].code == 'Save') {
                            this.limpiarcajas();
                        }
                    }
                }
            );
        }
    }

}
