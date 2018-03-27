
    /// <summary>
    /// Módulo de execução de request do login
    /// </summary>
    /// <returns></returns>
$(document).ready(function () {


    $("#UserLogin").focus();

    $(function () {

        $("#UserPassword").on("submit", function (e) {
            e.preventDefault();
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (response) {
                    if (response != null && response.success) {
                        
                        window.location.replace(url);
                    } else {
                        $("#result").html("Login Inválido!");
                    }

                },
                error: function (response) {
                    $("#result").html("Login Inválido!");
                }
            });
        });
    });

});
