var webDevExamples = webDevExamples || {};
webDevExamples.javascript = webDevExamples.javascript || {};
webDevExamples.javascript.webstorage = webDevExamples.javascript.webstorage || {};

(function () {
    var webstorage = this;

    webstorage.saveValueLocalStorage = function (event) {
        event.preventDefault();
        var key = $(event.currentTarget).find('#key').val();
        var value = $(event.currentTarget).find('#value').val();
        localStorage.setItem(key, value);
        webstorage.displayLocalStorage();
    };

    webstorage.deleteValueLocalStorage = function (event) {
        var key = $(event.currentTarget)
            .parent()
            .prev()
            .prev()
            .text();
        localStorage.removeItem(key);
        webstorage.displayLocalStorage();
    };

    webstorage.saveValueSessionStorage = function (event) {
        event.preventDefault();
        var key = $(event.currentTarget).find('#key').val();
        var value = $(event.currentTarget).find('#value').val();
        sessionStorage.setItem(key, value);
        webstorage.displaySessionStorage();
    };

    webstorage.deleteValueSessionStorage = function (event) {
        var key = $(event.currentTarget)
            .parent()
            .prev()
            .prev()
            .text();
        sessionStorage.removeItem(key);
        webstorage.displaySessionStorage();
    };

    webstorage.displayLocalStorage = function () {
        var storageTable = $('#LocalStorageDisplay')[0];
        
        storageTable.innerHTML = '';

        var localStorageCount = localStorage.length;

        for (var index = 0; index < localStorageCount; index++) {
            var key = localStorage.key(index);
            var value = localStorage.getItem(key);
            var row = webstorage.constructItemRow(key, value);
            storageTable.appendChild(row);
        }

        $(storageTable).find('.deleteOption').click(webstorage.deleteValueLocalStorage);
    };

    webstorage.displaySessionStorage = function () {
        var storageTable = $('#SessionStorageDisplay')[0];

        storageTable.innerHTML = '';

        var localStorageCount = sessionStorage.length;

        for (var index = 0; index < localStorageCount; index++) {
            var key = sessionStorage.key(index);
            var value = sessionStorage.getItem(key);
            var row = webstorage.constructItemRow(key, value);
            storageTable.appendChild(row);
        }

        $(storageTable).find('.deleteOption').click(webstorage.deleteValueSessionStorage);
    };

    webstorage.constructItemRow = function (key, value) {
        var row = document.createElement('tr');
        var keyColumn = document.createElement('td');
        var valueColumn = document.createElement('td');
        var optionColumn = document.createElement('td');
        var deleteOption = document.createElement('input');
        deleteOption.type = 'button';
        deleteOption.classList.add('btn');
        deleteOption.classList.add('btn-danger');
        deleteOption.classList.add('deleteOption');
        deleteOption.value = 'Delete';
        keyColumn.innerHTML = key;
        valueColumn.innerHTML = value;
        optionColumn.appendChild(deleteOption);
        row.appendChild(keyColumn);
        row.appendChild(valueColumn);
        row.appendChild(optionColumn);
        return row;
    };

    webstorage.init = function () {
        webstorage.displayLocalStorage();
        webstorage.displaySessionStorage();
        $('#LocalStorageForm').submit(webstorage.saveValueLocalStorage);
        $('#SessionStorageForm').submit(webstorage.saveValueSessionStorage);
    };

}).call(webDevExamples.javascript.webstorage);

$(document).ready(function () {
    webDevExamples.javascript.webstorage.init();
});