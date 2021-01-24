// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#myModal .modal-body').html(res);
            $('#myModal .modal-title').html(title);
            $('#myModal').modal('show');
        }
    })
}