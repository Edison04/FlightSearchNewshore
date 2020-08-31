$(document).ready(function () {
    $('.datepicker').datepicker();
});

$(document).ready(function () {
    $('select').formSelect();
});

$(document).bind("ajaxStart.mine", function () {
    $('#ajaxProgress').show();
});

$(document).bind("ajaxStop.mine", function () {
    $('#ajaxProgress').hide();
});

/* Función generica que ejecuta los eventos y retorna la respuesta */
function ExecuteGeneralFunction(path, action, info) {
    $.ajax({
        type: "POST",
        url: "/" + path + "/" + action,
        data: info,
        dataType: "json",
        success: function (data) {
            CargarInformacion(data);
        },
        error: function (msg) {
            console.log("Error: " + msg);
        }
    });
}

function BuscarVuelos() {
    var Origin = $("#selOrigen").val();
    var Destination = $("#selDestino").val();
    var From = $("#txtIda").val();

    var fecha = new Date(From);
    var month = (fecha.getMonth() + 1);
    var day = (fecha.getDate() + 1);

    if (month < 10) {
        month = "0" + month;
    }

    if (day < 10) {
        day = "0" + day;
    }

    var newFrom = fecha.getFullYear() + "-" + month + "-" + day;

    if (From != "") {
        var datos = { Origin: Origin, Destination: Destination, From: newFrom };
        ExecuteGeneralFunction("Home", "BuscarVuelos", datos);
    }
}

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate() + 1,
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
}

function CargarInformacion(data) {
    var tr;
    var json = JSON.parse(data);

    for (var i = 0; i < json.length; i++) {
        tr = $('<tr/>');
        tr.append("<td>" + json[i].DepartureStation + "</td>");
        tr.append("<td>" + json[i].ArrivalStation + "</td>");
        tr.append("<td>" + json[i].DepartureDate + "</td>");
        tr.append("<td> <a href=/Transports/Create?DepartureDate=" + json[i].DepartureDate + "&FlightNumber=" + json[i].FlightNumber + "&Price=" + json[i].Price + "&Currency=" + json[i].Currency + "&DepartureStation=" + json[i].DepartureStation + "&ArrivalStation=" + json[i].ArrivalStation + "> Continue </a> </td>");
        $('#detalleVuelos').append(tr);
    }
}