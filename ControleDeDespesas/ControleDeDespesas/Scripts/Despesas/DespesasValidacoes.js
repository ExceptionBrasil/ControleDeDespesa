
/*
 * Adiciona evento na seleção de Tipos 
 */
$(document).ready(function () {
    let Quantidade = document.querySelector("#Quantidade");
    let Valor = document.querySelector("#Valor");

    Quantidade.addEventListener("blur", function () {
        corrigeVirgula("Quantidade");
    }, true);


    Valor.addEventListener("blur", function () {
        corrigeVirgula("Valor");
    }, true);


});

/**
 * Valida os dados do formulário antes adicionar a grade
 */
var ValidaNumeros = function (v) {

    if (v.value == "") {
        return {
            result: false,
            text: v.name
        };
    }
    else {
        return {
            result: true,
            text: v.name
        };
    }

    if (parseFloat(v.value) == NaN) {
        return {
            result: false,
            text: v.name
        };
    }
    else {
        return {
            result: true,
            text: v.name
        };
    
    }
    

}

/**
 * Mesagem de conteúdo inválido
 * @param {any} tag
 */
var EscreveAvisoDeErro = function (tag) {
    $("#" + tag).after(
        `<div class="alert alert-warning alert-dismissible fade in" role="alert" id="AlertaDeCampo">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            <strong>Conteúdo Inválido!</strong>
            O conteúdo do campo <strong>`+ tag + ` </strong> está inválido
            </div>`);
}

/**
 * Faz a troca da vírgula pelo ponto
 * @param {any} id
 */
function corrigeVirgula(id) {
    let v = document.querySelector("#" + id);
    let newValue = v.value.replace(",", ".");
    v.value = newValue;
}