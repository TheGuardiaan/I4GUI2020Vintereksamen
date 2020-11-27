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
    const toggleArr = [/*["tag", "white", "dark"]*/
        //Icon-toggle
        ["i", "fa-toggle-off", "fa-toggle-on"],
        //Icon-moon-opacity
        ["i", "fa-toggle-off", "fa-toggle-on"],
        //Icon-moon
        ["i", "lightmode-sun-icon", "darkmode-sun-icon"],
        //Body_bg
        ["i", "lightmode-moon-icon", "darkmode-moon-icon"],
        //Header_bg
        ["body", "lightmode-body", "darkmode-body"],
        //Header - text
        ["nav", "lightmode-header", "darkmode-header"],
        //Text - menues
        ["a", "text-dark", "text-light"],
        //Text - logout
        ["button", "text-dark", "text-light"],
        //footer-bg
        ["footer", "lightmode-footer", "darkmode-footer"],
        //Dropdown background
        ["div", "bg-light", "bg-dark"],
        //Span window 
        ["span", "text-dark", "text-light"]

        
    ];

    if (localStorage.hasOwnProperty("modeview")) {
        if (localStorage["modeview"] == "toggle-darkmode") {////----------DarkMode------------------
            for (let i = 0; i < toggleArr.length; i++) {
                toggleClass(toggleArr[i][0], toggleArr[i][1], toggleArr[i][2]);
            }
            toggleSrc("logo","/img/logo/aulogo_white.png");
        } else if (localStorage["modeview"] == "toggle-lightmode") {////----------LightMode------------------
            for (let i = 0; i < toggleArr.length; i++) {
                toggleClass(toggleArr[i][0], toggleArr[i][2], toggleArr[i][1]);
            }
            toggleSrc("logo","/img/logo/aulogo_blue.png");
        }
    } else {
        localStorage["modeview"] = "toggle-lightmode";
        for (let i = 0; i < toggleArr.length; i++) {////----------LightMode------------------
            toggleClass(toggleArr[i][0], toggleArr[i][2], toggleArr[i][1]);
        }
        toggleSrc("logo","/img/logo/aulogo_blue.png");

    }
}


function toggleClass(e, cF, cT) {
    let textWhite = $(e + "." + cF);
    textWhite.removeClass(cF).addClass(cT);
}







function toggleSrc(id, cF) {

    let element = document.getElementById(id).setAttribute("src", cF);
}


