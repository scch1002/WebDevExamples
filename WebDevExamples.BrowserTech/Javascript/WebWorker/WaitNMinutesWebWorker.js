(function () {
    'use strict'

    var workerStarted = false;

    function main(minutes, intervalSeconds) {
        
        var runningTime = 0;

        postMessage('The thread as started.');

        setInterval(function () {

            runningTime = runningTime + intervalSeconds;

            if (minutes * 60 <= runningTime) {
                postMessage('The thread as stopped at ' + runningTime + ' seconds.');
                self.close();
            }
            else
            {
                postMessage('The thread as been running for ' + runningTime + ' seconds.');
            }

        }, intervalSeconds * 1000);
    };

    addEventListener('message', function (minutes) {
        if (workerStarted === false) {
            workerStarted = true;
            var data = JSON.parse(minutes.data);
            main(data.minutes, data.intervalSeconds);
        }
    });
})();