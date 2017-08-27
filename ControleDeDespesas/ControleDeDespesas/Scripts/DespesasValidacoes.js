

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