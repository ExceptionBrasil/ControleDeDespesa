
/*
 * Adiciona evento na seleção de Tipos 
 */
$(document).ready(function () {
    let tipoDespesa = document.querySelector("#btnAdicionar");
    let Quantidade = document.querySelector("#Quantidade");
    let Valor = document.querySelector("#Valor");

    tipoDespesa.addEventListener("click", AdicionarItem);
    Quantidade.addEventListener("blur", function () {
        corrigeVirgula("Quantidade");
    }, true);
    Valor.addEventListener("blur", function () {
        corrigeVirgula("Valor");
    }, true);
        

});


function corrigeVirgula (id) {
    let v = document.querySelector("#" + id);
    let newValue = v.value.replace(",", ".");
    v.value = newValue;    
}


/*
 * Adiciona Itens na Tabela
 */
var AdicionarItem = function(event) {
    event.preventDefault();
    event.stopPropagation();


   

    var tipoDespesa = document.querySelector("#Tipo");
    var quantidade  = document.querySelector("#Quantidade");
    var valor       = document.querySelector("#Valor");
    var descricao   = document.querySelector("#Descritivo");    
    var itensDespesas = document.querySelector("#itensDespesas");   

    //Valida se h[a conteúdo mínimo na tela antes de seguir
    var retorno = ValidaNumeros(quantidade);
    if (!retorno.result) {  
        EscreveAvisoDeErro("Quantidade")

    }

    retorno = ValidaNumeros(valor);
    if (!retorno.result) {
        EscreveAvisoDeErro("Valor")

    }
    

    itensDespesas.innerHTML += geraStringHTML(tipoDespesa, quantidade, valor, descricao);
    somaItens();

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
            O conteúdo do campo <strong>`+ tag +` </strong> está inválido
            </div>`);
}

/*
 * Gera a string da tabela 
 */
var geraStringHTML = function(tipoDespesa, quantidade, valor, descricao) {

    var stringHTML = "";
    stringHTML += "<tr >";
    stringHTML += "<td>" + tipoDespesa.value + " - "+tipoDespesa[tipoDespesa.selectedIndex].text+ "</td>";
    stringHTML += "<td>" + quantidade.value + "</td>";
    stringHTML += "<td>" + valor.value + "</td>";
    stringHTML += "<td>" + quantidade.value * valor.value + "</td>";
    stringHTML += "<td>" + descricao.value + "</td>";
    stringHTML += "<td><a href='#'><span class='glyphicon glyphicon-edit'></span></a></td>";
    stringHTML += "<td><a href='#'><span class='glyphicon glyphicon-erase'></span></a></td>";
    stringHTML += "</tr>"

    return stringHTML;
}

/*
 * Realiza a soma dos itens da Tebela
 */
var somaItens = function () {
    var total = 0;
    var itensDespesas = document.querySelector("#itensDespesas");
    var trs = itensDespesas.getElementsByTagName('tr');

    for (var ix = 0; ix < trs.length; ix++) {
        var tds = trs[ix].getElementsByTagName('td');
        total += parseFloat(tds[3].innerHTML.replace(",","."));
    }

    ImprimeTotal(total);
}


var ImprimeTotal = function (valor) {
    var total = document.querySelector("#tbTotal");
    valor = valor.replace(",", ".");

    total.innerHTML = "<h4>Total: " + parseFloat(valor.toFixed(2)).toLocaleString()+"</h4>";
}



function Itens() {
    {
        this.Item = {
            TipoDespesaId: 0,
            TipoDespesaText:"",
            Quantidade: 0,
            Valor: 0,
            Descricao:""
        }
    }

}