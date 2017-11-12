
/*
 * 11/11/2017 
 * Módulo que carrega o menu Usando o BuildMenu
 */

var Menus = new MenuBuilder();

    //
    //Inicializa o Eviroment dos Menus
    //
    Menus.Init = function () {
        

        Menus.Controller.set({ "Location": GetContex() });
        Menus.UrlDestino.set(urlGetMenu);
}
    //
    //Faz o Load dos menus
    //
    Menus.Load = function () {

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

    
   
   