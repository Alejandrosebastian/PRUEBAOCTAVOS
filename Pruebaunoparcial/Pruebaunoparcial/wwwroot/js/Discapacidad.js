class ClaseDiscapacidad {
    constructor(discapacidad, accion) {
        this.discapacidad = discapacidad;
        this.accion = accion;
    }
    GuardarDiscapacidad(id) {
        var discapacidad = this.discapacidad;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { discapacidad },
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
                data: { id, discapacidad },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }

    }


    ListadeDiscapacidades() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {

                    $('#ListaDiscapacidad').html(val[0]);

                });
            }
        });
    }

    CargarDiscapacidad(discapacidadId) {
        var accion = this.accion;
        $.post(
            accion,

            { discapacidadId },
            (respuesta) => {
                document.getElementById('discapacidad').value
                    = respuesta[0].detalle;
                document.getElementById('discapacidadId').value
                    = respuesta[0].discapacidadId;
            }
        );
    }

    EliminarDiscapacidad(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                if (respuesta[0].code == "save") {
                    this.limpiarcajas();
                }
            }
        });
    }

    limpiarcajas() {
        document.getElementById('discapacidad').value = '';
        document.getElementById('discapacidadId').value = '';
        $('#discapacidad').value = '';
        $('#IngresoDiscapacidad').modal('hide');
        ListaDiscapacidades();

    }
}