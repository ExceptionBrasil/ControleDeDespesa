
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

function ToFloat(v) {    
    let newValue = parseFloat(v.replace(",", "."));
    newValue = newValue.toFixed(2);
    return parseFloat(newValue);
}

function ToString(v) {
    let stringValue = v.toFixed(2);
    stringValue = stringValue.toString();
    return stringValue;
}