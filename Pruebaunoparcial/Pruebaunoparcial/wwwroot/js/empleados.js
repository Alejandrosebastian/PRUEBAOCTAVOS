class claseepleado {
    constructor(nombre, accion)

    GuardarEmple() {
        var nombre = this.nombre;
        var accion = this.accion;
        var resultado = '';
               $.ajax(
                {
                    type: "POST",
                    url: accion,
                    data: { nombre },
                    success: (respuesta) => {
                        if (respuesta[0].code == 'Save') {
                            this.limpiarcajas();
                        }
                    }
                });
              
    }
    limpiarcajas() {
        document.getElementById('nombre').value = '';
        $('#nombre').value = '';
        ListaSexos();
    }
}