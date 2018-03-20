
$(document).ready(function () {
    var btnEnviar = document.querySelector("#enviaDespesas");
    btnEnviar.addEventListener("click", EnviaDados);
});


///
/// sumary
/// Faz o envio dos dados ao servidor 
///
var EnviaDados = function () {


    //Faz o envio dos arquivos e caso de tudo certinho
    //envia a despesa    
    var Attachment = GetFiles("Attachment");


    //Valida o tamanho do Arquivo
    //Não envia arquivos maiores que 4mb
    if (GetSize(Attachment) > 4) {
        return alert("A soma dos tamanhos dos arquivos ultrapassa os 4mb");
    }

    //Cria o FormData
    let formData = PrepareFormData(Attachment);

    //Faz o envio do FormData e retorna o status HTTP
    SendAttchment(formData).then((retorno)=> {


        //Faz o envio da Despesa
        //Prepara o Json para envido no servidor 
        var Dados = { "despesasJson": PrepareEnv() }


        if (Dados.despesasJson.length <= 0) {
            erroDeEnvio("Não Há Dados para Enviar");
            return
        }

        $.ajax({
            url: urlDespesasIncluir,
            data: Dados,
            dataType: "json",
            method: "POST",
            error: function (response) {
                console.log(response);
            },
            success: function (response) {
                if (response.success) {
                    window.location.replace("/Despesas");
                } else {
                    erroDeEnvio(response.menssage);
                }

            }
        });
    }
    ).catch((data) => console.log(data));

        
    



}




//Prepara dados para serem enviados

function PrepareEnv() {
    let tBody = $("#itensDespesas");
    let Trs = tBody[0].getElementsByTagName("tr");
    let Itens = new Array();

    for (var item = 0; item < Trs.length; item++) {
        var Json = new Object();

        Json.IdDespesa = parseInt(Trs[item].cells[0].innerHTML);
        Json.DespesaDescricao = Trs[item].cells[1].innerHTML;
        Json.Quantidade = (Trs[item].cells[2].innerHTML);
        Json.Valor = (Trs[item].cells[3].innerHTML);
        Json.Observacao = Trs[item].cells[5].innerHTML;

        Itens.push(Json);
    }
    return Itens;
}


