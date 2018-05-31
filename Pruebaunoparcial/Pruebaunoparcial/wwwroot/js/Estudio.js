class ClaseEstudio {
    constructor(estudio, accion) {
        this.estudio = estudio;
        this.accion = accion;
    }
    GuardarEstudio(id) {
        var estudio = this.estudio;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { estudio },
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
                data: { id, estudio },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }

    }


    ListadeEstudios() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {

                    $('#ListaEstudio').html(val[0]);

                });
            }
        });
    }

    CargarEstudio(estudioId) {
        var accion = this.accion;
        $.post(
            accion,

            { estudioId },
            (respuesta) => {
                document.getElementById('estudio').value
                    = respuesta[0].detalle;
                document.getElementById('estudioId').value
                    = respuesta[0].estudioId;
            }
        );
    }

    EliminarEstudio(id) {
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
        document.getElementById('estudio').value = '';
        document.getElementById('estudioId').value = '';
        $('#estudio').value = '';
        $('#IngresoEstudio').modal('hide');
        ListaEstudios();

    }
}