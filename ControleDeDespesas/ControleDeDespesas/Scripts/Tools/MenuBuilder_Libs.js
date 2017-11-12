
/**
 * Retorna o Contexto do controller
 * 
 */
var GetContex = () => {
    //Verifica qual é o controller que estou trabalhando e recupera ele
    let contexto = window.location.pathname;

    while (contexto.indexOf("/") >= 0) {

        if (contexto.indexOf("/") === 0) {
            contexto = contexto.slice(1, contexto.length);
        }

        if (contexto.indexOf("/") > 0) {

            contexto = contexto.slice(0, contexto.indexOf("/"));
        }

    }

    return contexto;
}


var WriteHtml = function (menu) {
    var MenuBuilder = document.querySelector("#LoadMenu");
    var htmlScript = "";

    htmlScript += '<div class="thumbnail">';
    htmlScript += '    <div class="row">';
    htmlScript += '        <div class="col-md-4 col-xs-12">';
    htmlScript += '           <ul class="nav nav-pills">';
    htmlScript += '                <li role="presentation" class="dropdown">';
    htmlScript += '                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">';
    htmlScript += '                        Opções<span class="caret"></span>';
    htmlScript += '                     </a>';
    htmlScript += '    <ul class="dropdown-menu">';



    for (var i = 0; i < menu.length; i++) {
        htmlScript += ' <li><a href="' + menu[i].Controller + '/' + menu[i].Action + '">' + menu[i].Descricao + '</a></li>';
    }

    htmlScript += '                    </ul>';
    htmlScript += '            </li>';
    htmlScript += '        </ul>';
    htmlScript += '    </div>';
    htmlScript += '</div>';
    htmlScript += '</div>';

    MenuBuilder.innerHTML = htmlScript;

}

