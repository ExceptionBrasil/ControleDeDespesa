$(document).ready(function () {
    var BtnExclui = document.querySelector("#BtnExcluir");

    BtnExclui.addEventListener("click", function () {
        var codigoDespesa = document.querySelector("#codigoDespesa");

        $.ajax({
            url: urlDest,
            data: { codigoDespesa: codigoDespesa.innerHTML },
            dataType: "json",
            method: "POST",
            error: function (response) {
                console.log(response);
            },
            success: function (response) {
                if (response.success) {
                    window.location.replace(urlRedirect);
                } else {
                    console.log(response.menssage);
                }

            }
        });

    });
});


