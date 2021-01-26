// TABLA DEPENDIENTE
var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblCiudads").DataTable({
        "ajax": {
            "url": "/admin/ciudads/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "CiudadId", "width": "15" },
            { "data": "NombreCiudad", "width": "15" },



,{
                "data": "CiudadId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/Ciudads/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Ciudads/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros en la tabla Ciudad"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Esta seguro de borrar este registro?",
        text: "Este contenido una vez borrado no se podra recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar el registro!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}

