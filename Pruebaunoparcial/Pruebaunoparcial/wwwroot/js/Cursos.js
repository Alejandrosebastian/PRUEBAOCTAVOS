class ClaseCurso { 
    constructor(curso, accion) {
        this.sexo = sexo;
        this.accion = accion; 
    } 

    GuardarCurso(id) {
        var curso = this.curso;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: {curso},
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
                data: { id, curso },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }

    }


    ListaCurso() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {

                    $('#IngresoCurso').html(val[0]);

                });
            }
        });
    }

    CargarCurso(CursoId) {
        var accion = this.accion;
        $.post(
            accion,

            { CursoId},
            (respuesta) => {
                document.getElementById('curso').value
                    = respuesta[0].detalle;
                document.getElementById('CursoId').value
                    = respuesta[0].CursoId;
            }
        );
    }

    EliminarCurso(id) {
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
        document.getElementById('curso').value = '';
        document.getElementById('CursoId').value = '';
        $('#curso').value = '';
        $('#IngresoCurso').modal('hide');
        ListaCursos();

    }



}