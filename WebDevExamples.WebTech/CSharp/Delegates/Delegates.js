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

    delegates.hello = function (hello) {
        $('#basicDelegate').append(delegates.constructListItem(hello));
    };

    delegates.init = function () {
        var broadcaster = $.connection.delegatesHub
        broadcaster.client.hello = delegates.hello;
        $.connection.hub.start().done(function () {
            $('#BasicDelegateButton').click(function () {
                broadcaster.server.hello();
            });
            broadcaster.server.hello();
        });
    };

}).call(webDevExamples.CSharp.Delegates);

$(document).ready(function () {
    webDevExamples.CSharp.Delegates.init();
});