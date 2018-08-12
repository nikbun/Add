$(document).ready(function () {
	//$(function () {

		var form = $("form#form1");

		// Добавляет слушатель на строку таблицы и открывает окно редактирования
		$(".edit-address").on("dblclick", function (eventObject) {
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
			for (var i = 1; i < options.length; i++)
			{
				if (options[i].value == typeBuildId)
					$("select.type-selector", form)[0].value = options[i].index;
			}
			$('#exampleModalCenter').modal('show');
		});
	//})
});