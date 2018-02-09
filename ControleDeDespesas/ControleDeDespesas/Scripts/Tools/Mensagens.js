


/**
 * Adiciona um PopOver em um objeto e exibe ele
 * @param {string} object Objeto que vai ganhar o PopOver
 * @param {string} title   Título
 * @param {string} content Conteúdo
 * @param {"left", "right", "top", "bottom"} direction Direção que será exibido
 * @param {boolean} autoShow Se já exibe na sequência o PopOver
 */
function AddErrorPopOver(object, title, content, direction,autoShow) {

    AddPopOver(object);

    if (title !== null) {
        AddTitle(object, title);
    }
    
    AddDataContent(object, content);
    AddDirection(object, direction);
    AddFoucus(object);

    if (autoShow) {
        $(object).popover('show');
    }
    
}



function AddPopOver(object) {
    $(object).attr("data-toggle", "popover");
}

function AddTitle(object, title) {
    $(object).attr("title", title);
}

function AddDataContent(object,content) {
    $(object).attr("data-content", content);
}

function AddDirection(object, direction) {
    $(object).attr("placement", direction);
}

function AddFoucus(object) {
    $(object).attr("data-trigger", "focus" );    
}
