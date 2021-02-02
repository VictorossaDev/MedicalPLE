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
            { "data": "fijo", "width": "10%" },
            { "data": "celular", "width": "10%" },
            { "data": "nombreResponsable", "width": "10%" },
            { "data": "fijoResponsable", "width": "10%" },
            { "data": "celularResponsable", "width": "10%" },
            { "data": "parentescoResponsable", "width": "10%" },
            { "data": "nombreReferida", "width": "10%" },
            { "data": "fijoReferido", "width": "10%" },
            { "data": "celularReferido", "width": "10%" },
            { "data": "referidoPor", "width": "10%" },
            { "data": "nombreAcompanante", "width": "10%" },
            { "data": "fijoAcompanante", "width": "10%" },
            { "data": "celularAcompanante", "width": "10%" },
            { "data": "parentescoAcompanante", "width": "10%" },
            { "data": "nombreMadreMenor", "width": "10%" },
            { "data": "cedulaMadreMenor", "width": "10%" },
            { "data": "telefonoMadreMenor", "width": "10%" },
            { "data": "ocupacionMadreMenor", "width": "10%" },
            { "data": "nombrePadreCuidadorMenor", "width": "10%" },
            { "data": "cedulaPadreCuidadorMenor", "width": "10%" },
            { "data": "telefonoPadreCuidadorMenor", "width": "10%" },
            { "data": "ocupacionPadreCuidadorMenor", "width": "10%" },
            { "data": "parentescoPadreCuidador", "width": "10%" },
            { "data": "tipodoc.nombretipodoc", "width": "15%" },
            { "data": "tiposangre.nombretiposangre", "width": "15%" },
            { "data": "estadocivil.nombreestadocivil", "width": "15%" },
            { "data": "genero.nombregenero", "width": "15%" },
            { "data": "eps.nombreeps", "width": "15%" },
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

