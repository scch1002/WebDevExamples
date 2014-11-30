(function () {
    'use strict'

    var workerStarted = false;
    
    function compute (maxIteration) {
        var value = 0;
        
        for (var count = 0; count < maxIteration; count++) {
            value = value + Math.pow(count, 2);
        }
        
        postMessage(value);
    };
    
    addEventListener('message', function (maxIteration) {
        if (workerStarted === false) {
            workerStarted = true;
            compute(maxIteration.data);
        }
    });
})();