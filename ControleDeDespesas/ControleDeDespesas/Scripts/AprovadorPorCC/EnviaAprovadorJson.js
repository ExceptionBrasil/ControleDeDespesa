
/*
 * Aguarda carregar o formulário por completo para adcionar os eventos aos componetes
 */
$(document).ready(function () {
    var btnSubmit = document.querySelector("#submitAprovadorCC");
    btnSubmit.addEventListener("click", EnviaDadosJson);
})


var EnviaDadosJson = function (event) {
    event.preventDefault();
    event.stopPropagation();

    var dados = { "aprovador": PreparaJson() }

    $.ajax({
        url: urldest,
        data: dados,
        dataType: "json",
        method: "POST",
        error: function (response) {
            console.log(response);
        },
        success: function (response) {
            if (response.success) {
                window.location.replace("/AprovadorPorCC/Index");
            } else {
                erroDeEnvio(response.menssage);
            }

        }
    });
}

/*
 * Prepara o Json para envio dos Dados 
 */
var PreparaJson = function () {

    var cc = document.querySelector("#CC");
    var usuario = document.querySelector("#Usuario");
    var superior = document.querySelector("#Superior");
    var limite = document.querySelector("#Limite");
    var id = document.querySelector("#Id");

    var Json = new Object();
    
    Json.CC = parseInt(cc.value);
    Json.Usuario = parseInt(usuario.value);
    Json.Superior = parseInt(superior.value);
    Json.Id = parseInt(id.value);
    Json.Limite = parseFloat(limite.value);    
     
    return Json;

}