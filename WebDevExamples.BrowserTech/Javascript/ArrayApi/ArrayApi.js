var webDevExamples = webDevExamples || {};
webDevExamples.javascript = webDevExamples.javascript || {};
webDevExamples.javascript.arrayapi = webDevExamples.javascript.arrayapi || {};

(function () {
    var arrayapi = this;

    var exampleArray = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10'];
    
    arrayapi.popItem = function (event) {
        var value = exampleArray.pop();
        arrayapi.showReturnValueModal(value);
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.pushItem = function (event) {
        value = $('#pushValue').val();
        var value = exampleArray.push(value);
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.reverseItems = function (event) {
        exampleArray.reverse();
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.shiftItem = function (event) {
        var value = exampleArray.shift();
        arrayapi.showReturnValueModal(value);
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.unshiftItem = function (event) {
        value = $('#unShiftValue').val();
        var value = exampleArray.unshift(value);
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.sortItems = function (event) {
        exampleArray.sort();
        arrayapi.clearArrayDisplay();
        arrayapi.populateArrayDisplay();
    };

    arrayapi.showReturnValueModal = function (value) {
        $('#modalBody').text(value);
        $('#returnedValueModal').modal('show');
    };

    arrayapi.populateArrayDisplay = function () {
        var arrayExampleDisplay = $('#arrayExampleDisplay')[0];
        exampleArray.forEach(function (value, index, array) {
            arrayExampleDisplay.appendChild(arrayapi.constructArrayItemDisplay(index, value));
        });
    };

    arrayapi.clearArrayDisplay = function () {
        arrayExampleDisplay.innerHTML = '';
    };

    arrayapi.constructArrayItemDisplay = function (index, item) {
        var row = document.createElement('tr');
        var itemIndexColumn = document.createElement('td');
        var itemColumn = document.createElement('td');
        itemIndexColumn.innerHTML = index;
        itemColumn.innerHTML = item;
        row.appendChild(itemIndexColumn);
        row.appendChild(itemColumn);
        return row;
    };

    arrayapi.init = function () {
        arrayapi.populateArrayDisplay();
        $('#popItem').click(arrayapi.popItem);
        $('#pushItem').click(arrayapi.pushItem);
        $('#reverseItems').click(arrayapi.reverseItems);
        $('#shiftItem').click(arrayapi.shiftItem);
        $('#unshiftItem').click(arrayapi.unshiftItem);
        $('#sortItems').click(arrayapi.sortItems);
    };

}).call(webDevExamples.javascript.arrayapi);

$(document).ready(function () {
    webDevExamples.javascript.arrayapi.init();
});