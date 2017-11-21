


/*
** Faz o envio senssível das informações para o servidor 
*/
$(document).ready(function () {
    var btnAprovar = $("#btnAprovar");
    var btnRecusar = $("#btnRecusar");

    btnSubmit.addEventListener("click", GetAprovacao);
    btnSubmit.addEventListener("click", GetRecusa);
})



var GetAprovacao = function(event){
    event.preventDefault();
    event.stopPropagation();


    let promise = new Promise((resolve, reject) => {

        //Ajax Object 
        let ajaxObj = {
            url: Menus.UrlDestino.get(),
            data: Menus.Controller.get(),
            dataType: "json",
            method: "POST",
            error: function (response) {
                resolve("Erro to get Menu on Ajax request");

            },
            success: function (response) {
                if (response.success) {
                    Menus.Menu.set(response.menu);
                    resolve(Menus.Menu.get());
                } else {
                    reject("Menu don't have itens to continue | MenuBuilder_Module.js");
                }

            }
        }

        //Faz o call do Webservice
        $.ajax(ajaxObj);

    });

    //Resolve a promisse 
    promise
        .then((data) => WriteHtml(data))
        .catch((data) => console.log(data));
}


var GetRecusa = function (event) {
    event.preventDefault();
    event.stopPropagation();


    let promise = new Promise((resolve, reject) => {

        //Ajax Object 
        let ajaxObj = {
            url: Menus.UrlDestino.get(),
            data: Menus.Controller.get(),
            dataType: "json",
            method: "POST",
            error: function (response) {
                resolve("Erro to get Menu on Ajax request");

            },
            success: function (response) {
                if (response.success) {
                    Menus.Menu.set(response.menu);
                    resolve(Menus.Menu.get());
                } else {
                    reject("Menu don't have itens to continue | MenuBuilder_Module.js");
                }

            }
        }

        //Faz o call do Webservice
        $.ajax(ajaxObj);

    });

    //Resolve a promisse 
    promise
        .then((data) => WriteHtml(data))
        .catch((data) => console.log(data));
}