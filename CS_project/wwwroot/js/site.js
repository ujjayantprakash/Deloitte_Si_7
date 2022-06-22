// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$('#file-upload').click(function () {
//    $(".alert").delay(4000).slideUp(200, function () {
//        $(this).alert('close');
//    })
//});

//$(document).ready(function () {
//    $('#label-upload').click(function () {
//        $('#myalert').show('fade');


//        setTimeout(function () {
//            $('#myalert').hide('fade');
//        }, 6000);

//    });

//    $('#linkClose').click(function () {
//        $('#myalert').hide('fade');
//    });
//});

var pressedButton = document.getElementById('label-upload');
pressedButton.addEventListener("click", function (event) {
    alert("File uploaded successfully");
})

