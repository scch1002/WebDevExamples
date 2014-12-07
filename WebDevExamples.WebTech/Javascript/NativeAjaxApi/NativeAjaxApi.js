var webDevExamples = webDevExamples || {};
webDevExamples.javascript = webDevExamples.javascript || {};
webDevExamples.javascript.nativeAjaxApi = webDevExamples.javascript.nativeAjaxApi || {};

(function () {
    nativeAjaxApi = this;

    nativeAjaxApi.constructResultItemBlock = function (text) {
        var div = document.createElement('div');
        div.classList.add('list-group-item');
        div.innerHTML = text;
        return div;
    }

    nativeAjaxApi.exampleWebService = function (action, text, ajaxProcessFunction) {
        var request = new XMLHttpRequest();
        request.onreadystatechange = function () {
            try {
                if (request.readyState === 4) {
                    if (request.status === 200) {
                        ajaxProcessFunction(JSON.parse(request.responseText));
                    }
                    else {
                        alert('The request to the server failed with http code ' + request.status + '.')
                    }
                }
            }
            catch (exception) {
                alert('There was an exception during the request.');
            }
        };
        request.open(action, '../../api/Examples');
        request.responseType = "json";
        request.send(text);
    }

    nativeAjaxApi.processExampleRequest = function(event, action, text) {
        nativeAjaxApi.exampleWebService(action, text, function (example) {
            var resultDisplay = $(event.target).find('.resultOutput');
            resultDisplay.empty();
            example.forEach(function (value, index, array) {
                resultDisplay.append(nativeAjaxApi.constructResultItemBlock(value));
            });
        });
    };

    nativeAjaxApi.getSubmitExample = function (event) {
        event.preventDefault();
        nativeAjaxApi.processExampleRequest(event, 'GET', '');
    };

    nativeAjaxApi.postSubmitExample = function (event) {
        event.preventDefault();
        var text = $(event.target).find('#postInput').val();
        nativeAjaxApi.processExampleRequest(event, 'POST', text);
    };

    nativeAjaxApi.putSubmitExample = function (event) {
        event.preventDefault();
        var text = $(event.target).find('#putInput').val();
        nativeAjaxApi.processExampleRequest(event, 'PUT', text);
    };

    nativeAjaxApi.deleteSubmitExample = function (event) {
        event.preventDefault();
        var text = $(event.target).find('#deleteInput').val();
        nativeAjaxApi.processExampleRequest(event, 'DELETE', text);
    };

    nativeAjaxApi.resetExample = function (event) {
        $(event.target)
            .parent()
            .parent()
            .find('.resultOutput')
            .empty()
            .append('No Result');
    };

    nativeAjaxApi.init = function () {
        $('#getExample').submit(nativeAjaxApi.getSubmitExample);
        $('#postExample').submit(nativeAjaxApi.postSubmitExample);
        $('#putExample').submit(nativeAjaxApi.putSubmitExample);
        $('#deleteExample').submit(nativeAjaxApi.deleteSubmitExample);
        $('.resetExample').click(nativeAjaxApi.resetExample);
    };

}).call(webDevExamples.javascript.nativeAjaxApi);

$(document).ready(function () {
    webDevExamples.javascript.nativeAjaxApi.init();
});