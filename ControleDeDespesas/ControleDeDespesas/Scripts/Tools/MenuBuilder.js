
/*
 * Módulo que carrega o menu Usando o BuildMenu
 */
(function () {
    

    //Verifica qual é o controller que estou trabalhando e recupera ele
    let contexto = window.location.pathname

    while (contexto.indexOf("/")>=0) {

        if (contexto.indexOf("/") == 0) {
            contexto = contexto.slice(1, contexto.length)
        }

        if (contexto.indexOf("/") > 0) {

            contexto = contexto.slice(0, contexto.indexOf("/"))
        }

    }
        
    
    let controller = {"Location": contexto}; 
    let urlDestino = urlGetMenu    // Recebe externamente "/Menu/Get"


    //Recupera os Menus 
    $.ajax({
        url: urlDestino,
        data: controller,
        dataType: "json",
        method: "POST",
        error: function (response) {
            console.log(response.menu);

        },
        success: function (response) {
            if (response.success) {
                //console.log(response.menu);
                WriteHtml(response.menu);
            } else {
                console.log(response.menu);
            }

        }
    });

}());

var WriteHtml = function (menu) {
    var MenuBuilder = document.querySelector("#MenuBuilder");
    var htmlScrip = "";

    htmlScrip += '<div class="thumbnail">'
    htmlScrip += '    <div class="row">'
    htmlScrip += '        <div class="col-md-4 col-xs-12">'
    htmlScrip += '           <ul class="nav nav-pills">'    
    htmlScrip += '                <li role="presentation" class="dropdown">'
    htmlScrip += '                    <a class="dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">'
    htmlScrip += '                        Opções<span class="caret"></span>'
    htmlScrip += '                     </a>'
    htmlScrip += '    <ul class="dropdown-menu">'



    for (var i = 0; i < menu.length; i++) {
        htmlScrip += ' <li><span class="' + menu[i].Glyphicon + '"><a href="' + menu[i].Controller+ '/' + menu[i].Action  + '">' + menu[i].Descricao +'</a>)</span>  </li>'
    }

    htmlScrip +='                    </ul>'
    htmlScrip +='            </li>'
    htmlScrip +='        </ul>'
    htmlScrip +='    </div>'
    htmlScrip +='</div>'
    htmlScrip += '</div>'

    MenuBuilder.innerHTML = htmlScrip;

}

