$(document).ready(function () {
    $(".edit-address").dblclick(function (eventObject) {
        $("#exampleModalLongTitle")[0].innerHTML = "Редактирование записи";
        var inners = $('input.form-control');
        inners[0].value = this.children[0].innerText;
        inners[1].value = this.children[1].innerText;
        inners[2].value = this.children[2].innerText;
        inners[3].value = this.children[3].innerText;
        inners[4].value = this.children[4].innerText;
        inners[5].value = this.children[5].innerText;
        $('#exampleModalCenter').modal('show');
    });
});