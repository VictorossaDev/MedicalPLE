// TABLA DEPENDIENTE
var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblPacientes").DataTable({
        "ajax": {
            "url": "/admin/pacientes/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "PacienteId", "width": "15" },
            { "data": "NumeroDocumento", "width": "15" },
            { "data": "NombresApellidos", "width": "15" },
            { "data": "Fechanacimiento", "width": "15" },
            { "data": "Edad", "width": "15" },
            { "data": "Lugarnacimiento", "width": "15" },
            { "data": "Nacionalidad", "width": "15" },
Embarazo
            { "data": "UltimaMestruacion", "width": "15" },
            { "data": "Semanaembarazo", "width": "15" },
            { "data": "Numeroembarazo", "width": "15" },
            { "data": "Direccion", "width": "15" },
            { "data": "Barrio", "width": "15" },
            { "data": "Correo", "width": "15" },
            { "data": "Fijo", "width": "15" },
            { "data": "Celular", "width": "15" },
            { "data": "NombreResponsable", "width": "15" },
            { "data": "FijoResponsable", "width": "15" },
            { "data": "CelularResponsable", "width": "15" },
            { "data": "ParentescoResponsable", "width": "15" },
            { "data": "NombreReferida", "width": "15" },
            { "data": "FijoReferido", "width": "15" },
            { "data": "CelularReferido", "width": "15" },
            { "data": "ReferidoPor", "width": "15" },
            { "data": "NombreAcompanante", "width": "15" },
            { "data": "FijoAcompanante", "width": "15" },
            { "data": "CelularAcompanante", "width": "15" },
            { "data": "ParentescoAcompanante", "width": "15" },
            { "data": "NombreMadreMenor", "width": "15" },
            { "data": "CedulaMadreMenor", "width": "15" },
            { "data": "TelefonoMadreMenor", "width": "15" },
            { "data": "OcupacionMadreMenor", "width": "15" },
            { "data": "NombrePadreCuidadorMenor", "width": "15" },
            { "data": "CedulaPadreCuidadorMenor", "width": "15" },
            { "data": "TelefonoPadreCuidadorMenor", "width": "15" },
            { "data": "OcupacionPadreCuidadorMenor", "width": "15" },
            { "data": "ParentescoPadreCuidador", "width": "15" }







,{
                "data": "PacienteId",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/Pacientes/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Pacientes/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros en la tabla Paciente"
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

