$(document).ready(function () {
	$(function () {

		var form = $("form#form1");

		// Добавляет слушатель на строку таблицы и открывает окно редактирования
		(".edit-address").on("dblclick", function (eventObject) {
			$("#exampleModalLongTitle", form).get(0).innerText = "Редактирование записи";
			var inners = $('input.form-control');
			inners[0].value = this.children[0].innerText;
			inners[1].value = this.children[1].innerText;
			inners[2].value = this.children[2].innerText;
			inners[3].value = this.children[3].innerText;
			inners[4].value = this.children[4].innerText;
			$("select.form-control")[0].selectedIndex = this.children[5].innerText + 1;
			$('#exampleModalCenter').modal('show');
		});
	})
});