


/**
 * faz a validação do formúlario digitado
 */
function ValidaFormulário() {

    
    Formulario = new FormObject();


    if (Formulario.CentroCusto == "") {
        AddErrorPopOver("#submitAprovadorCC", "Campo não preechido", "O Centro de Custo não foi informado", "right", true);
        return false;
    }

    if (Formulario.Usuario == "") {
        AddErrorPopOver("#submitAprovadorCC", "Campo não preechido", "O Usuario não foi informado", "right", true);
        return false;
    }

    if (Formulario.Limite == "") {
        AddErrorPopOver("#submitAprovadorCC", "Campo não preechido", "O Limite não foi informado", "right", true);
        return false;
    }


    return true;
}


function FormObject() {

    this.CentroCusto = $("#CC").val();
    this.Usuario = $("#Usuario").val();
    this.Superior = $("#Superior").val();
    this.Limite = $("#Limite").val();
    this.Id = $("#Id").val();

}