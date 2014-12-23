var webDevExamples = webDevExamples || {};
webDevExamples.CSharp = webDevExamples.CSharp || {};
webDevExamples.CSharp.Generics = webDevExamples.CSharp.Generics || {};

(function () {
    var Generics = this;

    Generics.constructInputRow = function (inputArrayName, value) {
        var row = document.createElement('tr');
        var valueColumn = document.createElement('td');
        var optionColumn = document.createElement('td');
        var hiddenValue = document.createElement('input');
        var text = document.createTextNode(value);
        hiddenValue.type = 'hidden';
        hiddenValue.name = inputArrayName;
        hiddenValue.value = value;
        var deleteButton = document.createElement('input');
        deleteButton.type = 'button';
        deleteButton.classList.add('btn');
        deleteButton.classList.add('btn-danger');
        deleteButton.classList.add('delete_option');
        deleteButton.value = 'Delete';
        $(deleteButton).click(Generics.deleteValue);
        valueColumn.appendChild(hiddenValue);
        valueColumn.appendChild(text);
        optionColumn.appendChild(deleteButton);
        row.appendChild(valueColumn);
        row.appendChild(optionColumn);
        return row;
    };

    Generics.addValueToArray = function (tbodyId, row) {
        $('#' + tbodyId).append(row);
    };

    Generics.deleteValue = function (event) {
        $(event.target)
            .parent()
            .parent()
            .remove();
    };

    Generics.addValue = function (event) {
        var value = $(event.target).next().val();
        var inputArray = $(event.target).data('inputarray');
        var row = Generics.constructInputRow(inputArray, value);
        Generics.addValueToArray(inputArray, row);
    };

    Generics.resetInput = function () {
        $('#ConcatInput').empty();
        $('#SumInput').empty();
    }
    
    Generics.init = function () {
        $('.delete_option').click(Generics.deleteValue);
        $('.value_add').click(Generics.addValue);
        $('#inputReset').click(Generics.resetInput);
    };

}).call(webDevExamples.CSharp.Generics);

$(document).ready(function () {
    webDevExamples.CSharp.Generics.init();
});