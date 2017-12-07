
//Array do itens adicionados em tela
var Itens = new Array();


/*
 * Adiciona evento na seleção de Tipos
 */
$(document).ready(function () {
    let btnAdicionaItem= document.querySelector("#btnAdicionar");
    btnAdicionaItem.addEventListener("click", AdicionarItem);

});




/*
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
        EscreveAvisoDeErro("Quantidade");

    }

    retorno = ValidaNumeros(valor);
    if (!retorno.result) {
        EscreveAvisoDeErro("Valor");

    }


    var Item2 = {
        IdDespesa: parseInt(tipoDespesa.value),
        DespesaDescricao : tipoDespesa[tipoDespesa.selectedIndex].text,
        Quantidade: quantidade.value,
        Valor: valor.value,
        Observacao: descricao.value,
        Total : ToFloat(quantidade.value) * ToFloat(valor.value)
    }


    itensDespesas.innerHTML += geraStringHTML(Item2);
    somaItens();
    document.getElementById("frm-despesas").reset();
    tipoDespesa.focus();

}





/*
 * Remove um item da Grade
 */
 var RemoveItem = (it)=> {
    let tr = document.querySelector("#Item" + it);
    tr.outerHTML = "";
}

/*
 * Edita o Item
 */
 var EditaItem = (it)=> {

    //Obtem o Tr "clicado"
    let tr = document.querySelector("#Item" + it);
    let tds = tr.getElementsByTagName("td");

    //Seta os valores no Form novamente
    $("#Tipo").val(tds[0].innerHTML);
    $("#Quantidade").val(tds[2].innerHTML);
    $("#Valor").val(tds[3].innerHTML);
    $("#Descritivo").val(tds[5].innerHTML);

    //Remove o Tr
    tr.outerHTML = "";

}


/*
 * Realiza a soma dos itens da Tebela
 */
 var somaItens = () =>{
    var total = 0;
    var itensDespesas = document.querySelector("#itensDespesas");
    var trs = itensDespesas.getElementsByTagName('tr');

    for (var ix = 0; ix < trs.length; ix++) {
        var tds = trs[ix].getElementsByTagName('td');
        total += parseFloat(tds[3].innerHTML.replace(",","."));
    }

    ImprimeTotal(total);
}
