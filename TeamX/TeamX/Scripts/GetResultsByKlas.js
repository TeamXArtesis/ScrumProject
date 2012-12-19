function GetResultsByKlas(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "klas");
    localStorage.setItem("klasid", strUser);
    localStorage.setItem("week", 51);
    localStorage.setItem("dag", dag);
}