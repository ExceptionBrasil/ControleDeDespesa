
/*
 * 11/11/2017 
 * Módulo que carrega o menu Usando o BuildMenu
 */
(function () {



    let controller = { "Location": GetContex() };
    let urlDestino = urlGetMenu;    // Recebe externamente "/Menu/Get"

    let promise = new Promise((resolve, reject) => {
        let menu = GetMenu(controller, urlDestino);

        if (menu == undefined) {
            reject("Error to get Menu on Ajax Loader | MenuBuilder_Module.js")
        }

        if (menu.length > 0) {
            resolve(menu);
        } else {
            reject("Menu don't have itens to continue | MenuBuilder_Module.js")
        }
    });


    promise
        .then((data)  => WriteHtml(data))
        .catch((data) => console.log(data));

    ///
   
}());

