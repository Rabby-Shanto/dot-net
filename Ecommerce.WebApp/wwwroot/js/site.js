// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#editModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var url = button.data('url'); // Get the URL from data-url attribute of the button

        // Make an AJAX request to load the edit view Razor page
        $.get(url).done(function (data) {
            $('#editModalContent').html(data); // Load the received data into the modal content container
        });
    });
});

