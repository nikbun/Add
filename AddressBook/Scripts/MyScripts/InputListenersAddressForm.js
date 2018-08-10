$(document).ready(function () {
	$(function () {
		var form = $("form#form1");

		// Проверяет поля ввода формы на наличие заглавной буквы и обновляет
		$("input.capital-letter", form).on("focusout", function (eventObject) {
			var s = this.value;
			if (s != "") {
				s.substr(1, s.length);
				s = s[0].toUpperCase() + s.substr(1, s.length).toLowerCase();
				this.value = s;
			}
		});

		// Перехватывает нажатия с клавиатуры позволяя вводить только цифры
		$("input.only-number", form).on("keydown", function (eventObject) {
			if ((!(eventObject.which >= 48 && eventObject.which <= 57) ||
				this.value.length >= 5) &&
				eventObject.which != 8 &&
				eventObject.which != 9 &&
				eventObject.which != 13 &&
				eventObject.which != 46) {
				eventObject.preventDefault();
			}
		});

		
	});
});