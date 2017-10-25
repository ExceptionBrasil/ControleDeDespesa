
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
        
    
    


    let controller = {"Controller": contexto}; 
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
                window.location.replace(urlSuccess);
            } else {
                erroDeEnvio(response.error);
            }

        }
    });

}());