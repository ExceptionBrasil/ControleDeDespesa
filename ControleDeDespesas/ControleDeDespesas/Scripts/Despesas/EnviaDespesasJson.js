
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


    //Lista os arquivos
    var Attachment = document.querySelector("#Attachment").files;    

    //Cria um novo formData
    var formData = new FormData();


    // Adiciona os arquivos no FormData
    for (var i = 0; i < Attachment.length; i++) {
        var file = Attachment[i];


        //Apenas imagens 
        if (!file.type.match('image.*')) {
            continue;
        }

        // Add the file to the request.
        formData.append('imagens[]', file, file.name);
    }
    //http://blog.teamtreehouse.com/uploading-files-ajax

    //faz o envio do dados do formulário para o servidor 
    //Adcionar uma lista de arquivos? Ou dos nomes? 
    //E se eu tiver arquivos com mesmo nome? Nome original, nome randomico....

    // Set up the request.
    var xhr = new XMLHttpRequest();

    // Open the connection.
    xhr.open('POST', '/Upload/Upload', true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            // File(s) uploaded.
            uploadButton.innerHTML = 'Upload';
        } else {
            alert('An error occurred!');
        }
    };

    xhr.send(formData);

    $.ajax({
        url: urlDespesasIncluir,
        data:Dados,
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


