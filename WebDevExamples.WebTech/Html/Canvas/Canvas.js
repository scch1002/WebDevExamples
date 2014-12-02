var webDevExamples = webDevExamples || {};
webDevExamples.html = webDevExamples.html || {};
webDevExamples.html.canvas = webDevExamples.html.canvas || {};

(function () {
    var canvas = this;

    canvas.drawball = function (canvasContext, x, y, radius, HexColor) {
        canvasContext.fillStyle = HexColor;
        canvasContext.beginPath();
        canvasContext.arc(x, y, radius, 0, Math.PI * 2, true);
        canvasContext.fill();
    };

    canvas.paintDrops = function (canvasContext, canvasWidth, canvasHeight, maxRadius) {
        setInterval(function () {
            var y = Math.floor(Math.random() * (canvasHeight - 0)) + 0;
            var x = Math.floor(Math.random() * (canvasWidth - 0)) + 0;
            var radius = Math.floor(Math.random() * (maxRadius - 1)) + 1;
            var hexColor = '#'+(Math.random()*0xFFFFFF<<0).toString(16);

            canvas.drawball(canvasContext, x, y, radius, hexColor);
        }, 1000);
    };

    canvas.resizeCanvas = function () {
        var canvasExample = $('#canvasExample')[0];
        var canvasContainer = $('#canvasContainer')[0];

        canvasExample.width = canvasContainer.clientWidth;
        canvasExample.height = canvasContainer.clientHeight;
    };

    canvas.init = function () {
        var canvasExample = document.getElementById('canvasExample');
        if (canvasExample.getContext) {
            var canvasContext = canvasExample.getContext('2d');
            canvas.paintDrops(canvasContext, 500, 500, 50);
            $(window).on('resize', canvas.resizeCanvas);
            canvas.resizeCanvas();
        }
    };

}).call(webDevExamples.html.canvas);

$(document).ready(function () {
    webDevExamples.html.canvas.init();
});