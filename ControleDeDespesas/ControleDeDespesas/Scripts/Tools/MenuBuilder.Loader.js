


/**
 * Objeto de controle dos Menus
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
		get: function () { return Menu; }
	}
}


/*
 * 11/11/2017 
 * Cria objeto de inicialização
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
		htmlScript += ' <li><a href="'+'/' + menu[i].Controller + '/' + menu[i].Action + '">' + menu[i].Descricao + '</a></li>';
	}
	htmlScript += '                    </ul>';
	htmlScript += '            </li>';
	htmlScript += '        </ul>';
	htmlScript += '    </div>';
	htmlScript += '</div>';
	htmlScript += '</div>';

	MenuBuilder.innerHTML = htmlScript;

}




	/* 
	** Módulo de inicialização 
	*/
	; (function () {
		Menus.Init();
		Menus.Load();
	})();
