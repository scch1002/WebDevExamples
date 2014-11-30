var webDevExamples = webDevExamples || {};
webDevExamples.javascript = webDevExamples.javascript || {};
webDevExamples.javascript.geolocation = webDevExamples.javascript.geolocation || {};

(function () {
    var geolocation = this;

    var trackingId = 0;

    geolocation.getCurrentLocation = function (event) {
        navigator.geolocation.getCurrentPosition(function (position) {
            $('#getCurrentLocationlatitude').text(position.coords.latitude);
            $('#getCurrentLocationlongitude').text(position.coords.longitude);
        });
    };

    geolocation.trackLocation = function (event) {
        trackingId = navigator.geolocation.watchPosition(function (position) {
            $('#trackLocationlatitude').text(position.coords.latitude);
            $('#trackLocationlongitude').text(position.coords.longitude);
        });
        $('#stopTrackingCurrentLocation').prop('disabled', false);
        $('#trackCurrentLocation').prop('disabled', true);
    };

    geolocation.stopTrackingLocation = function (event) {
        navigator.geolocation.clearWatch(trackingId);
        $('#stopTrackingCurrentLocation').prop('disabled', true);
        $('#trackCurrentLocation').prop('disabled', false);
    };

    geolocation.init = function () {
        if ('geolocation' in navigator) {
            $('#getCurrentLocation').click(geolocation.getCurrentLocation);
            $('#trackCurrentLocation').click(geolocation.trackLocation);
            $('#stopTrackingCurrentLocation').click(geolocation.stopTrackingLocation);
        } else {
            $('main').addClass('hidden');
            $('#geolocationNotAvailable').removeClass('hidden');
        }
    };

}).call(webDevExamples.javascript.geolocation);

$(document).ready(function () {
    webDevExamples.javascript.geolocation.init();
});