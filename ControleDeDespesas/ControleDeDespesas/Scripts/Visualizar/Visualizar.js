

$(document).ready(function () {

    ///Faz a soma da tabela 

    var tabela = document.querySelector("#despesas");
    var trs = tabela.querySelectorAll("tr");
    var soma = 0;

    for (var i = 1; i < trs.length; i++) {
        var td = trs[i].querySelectorAll("td");
        if (!isNaN(parseFloat(td[1].innerText))) {
            soma += parseFloat(td[1].innerText) * parseFloat(td[2].innerText);
        }
        
    }
    soma = soma.toFixed(2).toLocaleString();
    $("#total").html(soma);
});   
