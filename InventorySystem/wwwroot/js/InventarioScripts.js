var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/InventoryArea/Inventario/GetAll"
        },
        "columns": [

            { "data": "bodega.nombre", "width": "20%" },
            { "data": "producto.descripcion", "width": "30%" },
            { "data": "producto.costo", "width": "10%", "className": "text-end" },
            { "data": "cantidad", "width": "5%", "className": "text-end" }   
        ]

    });
}

//Al ser una tabla y sección informativa solo cargaremos los datos en la tabla