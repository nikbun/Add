// Приводит форму к первоначальному состоянию
$(function () {
	var form = $('form#form1')

	$('#exampleModalCenter', form).on('hidden.bs.modal', function (e) {
		$("input.form-control", form)
			.blur()
			.val('')
			.removeClass("input-validation-error")
			.addClass("valid")
			.attr("aria-invalid", "false");
		$("span.text-danger", form)
			.removeClass("field-validation-error")
			.addClass("field-validation-valid")
			.children().remove();
		$("select.form-control", form).get(0).selectedIndex = 0;
		$("#exampleModalLongTitle").get(0).innerText = "Добавление новой записи";
	})
});
