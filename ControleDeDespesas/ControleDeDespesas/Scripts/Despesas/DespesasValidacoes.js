
/*
 * Adiciona evento na seleção de Tipos 
 */
$(document).ready(function () {
    let Quantidade = document.querySelector("#Quantidade");
    let Valor = document.querySelector("#Valor");

    Quantidade.addEventListener("blur", function () {
        corrigeVirgula("Quantidade");
    }, true);

    Quantidade.addEventListener("blur", function () {
        TiraNaN("Quantidade");
    }, true);


    Valor.addEventListener("blur", function () {
        corrigeVirgula("Valor");
    }, true);

    Valor.addEventListener("blur", function () {
        TiraNaN("Valor");
    }, true);


    let btnAdicionaItem = document.querySelector("#btnAdicionar");
    btnAdicionaItem.addEventListener("click", ValidaForm);

});

/**
 * Valida os dados do formulário antes adicionar a grade
 */
var ValidaNumeros = (v) => {

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

function TiraNaN(id) {
    let v = document.querySelector("#" + id);

    if (v.value == "NaN") {
        v.value = "0";
    } 

}

/**
 * Faz a troca do ponto por vírgula
 * @param {any} id
 */
function corrigeVirgula(id) {
    let v = document.querySelector("#" + id);
    let newValue = parseFloat(v.value.replace(",", "."));
    newValue = newValue.toFixed(2).toLocaleString().replace(".", ",");        
    v.value = newValue;
}

/**
 * Convert para Float uma string
 * @param {any} v
 */
function ToFloat(v) {    
    let newValue = parseFloat(v.replace(",", "."));
    newValue = newValue.toFixed(2);
    return parseFloat(newValue);
}

/**
 * Convert para string um float 
 * @param {any} v
 */
function ToString(v) {
    let stringValue = v.toFixed(2);
    stringValue = stringValue.toString();
    return stringValue;
}


function ValidaForm() {
    //Validar se pode ou não adcionar itens na grade
    //Pode adicionar quantidade zero?
    //Pode adicinar valor zero?

}