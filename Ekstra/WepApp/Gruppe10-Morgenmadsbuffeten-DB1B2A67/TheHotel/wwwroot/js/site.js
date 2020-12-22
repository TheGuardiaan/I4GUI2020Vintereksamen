// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Delete Confirm for index
$(function () {
    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
        
    }

});

//fadeOut notification 
$(function () {
    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut(4000);
        })
    }

});