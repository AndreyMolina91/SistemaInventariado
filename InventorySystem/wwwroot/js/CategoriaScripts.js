var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/Admin/Categoria/GetAll"
        },
        "columns": [

            { "data": "nombre", "width": "20%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Categoria Activa";
                    }
                    else {
                        return "Categoria Inactiva";
                    }
                }, "width": "20%"
                
            },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">

                                <a href="/Admin/Categoria/Upsert/${data}" class="btn btn-primary text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>
                                </a>

                                <a onclick=Delete("/Admin/Categoria/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
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
        title : "¿Seguro que desea eliminar la Categoria?",
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