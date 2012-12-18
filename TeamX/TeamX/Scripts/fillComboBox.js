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
                $("#combobox option:last").after("<option value=" + c[i][0] + ">" + c[i][1] + "</option>");
            }
        }
    });
})
/*
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
                $("#combobox1 option:last").after("<option value=" + c[i][0] + ">" + c[i][5] + "</option>");
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
                $("#combobox2 option:last").after("<option value=" + c[i][0] + ">" + c[i][1] + "</option>");
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
                $("#combobox3 option:last").after("<option value=" + c[i][0] + ">" + c[i][1] + " " + c[i][2] + "</option>");
            }
        }
    });
}) */