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

    threadingAndSynchronization.init = function () {
        var broadcaster = $.connection.threadingAndSynchronizationHub
        broadcaster.client.simpleThreadingExample = threadingAndSynchronization.simpleThreadingExample;
        broadcaster.client.threadStaticExample = threadingAndSynchronization.threadStaticExample;
        broadcaster.client.threadLocalTExample = threadingAndSynchronization.threadLocalTExample;
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
        });
    };

}).call(webDevExamples.CSharp.ThreadingAndSynchronization);

$(document).ready(function () {
    webDevExamples.CSharp.ThreadingAndSynchronization.init();
});