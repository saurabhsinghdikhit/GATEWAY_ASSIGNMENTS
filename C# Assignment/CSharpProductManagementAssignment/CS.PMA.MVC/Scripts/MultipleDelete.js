function buttonPopup() {
    var elements = document.getElementsByName('deleteCheckBox');
    var btn = document.getElementById("deleteButton");
    var selected = [];
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].checked) {
            selected.push(elements[i].value);
        }
    }
    if (selected.length == 0) {

        btn.style.display = "none";
    } else {
        document.getElementById("selectionTotal").innerHTML = selected.length;
        btn.style.display = "block";
    }
}