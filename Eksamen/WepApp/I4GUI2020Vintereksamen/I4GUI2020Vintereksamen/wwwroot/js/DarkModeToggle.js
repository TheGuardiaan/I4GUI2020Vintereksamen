// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    toggleMode();
});


function toggleModeFunction() {

    if (localStorage["modeview"] == "toggle-darkmode") {
        localStorage["modeview"] = "toggle-lightmode";
    } else {
        localStorage["modeview"] = "toggle-darkmode";
    }

    toggleMode();
}




function toggleMode() {
    if (localStorage.hasOwnProperty("modeview")) {
        if (localStorage["modeview"] == "toggle-darkmode") {
            darkMode();
        } else if (localStorage["modeview"] == "toggle-lightmode") {
            lightMode();
        }
    } else {
        localStorage["modeview"] = "toggle-lightmode";
        lightMode();
    }


}




//----------DarkMode------------------
function darkMode() {

    //Icon-toggle
    toggleClass("i", "fa-toggle-off", "fa-toggle-on");

    //Icon-moon-opacity
    toggleClass("i", "lightmode-sun-icon", "darkmode-sun-icon");
    //Icon-moon
    toggleClass("i", "lightmode-moon-icon", "darkmode-moon-icon")

    //Body_bg
    toggleClass("body", "lightmode-body", "darkmode-body");

    //Header_bg
    toggleClass("nav", "lightmode-header", "darkmode-header");

    //Header - text
    toggleClass("a", "text-dark", "text-light");

    //Text Logout
    toggleClass("button", "text-dark", "text-light");

    //footer-bg
    toggleClass("footer", "lightmode-footer", "darkmode-footer");


}


//----------LightMode------------------
function lightMode() {

    //Icon-toogle
    toggleClass("i", "fa-toggle-on", "fa-toggle-off");

    //Icon-sun-opacity
    toggleClass("i", "darkmode-sun-icon", "lightmode-sun-icon");
    //Icon-sun
    toggleClass("i", "darkmode-moon-icon", "lightmode-moon-icon")

    //Body_bg
    toggleClass("body", "darkmode-body", "lightmode-body");

    //Header_bg
    toggleClass("nav", "darkmode-header", "lightmode-header");

    //Header - text
    toggleClass("a", "text-light", "text-dark");

    //Text Logout
    toggleClass("button", "text-light", "text-dark");

    //footer-bg
    toggleClass("footer", "darkmode-footer", "lightmode-footer");


}



function toggleClass(e, cF, cT) {
    var textWhite = $(e+"."+cF);
    textWhite.removeClass(cF).addClass(cT);
}