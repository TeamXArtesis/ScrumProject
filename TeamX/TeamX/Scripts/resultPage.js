var kleur = true;
var schema = new Array();

//alert("{klasId:" + localStorage.getItem("klasid") + ",week:" + localStorage.getItem("week") + ",dag:" + localStorage.getItem("dag") + "}");


$(function () {
    if (localStorage.getItem("type") == "klas") {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: "{klasId:" + localStorage.getItem("klasid") + ",week:" + localStorage.getItem("week") + ",dag:" + localStorage.getItem("dag") + "}",
            url: "../Webservices/LesService.asmx/GetLesByKlasId",
            dataType: "json",
            success: function (msg) {
                console.log(msg);
                var c = eval(msg.d);
                for (var i in c) {
                    schema = new Array();

                    switch(c[i].dag)
                    {
                        case 1:
                            schema[0] = "maandag";
                            break;
                        case 2:
                            schema[0] = "dinsdag";
                            break;
                        case 3:
                            schema[0] = "woensdag";
                            break;
                        case 4:
                            schema[0] = "donderdag";
                            break;
                        case 5:
                            schema[0] = "vrijdag";
                            break;
                        default:
                            schema[0] = "undefined";
                    }
                    //tijd
                    c[i].tijd = (c[i].tijd.split(":"));
                    schema[1] = c[i].tijd[0] + ":" + c[i].tijd[1];
                    c[i].tijd[0] = parseInt(c[i].tijd[0]) + Math.floor((c[i].duur_in_minuten + parseInt(c[i].tijd[1])) / 60);
                    c[i].tijd[1] = (c[i].duur_in_minuten + parseInt(c[i].tijd[1])) % 60;
                    schema[2] = (c[i].tijd[0] < 10 ? "0" : "") + c[i].tijd[0] + ":" + (c[i].tijd[1] < 10 ? "0" : "") + c[i].tijd[1];

                    //klassen
                    schema[3] = "";
                    for (var klas in c[i].klassen) {
                        schema[3] += "<div>" + c[i].klassen[klas].afkorting + "</div>";
                    }

                    schema[4] = c[i].naam;
                    schema[5] = c[i].lokaal;

                    //docenten
                    schema[6] = "";
                    for (var docent in c[i].docenten) {
                        schema[6] += "<div>" + c[i].docenten[docent].naam + "</div>";
                    }
                    Afprinten();
                }
            },
            fail: function (a, b) {
                console.log(a);
            }
        });
    }
    else if (localStorage.getItem("type") == "lokaal") {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: "{lokaal:\"" + localStorage.getItem("lokaal") + "\",week:" + localStorage.getItem("week") + ",dag:" + localStorage.getItem("dag") + "}",
            url: "../Webservices/LesService.asmx/getlesbylokaal",
            dataType: "json",
            success: function (msg) {
                var c = eval(msg.d);
                for (var i in c) {
                    schema = new Array();

                    switch (c[i].dag) {
                        case 1:
                            schema[0] = "maandag";
                            break;
                        case 2:
                            schema[0] = "dinsdag";
                            break;
                        case 3:
                            schema[0] = "woensdag";
                            break;
                        case 4:
                            schema[0] = "donderdag";
                            break;
                        case 5:
                            schema[0] = "vrijdag";
                            break;
                        default:
                            schema[0] = "undefined";
                    }
                    //tijd
                    c[i].tijd = (c[i].tijd.split(":"));
                    schema[1] = c[i].tijd[0] + ":" + c[i].tijd[1];
                    c[i].tijd[0] = parseInt(c[i].tijd[0]) + Math.floor((c[i].duur_in_minuten + parseInt(c[i].tijd[1])) / 60);
                    c[i].tijd[1] = (c[i].duur_in_minuten + parseInt(c[i].tijd[1])) % 60;
                    schema[2] = (c[i].tijd[0] < 10 ? "0" : "") + c[i].tijd[0] + ":" + (c[i].tijd[1] < 10 ? "0" : "") + c[i].tijd[1];

                    schema[3] = c[i].klasnaam;
                    schema[4] = c[i].naam;
                    schema[5] = localStorage.getItem("lokaal");
                    schema[6] = "Possemiers";
                    Afprinten();
                }
            },
            error: function (a, b) {
                console.log(a);
            }
        });
    }
    else if (localStorage.getItem("type") == "olod") {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: "{olodid:" + localStorage.getItem("olodid") + ",week:" + localStorage.getItem("week") + ",dag:" + localStorage.getItem("dag") + "}",
            url: "../Webservices/LesService.asmx/GetLesByOlodId",
            dataType: "json",
            success: function (msg) {
                var c = eval(msg.d);
                for (var i in c) {
                    schema = new Array();

                    switch (c[i].dag) {
                        case 1:
                            schema[0] = "maandag";
                            break;
                        case 2:
                            schema[0] = "dinsdag";
                            break;
                        case 3:
                            schema[0] = "woensdag";
                            break;
                        case 4:
                            schema[0] = "donderdag";
                            break;
                        case 5:
                            schema[0] = "vrijdag";
                            break;
                        default:
                            schema[0] = "undefined";
                    }
                    //tijd
                    c[i].tijd = (c[i].tijd.split(":"));
                    schema[1] = c[i].tijd[0] + ":" + c[i].tijd[1];
                    c[i].tijd[0] = parseInt(c[i].tijd[0]) + Math.floor((c[i].duur_in_minuten + parseInt(c[i].tijd[1])) / 60);
                    c[i].tijd[1] = (c[i].duur_in_minuten + parseInt(c[i].tijd[1])) % 60;
                    schema[2] = (c[i].tijd[0] < 10 ? "0" : "") + c[i].tijd[0] + ":" + (c[i].tijd[1] < 10 ? "0" : "") + c[i].tijd[1];

                    schema[3] = c[i].klasnaam;
                    schema[4] = c[i].naam;
                    schema[5] = localStorage.getItem("lokaal");
                    schema[6] = "Possemiers";
                    Afprinten();
                }
            },
            error: function (a, b) {
                console.log(a);
            }
        });
    }
    else if (localStorage.getItem("type") == "docent") {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: "{docentId:" + localStorage.getItem("docentid") + ",week:" + localStorage.getItem("week") + ",dag:" + localStorage.getItem("dag") + "}",
            url: "../Webservices/LesService.asmx/GetLesByDocentId",
            dataType: "json",
            success: function (msg) {
                var c = eval(msg.d);
                for (var i in c) {
                    schema = new Array();

                    switch (c[i].dag) {
                        case 1:
                            schema[0] = "maandag";
                            break;
                        case 2:
                            schema[0] = "dinsdag";
                            break;
                        case 3:
                            schema[0] = "woensdag";
                            break;
                        case 4:
                            schema[0] = "donderdag";
                            break;
                        case 5:
                            schema[0] = "vrijdag";
                            break;
                        default:
                            schema[0] = "undefined";
                    }
                    //tijd
                    c[i].tijd = (c[i].tijd.split(":"));
                    schema[1] = c[i].tijd[0] + ":" + c[i].tijd[1];
                    c[i].tijd[0] = parseInt(c[i].tijd[0]) + Math.floor((c[i].duur_in_minuten + parseInt(c[i].tijd[1])) / 60);
                    c[i].tijd[1] = (c[i].duur_in_minuten + parseInt(c[i].tijd[1])) % 60;
                    schema[2] = (c[i].tijd[0] < 10 ? "0" : "") + c[i].tijd[0] + ":" + (c[i].tijd[1] < 10 ? "0" : "") + c[i].tijd[1];

                    schema[3] = c[i].klasnaam;
                    schema[4] = c[i].naam;
                    schema[5] = localStorage.getItem("lokaal");
                    schema[6] = "Possemiers";
                    Afprinten();
                }
            },
            error: function (a, b) {
                console.log(a);
            }
        });
    }
});

function Afprinten() {
    var html = "";
    var x;
    if (kleur == true) {
        html += '<tr bgcolor="#E6E6E6">';
        kleur = false;

    } else {
        html += '<tr bgcolor="white">';
        kleur = true;
    }

    for (x in schema) {

        html += '<td ALIGN="center">' + schema[x] + '</td>';

    }
    html += "</tr>";
    $("#overzicht").append(html);

}