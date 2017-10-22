/*
 * Data      >> 22/10/2017
 * Autor     >> DPS
 * Descrição >> Faz o envio das informções para o servidor 
 */



/*
 * Aguarda carregar o formulário por completo para adcionar os eventos aos componetes
 */
$(document).ready(function () {
    var btnSubmit = document.querySelector("#submitAprovadorCC");
    btnSubmit.addEventListener("click", EnviaDadosJson);
})




/**
 * Comunicação com o servidor 
 * @param {any} event
 */
var EnviaDadosJson = function (event) {

    event.preventDefault();
    event.stopPropagation();


    //Valida se poder fazer o envio de dados 
    if (ValidaFormulário()) {        
        WebServices();
    }



}


function WebServices() {

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
                window.location.replace(urlSuccess);
            } else {
                erroDeEnvio(response.error);
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