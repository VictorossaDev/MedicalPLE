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
            { "data": "nombresApellidos", "width": "10%" },
            { "data": "fechanacimiento", "width": "10%" },
            { "data": "edad", "width": "10%" },
            { "data": "lugarnacimiento", "width": "10%" },
            { "data": "nacionalidad", "width": "10%" },
            { "data": "embarazo", "width": "10%" },
            { "data": "ultimaMestruacion", "width": "10%" },
            { "data": "semanaembarazo", "width": "10%" },
            { "data": "numeroembarazo", "width": "10%" },
            { "data": "direccion", "width": "10%" },
            { "data": "barrio", "width": "10%" },
            { "data": "correo", "width": "10%" },
Fijo
            { "data": "celular", "width": "10%" },
            { "data": "nombreResponsable", "width": "10%" },
FijoResponsable
            { "data": "celularResponsable", "width": "10%" },
            { "data": "nombreReferida", "width": "10%" },
FijoReferido
            { "data": "celularReferido", "width": "10%" },
            { "data": "referidoPor", "width": "10%" },
            { "data": "nombreAcompanante", "width": "10%" },
FijoAcompanante
            { "data": "celularAcompanante", "width": "10%" },
            { "data": "nombreMadreMenor", "width": "10%" },
            { "data": "cedulaMadreMenor", "width": "10%" },
TelefonoMadreMenor
            { "data": "ocupacionMadreMenor", "width": "10%" },
            { "data": "nombrePadreCuidadorMenor", "width": "10%" },
            { "data": "cedulaPadreCuidadorMenor", "width": "10%" },
TelefonoPadreCuidadorMenor
            { "data": "ocupacionPadreCuidadorMenor", "width": "10%" },

            { "data": "tipodoc.nombreTipodoc", "width": "15%" },
            { "data": "tiposangre.nombreTiposangre", "width": "15%" },
            { "data": "estadocivil.nombreEstadocivil", "width": "15%" },
            { "data": "genero.nombreGenero", "width": "15%" },
            { "data": "eps.nombreEps", "width": "15%" },
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

