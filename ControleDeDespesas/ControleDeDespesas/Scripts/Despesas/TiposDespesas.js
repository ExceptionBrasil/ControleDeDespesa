var tiposDeDespesas = null;


//Quando o ducumeto estiver pronto busco os tipos de ducumeto
$(document).ready(function(){
  //Pega os tipos de despesas
  $.ajax({
    url:"/TiposDespesas/GetTipos",
    dataType: "json",
    method: "POST",
    success: function(result){
      tiposDeDespesas = result;
    },
    error: function(result){
      erroDeEnvio("Não foi possível obter os tipos de despesas do servidor");
    }
  });



  //Verifica se a opção que eu escolhi possui valor fixo
  $("#Tipo").blur(function(){
    for (var i = 0; i < tiposDeDespesas.length; i++) {
      let TipoEscolhido  = $("#Tipo");
      if (tiposDeDespesas[i].ValorFixo>0 && TipoEscolhido[0].value == tiposDeDespesas[1].Id){
        //TipoEscolhido.
        $("#Valor").val(tiposDeDespesas[i].ValorFixo);
        document.getElementById("Valor").disabled = true;
        return;
      }
      else {
        document.getElementById("Valor").disabled = false;
      }
    }
  });
});﻿


//Gap:
//Quando clica no editar da grid consigo editar um valor fixo
//possivel corrção: adicionar um evento no click do editar para fazer a verificação acima
