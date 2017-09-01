
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

    //Dados do Formulário
    let tipoDespesa = document.querySelector("#Tipo");
    let quantidade = document.querySelector("#Quantidade");
    let valor = document.querySelector("#Valor");
    let descricao = document.querySelector("#Descritivo");
    let itensDespesas = document.querySelector("#itensDespesas");

  
    //Valida se há conteúdo mínimo na tela antes de seguir
    let retorno = ValidaNumeros(quantidade);


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

    var Item2 = {
        IdDespesa: parseInt(tipoDespesa.value),
        DespesaDescricao : tipoDespesa[tipoDespesa.selectedIndex].text,
        Quantidade: parseFloat(quantidade.value),
        Valor: parseFloat(valor.value),       
        Observacao: descricao.value
    }

    //Adiciona o objeto no Array de transporte
    //Itens.push(Item);


    //itensDespesas.innerHTML += geraStringHTML(tipoDespesa, quantidade, valor, descricao);
    itensDespesas.innerHTML += geraStringHTML2(Item2);
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
 * Gera a string da tabela 
 */
var geraStringHTML2 = (I) => {

    var stringHTML = "";
    stringHTML += "<tr id='Item" +I.IdDespesa + "'>";
    stringHTML += "<td>" +I.IdDespesa + "</td>";
    stringHTML += "<td>" + I.DespesaDescricao + "</td > ";
    stringHTML += "<td>" + I.Quantidade + "</td>";
    stringHTML += "<td>" + I.Valor + "</td>";
    stringHTML += "<td>" + I.Quantidade * I.Valor + "</td>";
    stringHTML += "<td>" + I.Observacao + "</td>";
    stringHTML += "<td><a onclick='EditaItem(" + I.IdDespesa + ")'  href='#'><span class='glyphicon glyphicon-edit'></span></a></td>";
    stringHTML += "<td><a onclick='RemoveItem(" + I.IdDespesa + ")' href='#'><span class='glyphicon glyphicon-erase'></span></a></td>";
    stringHTML += "</tr>"

    return stringHTML;
}


/*
 * Remove um item da Grade 
 */
function RemoveItem(it) {
    let tr = document.querySelector("#Item" + it);
    tr.outerHTML = "";
}

/*
 * Edita o Item 
 */
function EditaItem(it) {
    let tr = document.querySelector("#Item" + it);
    let tds = tr.getElementsByTagName("td");

    $("#Tipo").val(tds[0].innerHTML);
    $("#Quantidade").val(tds[2].innerHTML);
    $("#Valor").val(tds[3].innerHTML);
    $("#Descritivo").val(tds[5].innerHTML);

    tr.outerHTML = "";

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