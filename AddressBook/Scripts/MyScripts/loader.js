$(document).ready(function () {
	$(function () {
		var form = $("form#form1");

		// Устанвка начального значения в форме
		$("select.form-control", form).get(0).selectedIndex = 0;

		// Отключение списка автозаполнения в форме
		$("input#City", form).get(0).autocomplete = "off"
	})
})