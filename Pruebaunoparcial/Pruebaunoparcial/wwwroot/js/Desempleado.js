class ClaseDesempleado {
    constructor(tiempo,fecha_ini,fecha_fin, accion) {
        this.tiempo = tiempo;
        this.fecha_fin = fecha_fin;
        this.fecha_ini = fecha_ini;
        this.accion = accion;
    }
    GuardarDesempleado(id) {
        var tiempo = this.tiempo;
        var fecha_fin = this.fecha_fin;
        var fecha_ini = this.fecha_ini;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { tiempo,fecha_ini,fecha_fin },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: accion,
                data: { id, tiempo, fecha_ini, fecha_fin },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeDesempleados() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaDesempleado').html(val[0]);
                });
            }
        });
    }
    CargarDesmpleado(DesempleadoId) {
        var accion = this.accion;

        $.post(
            accion,
            { DesempleadoId },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('tiempo').value = respuesta[0].tiempo;
                document.getElementById('fecha_ini').value = respuesta[0].fecha_ini;
                document.getElementById('feccha_fin').value = respuesta[0].tiempo;
                document.getElementById('DesempleadoId').value = respuesta[0].DesempleadoId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarDesempleado(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                if (respuesta[0].code == 'Save') {
                    this.limpiarcajas();
                }
            }
        });
    }

    limpiarcajas() {
        document.getElementById('tiempo').value = '';
        document.getElementById('fecha_ini').value = '';
        document.getElementById('fecha_fin').value = '';
        document.getElementById('DesempleadoId').value = '';
        //$('#sexo').value = '';
        $('#IngresoDesempleados').modal('hide');
        ListaSexo();
    }
}