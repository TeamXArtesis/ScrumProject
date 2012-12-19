

function GetResultsByKlas(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "klas");
    localStorage.setItem("klasid", strUser);
    localStorage.setItem("week", (new Date()).getWeek());
    localStorage.setItem("dag", dag);
}

function GetResultsByOlod(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox2");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "olod");
    localStorage.setItem("olodid", strUser);
    localStorage.setItem("week",(new Date()).getWeek());
    localStorage.setItem("dag", dag);
}

function GetResultsByDocent(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox3");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "docent");
    localStorage.setItem("docentid", strUser);
    localStorage.setItem("week", (new Date()).getWeek());
    localStorage.setItem("dag", dag);
}

function GetResultsByLokaal(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox1");
    var strUser = e.options[e.selectedIndex].innerHTML;
    localStorage.setItem("type", "lokaal");
    localStorage.setItem("lokaal", strUser);
    localStorage.setItem("week", (new Date()).getWeek());
    localStorage.setItem("dag", dag);
}