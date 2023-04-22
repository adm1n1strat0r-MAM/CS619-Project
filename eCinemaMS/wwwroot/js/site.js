// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#Pshow").click(function () {
        $("#Pshow").hide();
        $("#Phide").show();
        $("#password").attr("type", "Text");
    });
    $("#Phide").click(function () {
        $("#Phide").hide();
        $("#Pshow").show();
        $("#password").attr("type", "password");
    });
});

$(document).ready(function () {
    var output = document.getElementById('profilePicturePreview');
    output.src = $("#profilePictureUrl").val();
})

$("#profilePictureUrl").on("change", function () {
    var output = document.getElementById('profilePicturePreview');
    output.src = $(this).val();
});

$(document).ready(function () {
    var output = document.getElementById('PicturePreview');
    output.src = $("#Logo").val();
})

$("#Logo").on("change", function () {
    var output = document.getElementById('PicturePreview');
    output.src = $(this).val();
});

$("#ImageURL").on("change", function () {
    var output = document.getElementById("ImagePreview");
    output.src = $(this).val();
});

$(document).ready(function () {
    var output = document.getElementById('ImagePreview');
    output.src = $("#ImageURL").val();
});

$(document).ready(function () {
    var output = document.getElementById('PreviewImageUrl');
    output.src = $("input[name='movie.ImageUrl']").val();
});

$("input[name='movie.ImageUrl']").on("change", function () {
    var output = document.getElementById('PreviewImageUrl');
    output.src = $(this).val();
});

function calculateSubtotal() {
    const price = parseInt(document.getElementById("cost").value);
    const qty = parseInt(document.getElementById("qty").value);
    if (qty < 0) {
        document.getElementById("qty").value = 0;
    } else if (qty > 10) {
        document.getElementById("qty").value = 10;
    }else
    {
        const subtotal = price * qty;
        document.getElementById("subtotal").value = subtotal+".00";
    }
}

document.getElementById("qty").addEventListener("input", calculateSubtotal);