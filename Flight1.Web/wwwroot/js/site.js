// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    "use strict";
    // ============================================================== 
    //Tooltip
    // ============================================================== 
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
    // ============================================================== 
    //Popover
    // ============================================================== 
    $(function () {
        $('[data-toggle="popover"]').popover()
    })

    // ============================================================== 
    // Resize all elements
    // ============================================================== 
    $("body").trigger("resize");

});

$(function () { "use strict"; $(function () { $('[data-toggle="tooltip"]').tooltip() }), $(function () { $('[data-toggle="popover"]').popover() }), $("body").trigger("resize") });
