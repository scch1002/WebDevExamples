var webDevExamples = webDevExamples || {};
webDevExamples.html = webDevExamples.html || {};
webDevExamples.html.dragAndDrop = webDevExamples.html.dragAndDrop || {};

(function () {
    var dragAndDrop = this;

    var simpleDragItem;

    dragAndDrop.simpleDragStart = function (event) {
        $(event.target).addClass('active');
        simpleDragItem = $(event.target);
    };

    dragAndDrop.simpleDragEnd = function (event) {
        $(event.target).removeClass('active');
        simpleDragItem = null;
    };

    dragAndDrop.simpleDrop = function (event) {
        simpleDragItem.detach();
        simpleDragItem.appendTo($(event.currentTarget));
    }

    dragAndDrop.fileDrop = function (event) {
        var files = event.dataTransfer.files;
        var fileInfoTable = $('#fileInfo');
        for (var count = 0; count < files.length; count++) {
            var row = dragAndDrop.constructFileInfoRow(files[count].name, files[count].type, files[count].size);
            fileInfoTable.append(row);
        }
    };

    dragAndDrop.constructFileInfoRow = function (name, type, size) {
        var row = document.createElement('tr');
        var nameColumn = document.createElement('td');
        var typeColumn = document.createElement('td');
        var sizeColumn = document.createElement('td');
        nameColumn.innerHTML = name;
        typeColumn.innerHTML = type;
        sizeColumn.innerHTML = size + ' bytes';
        row.appendChild(nameColumn);
        row.appendChild(typeColumn);
        row.appendChild(sizeColumn);
        return row;
    };

    dragAndDrop.init = function () {
        jQuery.event.props.push('dataTransfer');
        $('#simpleItemList1').on('dragstart', dragAndDrop.simpleDragStart);
        $('#simpleItemList1').on('dragend', dragAndDrop.simpleDragEnd);
        $('#simpleItemList1').on('dragenter', function (event) { event.preventDefault(); });
        $('#simpleItemList1').on('dragover', function (event) { event.preventDefault(); });
        $('#simpleItemList1').on('drop', dragAndDrop.simpleDrop);
        $('#simpleItemList2').on('dragstart', dragAndDrop.simpleDragStart);
        $('#simpleItemList2').on('dragend', dragAndDrop.simpleDragEnd);
        $('#simpleItemList2').on('dragenter', function (event) { event.preventDefault(); });
        $('#simpleItemList2').on('dragover', function (event) { event.preventDefault(); });
        $('#simpleItemList2').on('drop', dragAndDrop.simpleDrop);
        $('#fileDropLocation').on('dragenter', function (event) { event.preventDefault(); });
        $('#fileDropLocation').on('dragover', function (event) { event.preventDefault(); });
        $('#fileDropLocation').on('drop', dragAndDrop.fileDrop);
    };

}).call(webDevExamples.html.dragAndDrop);

$(document).ready(function () {
    webDevExamples.html.dragAndDrop.init();
});