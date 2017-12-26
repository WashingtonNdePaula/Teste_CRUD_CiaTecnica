$(document).ready(function () {
    $("#Pessoa_CEP").blur(function () {
        var cepw = $("#Pessoa_CEP").val();
        var url = "/Cliente/ConsultaCEP";
        $("#Pessoa_Logradouro").val("Carregando...");
        $("#Pessoa_Bairro").val("Carregando...");
        $("#Pessoa_Cidade").val("Carregando...");
        $("#Pessoa_UF").val("Carregando...");

        $.get(url, { cep: cepw }, function (data) {
            $("#Pessoa_Logradouro").val(data.Logradouro);
            $("#Pessoa_Bairro").val(data.Bairro);
            $("#Pessoa_Cidade").val(data.Cidade);
            $("#Pessoa_UF").val(data.UF);
        });
    });

    $("#pj").on("click", function () {
        var form = $("#formCliente");
        form.attr("method", "get");
        form.attr("action", "CreatePJ");
        form.unbind("submit");
        form.submit();
    });

    $("#pf").on("click", function () {
        var form = $("#formCliente");
        form.attr("method", "get");
        form.attr("action", "CreatePF");
        form.unbind("submit");
        form.submit();
    });

    $("#salvar").on("click", function () {
        var form = $("#formCliente");
        var tipo = $('input[name=ClienteTipoPessoa]:radio:checked').val();
        form.attr("method", "post");
        $("#Pessoa_TipoPessoa").val(tipo);
        form.attr("action", "Create");
        form.submit();
    });

    $("#editar").on("click", function () {
        var form = $("#formCliente");
        form.attr("method", "post");
        form.attr("action", "Edit");
        form.submit();
    });
});
