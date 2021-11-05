var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            //Metodo de la API en el controller
            "url": "/InventoryArea/Inventario/GetAllHistory"
        },
        "columns":
            [
                {//FechaInicial del objeto
                    "data": "fechaInicial", "width": "20%",
                    "render": function (data) {
                        //Obtener la fecha actual de contenida en el objeto en la propiedad FechaInicial por medio de data que es el objeto en nuestra API
                        var fecha = new Date(data);
                        return fecha.toLocaleString(); //Convierte Date a string usando el formato especificado de forma local en el modelo
                    }
                },
                {//FechaFinal del objeto
                    "data": "fechaFinal", "width": "20%",
                    "render": function (data) {
                        //Obtener la fecha actual de contenida en el objeto en la propiedad FechaFinal por medio de data que es el objeto en nuestra API
                        var fecha = new Date(data);
                        return fecha.toLocaleString(); //Convierte Date a string usando el formato especificado de forma local en el modelo
                    }
                },
                {//Campo bodega por nombre
                    "data": "bodega.nombre", "width": "15%",
                },
                {//Obtener usuario Nombre-Apellido
                    "data": function UserName(data) {
                        return data.usuarioApp.nombre + " " + data.usuarioApp.apellidos;
                    }, "width" : "20%"
                },
                {
                    "data": "id",
                    "render": function (data) {
                        return `
                                <div class="text-center">
                                    <a href="/InventoryArea/Inventario/HistoryDetails/${data}" class="btn btn-info text-white" style="cursor:pointer">
                                       <i class="fas fa-newspaper"></i>  Detalle
                                    </a>
                                </div>
                        `
                    }, "width" : "10%"
                }
            ]

    });
}
