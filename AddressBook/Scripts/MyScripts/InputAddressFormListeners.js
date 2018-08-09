$(document).ready(function () {

    // Проверяет поля ввода формы на наличие заглавной буквы и обновляет
    $("form#form1 input.capital-letter").focusout(function (eventObject) {
        var s = this.value;
        if (s != "") {
            s.substr(1, s.length);
            s = s[0].toUpperCase() + s.substr(1, s.length);
            this.value = s;
        }
    });

    $("form#form1 input.not-e").keyup(function (eventObject) {
        var s = this.value;
        if (~s.indexOf('e')) {
            this.value = s.replace("e", "")
        }
    });
})