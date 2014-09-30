$(function () {
    $("#btntest").click(function (event) {
        showLoader();
    });

    $("div.movie_list>p>.add").click(function (event) {
        if ($(this).parent().hasClass("opt_ignore")) {
            $(this).parent().removeClass("opt_ignore");
        }

        $(this).parent().toggleClass("opt_select");
    });

    $("div.movie_list>p>.ignore").click(function (event) {
        if ($(this).parent().hasClass("opt_select")) {
            $(this).parent().removeClass("opt_select");
        }

        $(this).parent().toggleClass("opt_ignore");
    });

    $("div.movie_list>p>.info").click(function (event) {
        alert("info");
    });

    $("div.movie_list>p>.info").hover(function (event) {
        $(this).toggleClass("info_hover");
    }, function (event) {
        $(this).toggleClass("info_hover");
    });

    hideLoader();
});

function showLoader() {
    $("#loader").fadeIn();
}

function hideLoader() {
    $("#loader").fadeOut();
}