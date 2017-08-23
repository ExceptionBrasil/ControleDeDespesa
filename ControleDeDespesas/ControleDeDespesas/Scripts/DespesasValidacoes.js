
var regExCamposValores = "/\d{5}[,]\d\d/";
var quantidade = document.querySelector("#Quantidade");
var valor = document.querySelector("#Valor");


quantidade.addEventListener("blur", validaNumerico(quantidade.value));


function validaNumerico(valor) {
   
    var re = new RegExp(regExCamposValores);
    if (re.test(valor)) {
        
    } else {
        console.log("Invalid");
    }
}