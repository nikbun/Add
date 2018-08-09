$('form#form1 #exampleModalCenter').on('hidden.bs.modal', function (e) {
    $("form#form1 input.form-control").blur();
    $('form#form1 input.form-control').val('');
    $("form#form1 input.form-control").removeClass("input-validation-error");
    $("form#form1 input.form-control").addClass("valid");
    $("form#form1 input.form-control").attr("aria-invalid", "false");
    $("form#form1 span.text-danger").removeClass("field-validation-error");
    $("form#form1 span.text-danger").addClass("field-validation-valid");
    $("form#form1 span.text-danger").children().remove();
    $("form#form1 select.form-control")[0].selectedIndex = 0;
    $("form#form1 #exampleModalLongTitle")[0].innerHTML = "Добавление новой записи";
})