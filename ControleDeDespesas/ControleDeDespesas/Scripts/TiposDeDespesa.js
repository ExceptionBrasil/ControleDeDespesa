
/*
 * Adiciona evento na seleção de Tipos 
 */
$(document).ready(function () {
    var tipoDespesa = document.querySelector("#btnAdicionar");
    tipoDespesa.addEventListener("click", AdicionarItem);

});



function AdicionarItem(event) {
    event.preventDefault();
    event.stopPropagation();

    var tipoDespesa = document.querySelector("#Tipo");
    var quantidade  = document.querySelector("#Quantidade");
    var valor       = document.querySelector("#Valor");
    var descricao = document.querySelector("#Descritivo");    

    var itensDespesas = document.querySelector("#itensDespesas");   
    itensDespesas.innerHTML += geraStringHTML(tipoDespesa, quantidade, valor, descricao);
    somaItens();

}

function geraStringHTML(tipoDespesa, quantidade, valor, descricao) {

    var stringHTML = "";
    stringHTML += "<tr>";
    stringHTML += "<td>" + tipoDespesa.value + tipoDespesa.tex+ "</td>";
    stringHTML += "<td>" + quantidade.value + "</td>";
    stringHTML += "<td>" + valor.value + "</td>";
    stringHTML += "<td>" + quantidade.value * valor.value + "</td>";
    stringHTML += "<td>" + descricao.value + "</td>";
    stringHTML += "<td><a href='#'><span class='glyphicon glyphicon-edit'></span></a></td>";
    stringHTML += "<td><a href='#'><span class='glyphicon glyphicon-erase'></span></a></td>";
    stringHTML += "</tr>"

    return stringHTML;
}

function somaItens() {
    var total = 0;
    var itensDespesas = document.querySelector("#itensDespesas");
    var trs = itensDespesas.getElementsByTagName('tr');

    trs.forEach(function (tr) {
        var tds = tr.getElementsByTagName('td');
        total += parseFloat(tds[3].innerHTML);       

    });

    console.log(total);
}