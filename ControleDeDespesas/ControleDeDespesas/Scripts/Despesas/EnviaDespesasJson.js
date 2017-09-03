﻿
$(document).ready(function () {
    var btnEnviar = document.querySelector("#enviaDespesas");
    btnEnviar.addEventListener("click", EnviaDados);
});


var EnviaDados = function () {
    var Dados = { "despesasJson": PrepareEnv() }


    if (Dados.despesasJson.length <= 0) {
        erroDeEnvio("Não Há Dados para Enviar");
        return
    }


    $.ajax({
        url: urlDespesasIncluir,
        data:Dados,
        dataType: "json",
        method: "POST",
        error: function (response) {
            console.log(response);
        },
        success: function (response) {
            console.log(response);
        }
    });
}




//Prepara dados para serem enviados

function PrepareEnv() {
    let tBody = $("#itensDespesas");
    let Trs = tBody[0].getElementsByTagName("tr");
    let Itens = new Array();

    for (var item = 0; item < Trs.length; item++) {
        var Json = new Object();

        Json.IdDespesa          = parseInt(Trs[item].cells[0].innerHTML);
        Json.DespesaDescricao   = Trs[item].cells[1].innerHTML;
        Json.Quantidade         = (Trs[item].cells[2].innerHTML);
        Json.Valor              = (Trs[item].cells[3].innerHTML);
        Json.Observacao         = Trs[item].cells[5].innerHTML;
        
        Itens.push(Json);
    }
    return Itens;
}


