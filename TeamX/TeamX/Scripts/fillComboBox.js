$(function () {
    $("#query_results").empty();
    $("#query_results").append('<select id="combobox"><option value="">Select one..</option>');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Webservices/KlasService.asmx/GetKlassen",
        dataType: "json",
        success: function (msg) {
            var c = eval(msg.d);
            for (var i in c) {
                console.log(c[i]);
                $("#combobox option:last").after("<option value=" + c[i].klas_id + ">" + c[i].naam + "</option>");
            }
        }
    });
})

$(function () {
    $("#query_results").empty();
    $("#query_results").append('<select id="combobox1"><option value="">Select one..</option>');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Webservices/LesService.asmx/GetLokalen",
        dataType: "json",
        success: function (msg) {
            var c = eval(msg.d);
            for (var i in c) {
                $("#combobox1 option:last").after("<option value=" + c[i][0] + ">" + c[i] + "</option>");
            }
        }
    });
})

$(function () {
    $("#query_results").empty();
    $("#query_results").append('<select id="combobox2"><option value="">Select one..</option>');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Webservices/OlodService.asmx/GetOlods",
        dataType: "json",
        success: function (msg) {
            var c = eval(msg.d);
            for (var i in c) {
                console.log(c[i]);
                $("#combobox2 option:last").after("<option value=" + c[i].olod_id + ">" + c[i].naam + "</option>");
            }
        }
    });
}) 

$(function () {
    $("#query_results").empty();
    $("#query_results").append('<select id="combobox3"><option value="">Select one..</option>');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "../Webservices/DocentService.asmx/GetDocenten",
        dataType: "json",
        success: function(msg) {
            var c = eval(msg.d);
            for (var i in c) {
                console.log(c[i]);
                $("#combobox3 option:last").after("<option value=" + c[i].docent_id + ">" + c[i].naam+"</option>");
            }
        }
    });
}) 