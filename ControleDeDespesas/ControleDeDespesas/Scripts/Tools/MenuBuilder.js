var menu
var menuString


var BuildMenu = function (codigoMenu) {

}


var GetMenu = function(codigo) {

    $.ajax({
        url: "http://localhost:56849/MenuBuilder/GetMenu",
        data: { code: "mainMenu" },
        method: "POST",
        error: function (response) {
            if (!response.success) {
                console.log("Servidor indisponível");
            }
            
        },
        success: function (response) {
            if (response.success) {
                console.log(JSON.parse(response.json));
                menu = JSON.parse(response.json);
                menuString = response.json;
            }
            
        },
    });
}