


/**
 * Classe de controle dos Menus
 */
var MenuBuilder = function () {
    
    this.Controller = {
        set: function (value) { Controller = value; },
        get: function () { return Controller; }
    } 
    
    
    this.UrlDestino = {
        set: function (value) { UrlDestino = value; },
        get: function () { return UrlDestino; }        
    }

    this.Menu = {
        set: function (value) { Menu = value; },
        get: function () { return Menu;}
    }
}