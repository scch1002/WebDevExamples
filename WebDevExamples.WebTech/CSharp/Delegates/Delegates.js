var webDevExamples = webDevExamples || {};
webDevExamples.CSharp = webDevExamples.CSharp || {};
webDevExamples.CSharp.Delegates = webDevExamples.CSharp.Delegates || {};

(function () {
    var delegates = this;

    delegates.constructListItem = function (text) {
        var div = document.createElement('div');
        div.innerHTML = text;
        div.classList.add('list-group-item');
        return div;
    };

    delegates.simpleDelegateExample = function (hello) {
        $('#basicDelegate').append(delegates.constructListItem(hello));
    };

    delegates.asyncDelegateExample = function (message) {
        $('#asyncDelegate').append(delegates.constructListItem(message));
    };

    delegates.init = function () {
        var broadcaster = $.connection.delegatesHub
        broadcaster.client.simpleDelegateExample = delegates.simpleDelegateExample;
        broadcaster.client.asyncDelegateExample = delegates.asyncDelegateExample;
        $.connection.hub.start().done(function () {
            $('#BasicDelegateButton').click(function () {
                broadcaster.server.simpleDelegateExample();
            });
            $('#asyncDelegateButton').click(function () {
                broadcaster.server.asyncDelegateExample();
            });
        });
    };

}).call(webDevExamples.CSharp.Delegates);

$(document).ready(function () {
    webDevExamples.CSharp.Delegates.init();
});