

/// <var>The initialize</var>
/// <summary>
/// Inicialização básica dos Termos 
/// </summary>
/// <returns>WebService</returns>
var WebService = (
	function () {

		//Objetos
		var Termo = {
			Aceito: false
		};

		var btnAceitar = document.querySelector("#TermoAceito");
		var btnNaoAceito = document.querySelector("#TermoRecusado");


		///Inicializa o WebService		
		var Init = () => {
			btnAceitar.addEventListener("click", function (event) {
				event.preventDefault();
				event.stopPropagation();

				Termo.Aceito = true;
				WebService.Send();

			});

			btnNaoAceito.addEventListener("click", function (event) {
				event.preventDefault();
				event.stopPropagation();

				Termo.Aceito = false;
				WebService.Send();
			});
		}

		//Monta a promisse
		var SendData = (TermoDeAceite) => {
			return (new Promise((resolve, reject) => {

				$.ajax({
					url: "/Termos/TermoDeAceiteRDVPost",
					data: TermoDeAceite,
					dataType: "json",
					method: "POST",
					error: function (response) {
						console.log("Termo.Ini.js |Epic Fail !");
						console.log(resolve);
						reject(response);
					},
					success: function (response) {
						if (response.success) {
							console.log("Termo.Ini.js | Sucess! Redirecting...");
							resolve(response.success);
						}
						else {
							console.log("Termo.Ini.js | Sucess! Redirecting...!");
							resolve(response.success);
						}
					}
				});
			})
			);
		}


		//Request do Promisse 
		var Send = () => {

			SendData(Termo).then((response) => {
				console.log(response);
				if (response) {
					window.location.replace(urlContinue);
				} else {
					window.location.replace(urlRollback);
				}
				
			}).catch((e) => console.log(e));
		   
		}


		/// Retono dos mátodos públicos 
		return ({
			Init: Init,
			Send: Send
		});

	}
)();

WebService.Init();
