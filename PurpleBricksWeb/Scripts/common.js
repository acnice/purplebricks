function ShowLoader(message) {
    $("#dvLoader").find("#loadingMessage")[0].innerHTML = message;
    $("#dvOverlay").not('#dvLoader').addClass("overlay");
    $("#dvOverlay").css("display", "block");
}

function HideLoader() {
    $("#dvLoader").find("#loadingMessage")[0].innerHTML = "Loading";
    $("#dvOverlay").css("display", "none");
    $("dvOverlay").removeClass("overlay");
}
