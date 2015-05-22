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

    delegates.init = function () {
        var broadcaster = $.connection.delegatesHub
        broadcaster.client.simpleDelegateExample = delegates.simpleDelegateExample;
        $.connection.hub.start().done(function () {
            $('#BasicDelegateButton').click(function () {
                broadcaster.server.simpleDelegateExample();
            });
        });
    };

}).call(webDevExamples.CSharp.Delegates);

$(document).ready(function () {
    webDevExamples.CSharp.Delegates.init();
});