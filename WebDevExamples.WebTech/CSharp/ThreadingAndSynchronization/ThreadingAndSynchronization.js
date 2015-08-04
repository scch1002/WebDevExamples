var webDevExamples = webDevExamples || {};
webDevExamples.CSharp = webDevExamples.CSharp || {};
webDevExamples.CSharp.ThreadingAndSynchronization = webDevExamples.CSharp.ThreadingAndSynchronization || {};

(function () {
    var threadingAndSynchronization = this;

    threadingAndSynchronization.constructListItem = function (text) {
        var div = document.createElement('div');
        div.innerHTML = text;
        div.classList.add('list-group-item');
        return div;
    };

    threadingAndSynchronization.simpleThreadingExample = function (response) {
        $('#simpleThreadingExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadStaticExample = function (response) {
        $('#threadStaticExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadLocalTExample = function (response) {
        $('#threadLocalTExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadLocalStorageExample = function (response) {
        $('#threadLocalStorageExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadPoolQueueWorkItemExample = function (response) {
        $('#threadPoolQueueWorkItemExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadSynchronizationUsingMonitorExample = function (response) {
        $('#threadSynchronizationUsingMonitorExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadSynchronizationUsingMutexExample = function (response) {
        $('#threadSynchronizationUsingMutexExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadSynchronizationUsingSemaphoreExample = function (response) {
        $('#threadSynchronizationUsingSemaphoreExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.threadSynchronizationUsingManualResetEventExample = function (response) {
        $('#threadSynchronizationUsingManualResetEventExample').append(threadingAndSynchronization.constructListItem(response));
    };

    threadingAndSynchronization.init = function () {
        var broadcaster = $.connection.threadingAndSynchronizationHub;
        broadcaster.client.simpleThreadingExample = threadingAndSynchronization.simpleThreadingExample;
        broadcaster.client.threadStaticExample = threadingAndSynchronization.threadStaticExample;
        broadcaster.client.threadLocalTExample = threadingAndSynchronization.threadLocalTExample;
        broadcaster.client.threadLocalStorageExample = threadingAndSynchronization.threadLocalStorageExample;
        broadcaster.client.threadPoolQueueWorkItemExample = threadingAndSynchronization.threadPoolQueueWorkItemExample;
        broadcaster.client.threadSynchronizationUsingMonitorExample = threadingAndSynchronization.threadSynchronizationUsingMonitorExample;
        broadcaster.client.threadSynchronizationUsingMutexExample = threadingAndSynchronization.threadSynchronizationUsingMutexExample;
        broadcaster.client.threadSynchronizationUsingSemaphoreExample = threadingAndSynchronization.threadSynchronizationUsingSemaphoreExample;
        broadcaster.client.threadSynchronizationUsingManualResetEventExample = threadingAndSynchronization.threadSynchronizationUsingManualResetEventExample;
        $.connection.hub.start().done(function () {
            $('#simpleThreadingExampleButton').click(function () {
                broadcaster.server.simpleThreadingExample();
            });
            $('#threadStaticExampleButton').click(function () {
                broadcaster.server.threadStaticExample();
            });
            $('#threadLocalTExampleButton').click(function () {
                broadcaster.server.threadLocalTExample();
            });
            $('#threadLocalStorageExampleButton').click(function () {
                broadcaster.server.threadLocalStorageExample();
            });
            $('#threadPoolQueueWorkItemExampleButton').click(function () {
                broadcaster.server.threadPoolQueueWorkItemExample();
            });
            $('#threadSynchronizationUsingMonitorExampleButton').click(function () {
                broadcaster.server.threadSynchronizationUsingMonitorExample();
            });
            $('#threadSynchronizationUsingMutexExampleButton').click(function () {
                broadcaster.server.threadSynchronizationUsingMutexExample();
            });
            $('#threadSynchronizationUsingSemaphoreExampleButton').click(function () {
                broadcaster.server.threadSynchronizationUsingSemaphoreExample();
            });
            $('#threadSynchronizationUsingManualResetEventExampleButton').click(function () {
                broadcaster.server.threadSynchronizationUsingManualResetEventExample();
            });
        });
    };

}).call(webDevExamples.CSharp.ThreadingAndSynchronization);

$(document).ready(function () {
    webDevExamples.CSharp.ThreadingAndSynchronization.init();
});