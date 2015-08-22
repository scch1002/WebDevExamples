var webDevExamples = webDevExamples || {};
webDevExamples.CSharp = webDevExamples.CSharp || {};
webDevExamples.CSharp.TaskParallelismAndDataParallelism = webDevExamples.CSharp.TaskParallelismAndDataParallelism || {};

(function () {
    var taskParallelismAndDataParallelism = this;

    taskParallelismAndDataParallelism.constructListItem = function (text) {
        var div = document.createElement('div');
        div.innerHTML = text;
        div.classList.add('list-group-item');
        return div;
    };

    taskParallelismAndDataParallelism.simpleTaskExample = function (response) {
        $('#simpleTaskExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.taskFactoryExample = function (response) {
        $('#taskFactoryExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.taskRunExample = function (response) {
        $('#taskRunExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.init = function () {
        var broadcaster = $.connection.taskParallelismAndDataParallelismHub;
        broadcaster.client.simpleTaskExample = taskParallelismAndDataParallelism.simpleTaskExample;
        broadcaster.client.taskFactoryExample = taskParallelismAndDataParallelism.taskFactoryExample;
        broadcaster.client.taskRunExample = taskParallelismAndDataParallelism.taskRunExample;
        $.connection.hub.start().done(function () {
            $('#simpleTaskExampleButton').click(function () {
                broadcaster.server.simpleTaskExample();
            });
            $('#taskFactoryExampleButton').click(function () {
                broadcaster.server.taskFactoryExample();
            });
            $('#taskRunExampleButton').click(function () {
                broadcaster.server.taskRunExample();
            });
        });
    };

}).call(webDevExamples.CSharp.TaskParallelismAndDataParallelism);

$(document).ready(function () {
    webDevExamples.CSharp.TaskParallelismAndDataParallelism.init();
});