
/*
 * Gera a string da tabela 
 */
var geraStringHTML = (I) => {

    var stringHTML = "";
    stringHTML += "<tr id='Item" + I.IdDespesa + "'>";
    stringHTML += "<td>" + I.IdDespesa + "</td>";
    stringHTML += "<td>" + I.DespesaDescricao + "</td > ";
    stringHTML += "<td>" + I.Quantidade + "</td>";
    stringHTML += "<td>" + I.Valor + "</td>";
    stringHTML += "<td>" + ToFloatToString(I.Total) + "</td>";
    stringHTML += "<td>" + I.Observacao + "</td>";
    stringHTML += "<td><a onclick='EditaItem(" + I.IdDespesa + ")'  href='#'><span class='glyphicon glyphicon-edit'></span></a></td>";
    stringHTML += "<td><a onclick='RemoveItem(" + I.IdDespesa + ")' href='#'><span class='glyphicon glyphicon-erase'></span></a></td>";
    stringHTML += "</tr>"

    return stringHTML;
}

/**
 * Imprime o total em tela
 * @param {any} valor
 */
var ImprimeTotal = function (valor) {
    var total = document.querySelector("#tbTotal");
    total.innerHTML = "<h4>Total: " + parseFloat(valor.toFixed(2)).toLocaleString() + "</h4>";
}

/**
 * Mesagem de conteúdo inválido
 * @param {any} tag
 */
var EscreveAvisoDeErro = function (tag) {
    $("#" + tag).after(
        `<div class="alert alert-warning alert-dismissible fade in" role="alert" id="AlertaDeCampo">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            <strong>Conteúdo Inválido!</strong>
            O conteúdo do campo <strong>`+ tag + ` </strong> está inválido
            </div>`);
}

var erroDeEnvio = function (erro) {
    $("#erroDeEnvio").after(`<div class="alert alert-warning alert-dismissible fade in" role="alert" id="ErroDeWebService">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            <strong>Erro ao enviar informação ao Servidor!</strong>
            `+erro+`
            </div>`);
}