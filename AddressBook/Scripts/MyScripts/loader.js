$(document).ready(function () {
	$(function () {
		var form = $("form#form1");

		// Устанвка начального значения в форме
		$("select.type-selector", form).get(0).selectedIndex = 0;
		$("input.type-selector", form).get(0).value = "";

		// Отключение списка автозаполнения в форме
		$("input#City", form).get(0).autocomplete = "off"
	})
})