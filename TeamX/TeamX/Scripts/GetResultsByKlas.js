

function GetResultsByKlas(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "klas");
    localStorage.setItem("klasid", strUser);
    localStorage.setItem("week", getWeekNumber());
    localStorage.setItem("dag", dag == 6 ? -1 : dag);
}

function GetResultsByOlod(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox2");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "olod");
    localStorage.setItem("olodid", strUser);
    localStorage.setItem("week", getWeekNumber());
    localStorage.setItem("dag", dag == 6 ? -1 : dag);
}

function GetResultsByDocent(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox3");
    var strUser = e.options[e.selectedIndex].value;
    localStorage.setItem("type", "docent");
    localStorage.setItem("docentid", strUser);
    localStorage.setItem("week", getWeekNumber());
    localStorage.setItem("dag", dag == 6 ? -1 : dag);
}

function GetResultsByLokaal(dag) {
    $("#query_results").empty();
    var e = document.getElementById("combobox1");
    var strUser = e.options[e.selectedIndex].innerHTML;
    localStorage.setItem("type", "lokaal");
    localStorage.setItem("lokaal", strUser);
    localStorage.setItem("week", getWeekNumber());
    localStorage.setItem("dag", dag == 6 ? -1 : dag);
}

function getWeekNumber() {
    // Copy date so don't modify original
    d = new Date();
    d.setHours(0, 0, 0);
    // Set to nearest Thursday: current date + 4 - current day number
    // Make Sunday's day number 7
    d.setDate(d.getDate() + 4 - (d.getDay() || 7));
    // Get first day of year
    var yearStart = new Date(d.getFullYear(), 0, 1);
    // Calculate full weeks to nearest Thursday
    var weekNo = Math.ceil((((d - yearStart) / 86400000) + 1) / 7)
    // Return array of year and week number
    return weekNo;
}