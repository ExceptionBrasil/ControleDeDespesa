$(document).ready(function () {
    var tipoDespesa = document.querySelector("#Tipo");
    tipoDespesa.addEventListener("focus", GetLista);

});



function GetLista() {
    $.ajax({
        url: urlDest,
        sucess: function (data) {
            console.log(data);
        },
        error: function data() {
            console.log("erro");
        }
    });
}

