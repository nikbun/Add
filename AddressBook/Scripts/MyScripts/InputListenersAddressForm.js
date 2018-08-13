$(document).ready(function () {
	$(function () {
		var form = $("form#form1");

		// Проверяет поля ввода формы на наличие заглавной буквы и обновляет
		$("input.capital-letter", form).on("focusout", function (eventObject) {
			var str = this.value;

			if (str != "") {
				var astr = str.split(' ');
				str = "";
				for (var i = 0; i < astr.length; i++) {
					str += astr[i].substring(0, 1).toUpperCase() + (astr[i].length > 1 ? astr[i].substring(1).toLowerCase() : "") + " ";
				}
				str = str.substring(0, str.length - 1);
				this.value = str;
			}
		});

		// Перехватывает нажатия с клавиатуры позволяя вводить только цифры
		$("input.only-number", form).on("keydown", function (eventObject) {
			if ((!(eventObject.which >= 48 && eventObject.which <= 57 ||
				eventObject.which >= 96 && eventObject.which <= 105) ||
				this.value.length >= 5) &&
				eventObject.which != 8 &&
				eventObject.which != 9 &&
				eventObject.which != 13 &&
				eventObject.which != 46) {
				eventObject.preventDefault();
			}
		});

		// При изменении селектора передает значение в поле input
		$("select.type-selector", form).on("change", function (eventObject) {
			var typeBuildingId = this.children[this.selectedIndex].value;
			if (typeBuildingId == 0) {
				$("input.type-selector", form).get(0).value = null;
			}
			else
			{
				$("input.type-selector", form).get(0).value = typeBuildingId;
			}
		})

		// Открывает форму редактирования при двойном клике по строке таблицы
		$("div#resultAddresses").on("dblclick", ".edit-address" , function (eventObject) {
			$("#exampleModalLongTitle", form).get(0).innerText = "Редактирование записи";
			var inners = $('input.form-control');
			inners[0].value = this.children[0].innerText;
			inners[1].value = this.children[1].innerText;
			inners[2].value = this.children[2].innerText;
			inners[3].value = this.children[3].innerText;
			inners[4].value = this.children[4].innerText;
			var options = $("select.type-selector", form)[0].children;
			var typeBuildId = this.children[5].innerText;
			$("select.type-selector", form)[0].value = 0;
			for (var i = 1; i < options.length; i++) {
				if (options[i].value == typeBuildId)
					$("select.type-selector", form)[0].value = options[i].index;
			}
			$('#exampleModalCenter').modal('show');
		});

		// Приводит форму к первоначальному состоянию
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
});