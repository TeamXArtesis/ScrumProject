var kleur = true;
var schema = new Array();
schema[0] = "maandag";
schema[1] = "10:00";
schema[2] = "12:00";
schema[3] = "3 TI";
schema[4] = "JAVA";
schema[5] = "CH0"
schema[6] = "Possemiers";


$(function () {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        /*data: "{ klasId: 1, week: 51, dag: 1 }",*/
        data: "{klasId:"+localStorage.getItem("klasid")+",week:"+localStorage.getItem("week")+",dag:"+localStorage.getItem("dag")+"}",
        url: "../Webservices/LesService.asmx/GetLesByKlasId",
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            var c = eval(msg.d);
            for (var i in c) {
                console.log(c[i]);
            }
        }
    });
});


document.write('<table style="background-color:#E6E6E6;width:100%;border-collapse:collapse;">')
document.write('<tr style="background-color:orange;color:white;">')
document.write('<th align="center" >Dag</th>')

document.write('<th align="center" ">Start</th>')

document.write('<th align="center" ">Einde</th>')

document.write('<th align="center" ">Klas</th>')

document.write('<th align="center" ">Olod</th>')

document.write('<th align="center" ">Lokaal</th>')

document.write('<th align="center" ">Docent</th></tr>')


for (var i = 0; i < 5; i++) {
    Afprinten();
};

function Afprinten() {
    var x;
    if (kleur == true) {
        document.write('<tr bgcolor="#E6E6E6">')
        kleur = false;

    } else {
        document.write('<tr bgcolor="white">')
        kleur = true;
    }

    for (x in schema) {

        document.write('<td ALIGN="center">' + schema[x] + '</td>')

    }
    document.write('</tr>')

}

document.write('</table>')