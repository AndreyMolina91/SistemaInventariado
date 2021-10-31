var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [

            { "data": "userName", "width": "10%" },
            { "data": "nombre", "width": "10%" },
            { "data": "apellidos", "width": "20%" },
            { "data": "email", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "role", "width": "5%" },
            {
                "data": {
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                //Por medio de esta funcion recibimos en data el Json de id + lockountEnd del User gracias al metodo GetAll
                "render": function (data) {
                    //Creamos fecha de hoy
                    var fechaHoy = new Date().getTime();
                    //Creamos fecha que contenga el objeto al que le pertenezca el id recibido por data y obtenemos el lockountEnd de la BD
                    var bloqueo = new Date(data.lockoutEnd).getTime();
                    //Comparamos ambas fechas si es mayor la del bloqueo a la de hoy es porque esta bloqueado el usuario
                    if (bloqueo > fechaHoy) {
                        //Usuario esta bloqueado entonces enviamos al API el data.id 
                        return `<div class="text-center">

                                <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer">
                               <i class="fas fa-unlock"></i> Desbloquear
                               </a>
                            </div>
                          `;

                    }
                    else {
                        //Si no es mayor es porque el usuario no está bloqueado asi que enviamos el data.id para bloquearlo
                        return `<div class="text-center">

                                <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer">
                               <i class="fas fa-user-lock"></i> Bloquear
                               </a>
                            </div>
                          `;
                    }

                }, "width" : "25%"

            },
            //{
            //    "data": "id",
            //    "render": function (data) {
            //        return `<div class="text-center">

            //                    <a href="/Admin/Categoria/Upsert/${data}" class="btn btn-primary text-white" style="cursor:pointer">
            //                        <i class="fas fa-edit"></i>
            //                    </a>

            //                    <a onclick=Delete("/Admin/Categoria/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
            //                    <i class="fas fa-trash"></i>
            //                    </a>
            //                </div>
            //               `;
            //    }, "width": "20%"
        ]

    });
}

//Ejecutamos la funcion del metodo onclick por medio de Ajax y un sweet alert para el mensaje de confirmacion
function LockUnlock(id) {
    //Se ejecuta el sweet alert con la consulta
    swal({
        title: "¿Seguro que desea ejecutar esta acción?",
        icon: "warning",
        buttons: true,
        dangerMode: true
        //Si elige OK entonces procede a ejecutar la variable bloquear que será la llave true para ejecutar el ajax
    }).then((bloquear) => {
        if (bloquear) {
            $.ajax({
                //Tipo post envia los datos al API en formato JSON, 
                type: "POST",
                //Cual metodo ejecutar? Lockunlock en controller user
                url: '/Admin/User/LockUnlock',
                //El Json a enviar recibe la data por medio del id. ¿Que datos? los del body por medio del onclick: id + Fecha hoy ó lockoutend.getdate
                data: JSON.stringify(id),
                //Se envia en formato JSON
                contentType: "application/json",
                //Si el post es 200 se envia por parametro el data que es el JSON {"id" : iduser, "lockoutEnd": el getDate}
                success: function (data) {
                    if (data.success) {
                        //Una vez ejecutado el post satisfactoriamente se despliega la notificacion toast con el msj del controller
                        toastr.success(data.message);
                        //Se recarga la tabla
                        datatable.ajax.reload();
                    }
                    else {
                        //De lo contrario mensaje de error
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}