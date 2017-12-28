/*
 * 12/2017 - Daniel P Silveira
 * Bibliotec de envio de multiplos arquivos ao servidor 
 * Base da documentação 
 * http://blog.teamtreehouse.com/uploading-files-ajax
 */

///
/// sumary
/// Obtem todo os arquivos anexados 
///
var GetFiles = function () {

    //Lista os arquivos
    var Attachment = document.querySelector("#Attachment").files;
}

///
/// sumary 
/// Retorna o tamanho dos anexos em MegaBits
///
var GetSize = function (Attachment) {
    let soma=0;
    for (var j = 0; j < Attachment.length; j++) {
        soma += Attachment[j].size;
    }

    //Obtem o tamnho em Megabits
    return ((soma/1024)/1024)
}


///
/// sumary
/// Retorna o FormData para envio ao servidor
///
var PrepareFormData = function () {
    //Cria um novo formData
    let formData = new FormData();


    // Adiciona os arquivos no FormData
    for (var i = 0; i < Attachment.length; i++) {
        let file = Attachment[i];


        //Apenas imagens 
        if (!file.type.match('image.*')) {
            continue;
        }

        // Add the file to the request.
        formData.append('imagens[]', file, file.name);
    }

    return formData;
}



///
/// sumary
/// faz o envio do dados do formulário para o servidor 
///

var SendAttchment = function (formData) {
    // Set up the request.
    let xhr = new XMLHttpRequest();

    // Open the connection.
    xhr.open('POST', '/Upload/Upload', true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            // File(s) uploaded.
            uploadButton.innerHTML = 'Upload';
        } else {
            alert('An error occurred!');
        }
    };

    //Faz o envio das imagens para o server
    xhr.send(formData);

}
