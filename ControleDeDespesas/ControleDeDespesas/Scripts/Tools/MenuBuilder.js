
/* Data: 29/10/2017
 * Author: Daniel Pitthan Silveira
 * Módulo que carrega o menu Usando o BuildMenu
 */
(function () {
    

    //Recupera os Menus 
    var promise = new Promise(function (resolve, reject) {

    });

    var Menus = GetMenus();
    WriteHtml(Menus);

}());



function WriteHtml(Menus) {

    var menu = "";
    var P0 = new Array();
    var P1 = new Array();
    var P2 = new Array();
    var P3 = new Array();
    var P4 = new Array();
    var P5 = new Array();
    var P6 = new Array();
    var P7 = new Array();
    var P8 = new Array();
    var P9 = new Array();
    var P10 = new Array();
    var P11 = new Array();
    var P12 = new Array();





    for (var i = 0; i < Menus.length; i++) {
        if (Menus[i].Position == 0) {
            P0.push(Menus[i]);
        }
        if (Menus[i].Position == 1) {
            P1.push(Menus[i]);
        }
        if (Menus[i].Position == 2) {
            P2.push(Menus[i]);
        }
        if (Menus[i].Position == 3) {
            P3.push(Menus[i]);
        }
    }
   
    let Html = '';
    Html += '<div class="container-fluid">';    
    Html += '        <div class="row">';
    Html += '            <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">';
    Html += '                <ul class="nav nav-tabs nav-fill">';
                                    //Posição 0
    Html += '                    <li>Posicao0</li>';
                                    //Posicao 1
    Html += '                    <li role="presentation" class="dropdown">';
    Html += '                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">';
    Html += '                            Opções<span class="caret"></span>';
    Html += '                        </a>';
    Html += '                        <ul class="dropdown-menu">';
    Html += '                            <li><span class="glyphicon glyphicon-list-alt">@Html.ActionLink(" Novo", "FrmIncluir", "Despesas")</span></li>';
    Html += '                            @if (ViewBag.IsAdmin)';
    Html += '                        {';
    Html += '                                <li> <span class="glyphicon glyphicon-copy">@Html.ActionLink(" Tipos de Despesas", "Index", "TiposDespesas")</span>  </li>';
    Html += '                                <li> <span class="glyphicon glyphicon-user">@Html.ActionLink(" Usuarios", "Index", "Usuarios")</span>  </li>';
    Html += '                                <li> <span class="glyphicon glyphicon-subtitles">@Html.ActionLink(" Centro de Custo", "Index", "CentroDeCusto")</span>  </li>';
    Html += '                                <li> <span class="glyphicon glyphicon-user">@Html.ActionLink(" Aprovador por CC", "Index", "AprovadorPorCC")</span>  </li>';
    Html += '                        }';
    Html += '                            @if (ViewBag.IsAprovador)';
    Html += '                        {';
    Html += '                                <li>Aprovação</li>';
    Html += '                            }';
    Html += '                        </ul>';
    Html += '                    </li>';
    Html += '                </ul>';
    Html += '            </div>';
    Html += '        </div>';    
    Html += '</div>';
    
}

function GetMenus() {

    //Recupera o menu pela localização atual
    var controller = { "Location": RecoveryControllerName() };
    var urlDestino = urlGetMenu    // Recebe externamente: "/Menu/Get"

    $.ajax({
        url: urlDestino,
        data: controller,
        dataType: "json",
        method: "POST",
        error: function (response) {
            console.log(response.menssage);
        },
        success: function (response) {
            if (response.success) {
                return response.menu;
            } else {
                console.log(response.menssage);
            }

        }
    });
}


function RecoveryControllerName() {
    let path = window.location.pathname

    while (path.indexOf("/") >= 0) {

        if (path.indexOf("/") == 0) {
            path = path.slice(1, path.length)
        }

        if (path.indexOf("/") > 0) {

            path = path.slice(0, path.indexOf("/"))
        }

    }

    return path;
}