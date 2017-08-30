
//Array do itens adicionados em tela
var Itens = new Array();


/*
 * Adiciona evento na seleção de Tipos 
 */
$(document).ready(function () {
    let btnAdicionaItem= document.querySelector("#btnAdicionar");
    btnAdicionaItem.addEventListener("click", AdicionarItem);
    
});




/**
 * Adiciona Itens na Tabela
 * @param {any} event
 */
var AdicionarItem = function(event) {
    event.preventDefault();
    event.stopPropagation();


    var tipoDespesa = document.querySelector("#Tipo");
    var quantidade = document.querySelector("#Quantidade");
    var valor = document.querySelector("#Valor");
    var descricao = document.querySelector("#Descritivo");
    var itensDespesas = document.querySelector("#itensDespesas");

  
    //Valida se há conteúdo mínimo na tela antes de seguir
    var retorno = ValidaNumeros(quantidade);


    if (!retorno.result) {  
        EscreveAvisoDeErro("Quantidade")

    }

    retorno = ValidaNumeros(valor);
    if (!retorno.result) {
        EscreveAvisoDeErro("Valor")

    }

    //Cria um objeto Item 
    var Item = {
        tipoDespesa: tipoDespesa.value,
        tipoDespesaDescricao : tipoDespesa[tipoDespesa.selectedIndex].text,
        quantidade: parseFloat(quantidade.value),
        valor: parseFloat(valor.value),       
        descricao: descricao.value
    }

    Itens.push(Item);


    itensDespesas.innerHTML += geraStringHTML(tipoDespesa, quantidade, valor, descricao);
    somaItens();
    ZeraItens();

}



function EditaArray(posicao) {

    var tipoDespesa = document.querySelector("#Tipo");
    var quantidade = document.querySelector("#Quantidade");
    var valor = document.querySelector("#Valor");
    var descricao = document.querySelector("#Descritivo");
    var itensDespesas = document.querySelector("#itensDespesas");

    var indexJson = posicao - 1;

    tipoDespesa.value = Itens[indexJson].tipoDespesa;
    quantidade.value = Itens[indexJson].quantidade;
    valor.value = Itens[indexJson].valor;
    descricao.value = Itens[indexJson].descricao;    

    SubtraiArray(posicao)

}



/**
 * Remove um item da Lista
 * @param {any} posicao
 */
function SubtraiArray(posicao) {
    var trItemSelecionado = document.querySelector("#Item" + posicao);

    Itens = Itens.filter(function (it) {
        var tdDespesa = document.querySelector("#TipoDespesa" + posicao);
        return it.tipoDespesa !== tdDespesa.textContent;
    })

    trItemSelecionado.innerHTML = "";

}


/*
 * Gera a string da tabela 
 */
var geraStringHTML = function(tipoDespesa, quantidade, valor, descricao) {

    var stringHTML = "";
    stringHTML += "<tr id='Item" + Itens.length + "'>";
    stringHTML += "<td id='TipoDespesa" + Itens.length + "' >" + tipoDespesa.value +"</td>";
    stringHTML += "<td>" + tipoDespesa[tipoDespesa.selectedIndex].text + "</td > ";
    stringHTML += "<td>" + quantidade.value + "</td>";
    stringHTML += "<td>" + valor.value + "</td>";
    stringHTML += "<td>" + quantidade.value * valor.value + "</td>";
    stringHTML += "<td>" + descricao.value + "</td>";
    stringHTML += "<td><a onclick='EditaArray(" + Itens.length +")'  href='#'><span class='glyphicon glyphicon-edit'></span></a></td>";
    stringHTML += "<td><a onclick='SubtraiArray(" + Itens.length +")' href='#'><span class='glyphicon glyphicon-erase'></span></a></td>";
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

/**
 * Imprime o total em tela
 * @param {any} valor
 */
var ImprimeTotal = function (valor) {
    var total = document.querySelector("#tbTotal");
    total.innerHTML = "<h4>Total: " + parseFloat(valor.toFixed(2)).toLocaleString()+"</h4>";
}



function ZeraItens() {
    var tipoDespesa = document.querySelector("#Tipo");
    var quantidade = document.querySelector("#Quantidade");
    var valor = document.querySelector("#Valor");
    var descricao = document.querySelector("#Descritivo");
    var itensDespesas = document.querySelector("#itensDespesas");


    tipoDespesa.value = "";
    quantidade.value = 0;
    valor.value = 0;
    descricao.value = "";   
    descricao.placeholder = "Insira uma informação relevante aqui..."
}