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

    taskParallelismAndDataParallelism.taskRunExample = function (response) {
        $('#taskRunExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.taskExceptionExample = function (response) {
        $('#taskExceptionExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.taskContinuationExample = function (response) {
        $('#taskContinuationExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.taskCancellationExample = function (response) {
        $('#taskCancellationExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.parallelInvokeExample = function (response) {
        $('#parallelInvokeExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.parallelForExample = function (response) {
        $('#parallelForExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.parallelForEachExample = function (response) {
        $('#parallelForEachExample').append(taskParallelismAndDataParallelism.constructListItem(response));
    };

    taskParallelismAndDataParallelism.init = function () {
        var broadcaster = $.connection.taskParallelismAndDataParallelismHub;
        broadcaster.client.simpleTaskExample = taskParallelismAndDataParallelism.simpleTaskExample;
        broadcaster.client.taskFactoryExample = taskParallelismAndDataParallelism.taskFactoryExample;
        broadcaster.client.taskRunExample = taskParallelismAndDataParallelism.taskRunExample;
        broadcaster.client.taskExceptionExample = taskParallelismAndDataParallelism.taskExceptionExample;
        broadcaster.client.taskContinuationExample = taskParallelismAndDataParallelism.taskContinuationExample;
        broadcaster.client.taskCancellationExample = taskParallelismAndDataParallelism.taskCancellationExample;
        broadcaster.client.parallelInvokeExample = taskParallelismAndDataParallelism.parallelInvokeExample
        broadcaster.client.parallelForExample = taskParallelismAndDataParallelism.parallelForExample;
        broadcaster.client.parallelForEachExample = taskParallelismAndDataParallelism.parallelForEachExample;
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
            $('#taskExceptionExampleButton').click(function () {
                broadcaster.server.taskExceptionExample(
                    $('#taskExceptionFailNotHandle')[0].checked,
                    $('#taskExceptionFailHandle')[0].checked);
            });
            $('#taskContinuationExampleButton').click(function () {
                broadcaster.server.taskContinuationExample();
            });
            $('#taskCancellationExampleStartButton').click(function () {
                broadcaster.server.taskCancellationExample();
            });
            $('#taskCancellationExampleEndButton').click(function () {
                broadcaster.server.taskCancellationExampleCancelTasks();
            });
            $('#parallelInvokeExampleButton').click(function () {
                broadcaster.server.parallelInvokeExample();
            });
            $('#parallelForExampleButton').click(function () {
                broadcaster.server.parallelForExample();
            });
            $('#parallelForEachExampleButton').click(function () {
                broadcaster.server.parallelForEachExample();
            });
        });
    };

}).call(webDevExamples.CSharp.TaskParallelismAndDataParallelism);

$(document).ready(function () {
    webDevExamples.CSharp.TaskParallelismAndDataParallelism.init();
});