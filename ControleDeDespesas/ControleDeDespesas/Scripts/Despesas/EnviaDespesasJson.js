
$(document).ready(function () {
    var  btnEnviar = document.querySelector("#enviaDespesas");
    btnEnviar.addEventListener("click", WebServicesDespesa);
});



var WebServicesDespesa = ()=>{
    $.ajax({
        url: "http://localhost:52102/Despesas/Incluir",
        data: { "despesas": Itens },
        dataType: "json",
        error: function(){
            console.log("Erro de processamento no servidor");
        },
        success: function(){
            console.log("Sucesso!");
        },
        method :"POST"
    });
}