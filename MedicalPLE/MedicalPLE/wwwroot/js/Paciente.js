var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblpaciente").DataTable({
        "ajax": {
            "url": "/admin/Paciente/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "pacienteId", "width": "5%" },
            { "data": "numeroDocumento", "width": "10%" },
            { "data": "nombreApellido", "width": "10%" },
            { "data": "fechaNacimiento", "width": "10%" },
            { "data": "edad", "width": "10%" },
            { "data": "lugarNacimiento", "width": "10%" },
            { "data": "nacionalidad", "width": "10%" },

            { "data": "tipodoc.nombreTipodoc", "width": "15%" },
            { "data": "estadoCivil.nombreEstadoCivil", "width": "15%" },
            { "data": "genero.nombreGenero", "width": "15%" },
            { "data": "tipoSangre.nombreTipoSangre", "width": "15%" },
            { "data": "eps.nombreEps", "width": "15%" },
            { "data": "ciudad.nombreCiudad", "width": "15%" },
            {
                "data": "pacienteId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Paciente/Edit/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/Paciente/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash-alt'></i> Borrar
                                </a>
                            </div>
                            `;
                }, "width": "30%"
            },
        ],
        "language": {
            "emptyTable": "No hay registros."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
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

