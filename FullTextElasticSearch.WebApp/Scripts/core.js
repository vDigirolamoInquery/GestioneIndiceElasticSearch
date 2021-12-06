/*
    File javascriot che contiene tutte le funzioni utili per le richieste Ajax.   
*/

// Intervallo globale per la visualizzazione del loader dopo 250 millisecondi.
var global_interval;
var enabledShowLoader = true

$(document).ajaxStop(function () {
    enabledShowLoader = true;
    hideLoader();
    enableScrollTop();
    repositionElements();
});

$(document).ajaxStart(function () {
    showLoader();
    enableScrollTop();
});


$(document).ajaxError(function (jqxhr) {
    hideLoader();
    alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
    alert("responseText: " + xhr.responseText);
});

$.ajaxSetup({ cache: false });

$(document).ready(function () {

    $(window).on('beforeunload', function () {
        showLoader();
    });

    $(window).resize(function () {
        repositionElements();
    });

    repositionElements();

    $("[data-role='autocomplete-text']")

        .focusout(function () {

            if ($(this).attr("data-role-hide-list") == 'true')

                $("[data-role='autocomplete-content-list-items']").hide();
        })
        .focus(function () {

            $("[data-role='autocomplete-content-list-items']").fadeIn();

        });

    $("[data-role='autocomplete-text']").on("keyup", function (event) {

        if (event.keyCode === 27) $("[data-role='autocomplete-content-list-items']").hide();
    });

    $("[data-start='focus'").focus();

    $("[data-role='autocomplete-content-list-items']").on("mouseover", function () { hideAutocompleteListItem(false) });
    $("[data-role='autocomplete-content-list-items']").on("mouseout", function () { hideAutocompleteListItem(true) });

    $(window).scroll(function () {
        enableScrollTop();
    });

    enabledPressKeyDefaultButton();

    enableScrollTop();

    $(".scrollTop").click(function () {
        animateTop();
    });

    $("#documentDetailsContent").on('shown.bs.modal', function () {
        highLighter();
    });
});

function repositionElements()
{
    var windowHeight = $(window).height() - 75 - 65 - 150;
    
    $("[data-role='autocomplete-content-list-items']").css(
        {
            "width": $("[data-role='autocomplete']").innerWidth() + "px",
        });

    $("#btnSearch").css(
        {
            "position": "absolute",
            "top": "0",
            "left": ($("[data-role='autocomplete-text']").innerWidth() - ($("#btnSearch").width() / 2)) + "px",
        });

    $("[data-role='autocomplete-text']").css("paddingRight", $("#btnSearch").width() + "px");


    $(".document-details-view").css("maxHeight", windowHeight + "px")
}

function hideAutocompleteListItem(flag) {

    $("[data-role='autocomplete-text']").attr("data-role-hide-list", flag);
}

function enabledPressKeyDefaultButton() {

    $("[data-search-default-button]").on("keydown", function (event) {

        if (event.keyCode === 13) {

            var defaultButton = $("#" + $(this).attr("data-search-default-button"));

            $(defaultButton).trigger("click");
        }
    });
}

function enableScrollTop() {

    if ($(window).scrollTop() > 30) {
        $(".scrollTop").fadeIn();
    }
    else {
        $(".scrollTop").fadeOut();
    }
}

function animateTop() {

    $("html, body").animate({ scrollTop: 0 }, 500);
}

function showLoader()
{
    if (enabledShowLoader == true)
    {
        window.clearInterval(global_interval);
        global_interval = setInterval(function () { $("#pleaseWaitDialog").modal(); }, 250);
    }

}

function hideLoader()
{
    window.clearInterval(global_interval);

    $(".modal-backdrop").hide();
    $("#pleaseWaitDialog").modal("hide");
}
