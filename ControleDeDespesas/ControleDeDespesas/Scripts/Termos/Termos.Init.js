

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
		var Init = function () {
			btnAceitar.addEventListener("click", function (event) {
				event.preventDefault();
				event.preventPropagation();

				Termo.Aceito = true;

			});

			btnNaoAceito.addEventListener("click", function (event) {
				event.preventDefault();
				event.preventPropagation();

				Termo.Aceito = false;
			});
		}

		//Monta a promisse
		var SendData = function () {
			return (new Promise(function (resolve, reject) {

				$.ajax({
					url: urlDespesasIncluir,
					data: Dados,
					dataType: "json",
					method: "POST",
					error: function (response) {
						console.log(response);
					},
					success: function (response) {
						if (response.success) {
							window.location.replace("/Despesas");
						} else {
							erroDeEnvio(response.menssage);
						}

					}
				});



			})
			   );
		}


		//Faz o envio das informações
		var Send = function () {
			SendData.then().cath();

		}

		/// Retono dos mátodos públicos 
		return ({
			Init: Init,
			Send: Send
		});

	}
)();