// Adicionamos o método date para sobrepor o método padrão e atribuindo sempre um retorno verdadeiro para garantir 
// que o JQuery não vai tratar as data exibindo mensagens indesejadas. 
$.validator.addMethod('date',
   function (value, element) {
       return true;
   });

// Aqui adicionamos os métodos respeitando os nomes gerado em nossa classe atributo
// os nomes devem estar em caixa baixa tanto na integração como aqui no JavaScript (Nome atributo, parametro)
$.validator.unobtrusive.adapters.addSingleVal("databrasil", "datarequerida");

//Aqui temos a funcao que Valida do lado do cliente as datas digitadas utilizando uma expressão regular
$.validator.addMethod('databrasil',
function (value, element, datarequerida) {

    // Verificamos se o valor foi digitado
    if (value.length === 0) {
        // Se a data é requerida retorna erro senão retorna com sucesso
        if (datarequerida.toString() === 'True') {
            return false;
        }
        else {
            return true;
        }
    }

    /// Expressão Regular para tratar datas, dd/MM/yyyy, validando também ano Bisexto.
    //var expReg = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/;
    var expReg = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;
    // Valida a expressão, se for compatível vai retornar validando o campo, caso contrario exibe a mensagem de erro informada no atributo;
    return value.match(expReg);
});

$.validator.unobtrusive.adapters.addSingleVal("idademinima", "idade");

//Aqui temos a funcao que Valida do lado do cliente as datas digitadas utilizando uma expressão regular
$.validator.addMethod('idademinima',
function (value, element, idade) {

    // Verificamos se o valor foi digitado
    if (value.length === 0) {
        // Se a data é requerida retorna erro senão retorna com sucesso
        if (datarequerida.toString() === 'True') {
            return false;
        }
        else {
            return true;
        }
    }

    /// Expressão Regular para tratar datas, dd/MM/yyyy, validando também ano Bisexto.
    //var expReg = /^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$/;
    var expReg = /^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/;

    debugger
    // Valida a expressão, se for compatível vai retornar validando o campo, caso contrario exibe a mensagem de erro informada no atributo;
    if (value.match(expReg)) {
        var dataAtual = new Date();
        var anoAtual = dataAtual.getFullYear();
        var anoNascParts = value.split('/');
        var diaNasc = anoNascParts[0];
        var mesNasc = anoNascParts[1];
        var anoNasc = anoNascParts[2];
        var idadeAtual = anoAtual - anoNasc;
        var mesAtual = dataAtual.getMonth() + 1;
        //se mês atual for menor que o nascimento, nao fez aniversario ainda; (26/10/2009) 
        if (mesAtual < mesNasc) {
            idadeAtual--;
        } else {
            //se estiver no mes do nasc, verificar o dia
            if (mesAtual == mesNasc) {
                if (dataAtual.getDate() < diaNasc) {
                    //se a data atual for menor que o dia de nascimento ele ainda nao fez aniversario
                    idadeAtual--;
                }
            }
        }
        if (idadeAtual < idade) {
            return false;
        }
        else {
            return true;
        }
    }
});

///Validações Numeros

// Adicionamos o método ranger para sobrepor o método original e corrigir os valores passados,
// retirando o ponto milhar e trocando a virgula decimal por ponto decimal, 
// Com isto solucionamos os conflitos ao tentar definir um range para um valor quando utilizamos o atributo NumeroBrasil 
$.validator.addMethod('range',
   function (value, element, params) {

       // Coleta os parametros passados, valor maximo e minimo
       var min = params[0];
       var max = params[1];

       // Retira todo ponto de milhar formatado no campo valor
       var pos = value.indexOf('.');
       while (pos > -1) {
           value = value.replace('.', '');
           pos = value.indexOf('.');
       }

       // Troca virgula decimal por ponto decimal
       value = value.replace(',', '.');

       // Faz a validacao do valor, comparando com o valor minimo e maximo
       if (value < min) {
           return false;
       }

       if (value > max) {
           return false;
       }

       return true;
   });


// Adicionamos o metodo number para sobrepor o metodo padrão e atribuindo sempre um retorno verdadeiro para garantir 
// que o JQuery não vai tratar os numeros exibindo mensagens indesejadas. 
$.validator.addMethod('number',
   function (value, element) {
       return true;
   });

// Aqui adicionamos os metodos respeitando os nomes gerado em nossa classe atributo
// os nomes devem estar em caixa baixa tanto na integração como aqui no JavaScript (Nome atributo, parametro)
$.validator.unobtrusive.adapters.addSingleVal('numerobrasil', 'params');

//Aqui temos a funcao que Valida do lado do cliente os números digitados utilizando uma expressão regular
$.validator.addMethod('numerobrasil',
function (value, element, params) {

    // Separamos o parametros recebidos
    var parametros = params.split(',');

    // Verifica o Ponto de milhar
    if (parametros[1].toString() == "True") {
        var pos = value.indexOf('.');
        while (pos > -1) {
            value = value.replace('.', '');
            pos = value.indexOf('.');
        }
    }

    // Valida caso o valor não tenha sido preenchido
    if (value.length == 0) {
        return true;
    }

    var expReg = '';

    // atribui a expressao regular com ou sem ponto decimal
    if (parametros[0].toString() == 'False') {
        expReg = /^[-+]?\d*$/;
    }
    else {
        expReg = /^[-+]?\d*\,?\d*$/;
    }

    // Valida a expressão, se for compativel vai retornar validando a campo, caso contrario exibe a mensagem de erro informada no atributo;
    return value.match(expReg);
});


// Aqui adicionamos os metodos respeitando os nomes gerado em nossa classe atributo
// os nomes devem estar em caixa baixa tanto na integração como aqui no JavaScript (Nome atributo, parametro)
$.validator.unobtrusive.adapters.addSingleVal('emailbrasil', 'emailrequerido');

//Aqui temos a funcao que Valida do lado do cliente o e-mail digitado utilizando uma expressão regular
$.validator.addMethod('emailbrasil',
function (value, element, emailrequerido) {

    // Retira espaços do final da literal
    value = value.trim();

    // Valida caso o valor não tenha sido preenchido
    if (value.length == 0) {
        if (emailrequerido.toString() == "True") {
            return false;
        }
        else {
            return true;
        }
    }

    // Atribui expressão
    var expReg = /^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$/;

    // Valida Expressao
    var result = value.match(expReg);

    // Retorna false caso a expressao nao seja valida
    if (result != null) {
        return true;
    }

    return false;
});