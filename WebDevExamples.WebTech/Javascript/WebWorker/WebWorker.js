var webDevExamples = webDevExamples || {};
webDevExamples.javascript = webDevExamples.javascript || {};
webDevExamples.javascript.webWorker = webDevExamples.javascript.webWorker || {};

(function () {
    var webWorker = this;

    webWorker.addN2WebWorker = function (event) {
        var worker = new Worker('N2WebWorker.js');
        webWorker.addWebWorkerDisplay(worker, 'N^2');
        worker.postMessage(1000000);
    }

    webWorker.addNNWebWorker = function (event) {
        var worker = new Worker('NNWebWorker.js');
        webWorker.addWebWorkerDisplay(worker, 'N^N');
        worker.postMessage(1000000);
    }

    webWorker.add5Minutesat30secondsWebWorker = function (event) {
        var worker = new Worker('WaitNMinutesWebWorker.js');
        webWorker.addWebWorkerDisplay(worker, 'Wait 5 Minutes And Message Every 30 Secounds');
        var data = {};
        data.minutes = 5;
        data.intervalSeconds = 30;
        worker.postMessage(JSON.stringify(data));
    }

    webWorker.add5Minutesat10secondsWebWorker = function (event) {
        var worker = new Worker('WaitNMinutesWebWorker.js');
        webWorker.addWebWorkerDisplay(worker, 'Wait 5 Minutes And Message Every 10 Secounds');
        var data = {};
        data.minutes = 5;
        data.intervalSeconds = 10;
        worker.postMessage(JSON.stringify(data));
    }

    webWorker.addWebWorkerDisplay = function (worker, webWorkerType) {

        var webWorkerNumber = $('#webWorkerList').find('tr').length + 1;

        var row = webWorker.constructResultRow(worker, webWorkerNumber, webWorkerType);
      
        $('#webWorkerList')[0].appendChild(row);
    };

    webWorker.constructResultRow = function (worker, webWorkerNumber, webWorkerType) {
        var row = document.createElement('tr');
        var webWorkerNumberColumn = document.createElement('td');
        var webWorkerTypeColumn = document.createElement('td');
        var webWorkerResultColumn = document.createElement('td');
        webWorkerNumberColumn.innerHTML = webWorkerNumber;
        webWorkerTypeColumn.innerHTML = webWorkerType;
        row.appendChild(webWorkerNumberColumn);
        row.appendChild(webWorkerTypeColumn);
        row.appendChild(webWorkerResultColumn);
        worker.addEventListener('message', function (result) {
            webWorkerResultColumn.innerHTML = result.data;
        });
        return row;
    };

    webWorker.init = function () {
        $('#addN2WebWorker').click(webWorker.addN2WebWorker);
        $('#addNNWebWorker').click(webWorker.addNNWebWorker);
        $('#add5MinutesAt30SecoundWebWorker').click(webWorker.add5Minutesat30secondsWebWorker);
        $('#add5MinutesAt10SecoundWebWorker').click(webWorker.add5Minutesat10secondsWebWorker);
    };

}).call(webDevExamples.javascript.webWorker);

$(document).ready(function () {
    webDevExamples.javascript.webWorker.init();
});