
$('#exampleModalCenter').on('hidden.bs.modal', function (e) {
    $("input.form-control").blur();
    $('input.form-control').val('');
    $("input.form-control").removeClass("input-validation-error");
    $("input.form-control").addClass("valid");
    $("input.form-control").attr("aria-invalid", "false");
    $("span.text-danger").removeClass("field-validation-error");
    $("span.text-danger").addClass("field-validation-valid");
    $("span.text-danger").children().remove();
})