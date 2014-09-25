$(function () {
    $("#btntest").click(function () {
        showLoader();
    });

    $("div.movie_list>p").click(function () {
        $(this).toggleClass("opt_select");
    });

    hideLoader();
});

function showLoader() {
    $("#loader").fadeIn();
}

function hideLoader() {
    $("#loader").fadeOut();
}