var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/Admin/Producto/GetAll"
        },
        "columns": [

            { "data": "serieId", "width": "15%" },
            { "data": "descripcion", "width": "20%" },
            { "data": "categoria.nombre", "width": "15%" },
            { "data": "marca.nombre", "width": "15%" },
            {
                "data": "padre.descripcion",
                "render": function (data) {
                    if (data == null) {
                        return "";
                    }
                    else {
                        return data;
                    }
                }, "width": "15%" },
            { "data": "precio", "width": "15%" }, 
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">

                                <a href="/Admin/Producto/Upsert/${data}" class="btn btn-primary text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>

                                <a onclick=Delete("/Admin/Producto/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash"></i>
                                </a>
                            </div>
                           `;
                }, "width": "20%"
            }
        ]

    });
}

function Delete(url) {
    swal({
        title : "¿Seguro que desea eliminar Producto?",
        text: "Este registro no se podrá recuperar",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((eliminar) => {
        if (eliminar) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}