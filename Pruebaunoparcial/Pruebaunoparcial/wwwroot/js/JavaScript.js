class ClaseDesempleado {
    constructor(sexo, accion) {
        this.sexo = sexo;
        this.accion = accion;
    }
    GuardarSexo(id) {
        var sexo = this.sexo;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { sexo },
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
                data: { id, sexo },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeSexos() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaSexo').html(val[0]);
                });
            }
        });
    }
    CargarSexo(sexoId) {
        var accion = this.accion;

        $.post(
            accion,
            { sexoId },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('sexo').value = respuesta[0].detalle;
                document.getElementById('sexoId').value = respuesta[0].sexoId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarSexo(id) {
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
        document.getElementById('sexo').value = '';
        document.getElementById('sexoId').value = '';
        //$('#sexo').value = '';
        $('#IngresoSexos').modal('hide');
        ListaSexo();
    }
}