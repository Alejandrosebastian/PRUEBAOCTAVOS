

class ClaseEmpleo
{
    constructor(empleo, accion)
    {
        this.empleo = empleo;
        this.accion = accion;
    }
    Guardarempleo(id) {
        var empleo = this.empleo;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { empleo },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {

                    }
                }
            });

        } else {
            $.ajax({
                type: "POST",
                url: accion,
                data: { id, empleo },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {

                    }
                }
            });
        }
    }

    listadeempleo() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#listaempleo').html(val[0]);

                });
            }
        });

    }

    EditarEmpleo(empleoId) {
        var accion = this.accion;
        $.post(
            accion,
            { empleoId },
            (respuesta) => {
                document.getElementById('empleo').value = respuesta[0].empleo;
                document.getElementById('empleoId').value = respuesta[0].empleoId;

            }
        );
    }

    EliminaEmpleo(empleoId) {
        var accion = this.accion;
        $.ajax(
            {
                type: "POST",
                url: accion,
                data: { id },
                success: (respuesta) => {
                    if (respuesta[0].code == 'Save') {

                    }
                }
            });
    }
}