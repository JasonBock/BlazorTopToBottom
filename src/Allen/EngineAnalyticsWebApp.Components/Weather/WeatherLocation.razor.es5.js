// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

"use strict";

Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.showPrompt = showPrompt;
exports.showAlert = showAlert;
exports.useCurrentGeolocationAsync = useCurrentGeolocationAsync;

function showPrompt(message) {
    return prompt(message, 'Type anything here');
}

function showAlert(message) {
    return alert(message);
}

function useCurrentGeolocationAsync() {
    var location, pos;
    return regeneratorRuntime.async(function useCurrentGeolocationAsync$(context$1$0) {
        while (1) switch (context$1$0.prev = context$1$0.next) {
            case 0:
                location = { latitude: null, longitude: null };
                pos = new Promise(function (success, error) {
                    if (!navigator.geolocation) {
                        reject("Geolocation is not supported by your browser");
                    } else {
                        // 10000 (milliseconds) represents the maximum length of time the device is allowed to take in order to return a position (or calls error)
                        navigator.geolocation.getCurrentPosition(success, error, { timeout: 10000 });
                    }
                });
                context$1$0.next = 4;
                return regeneratorRuntime.awrap(pos.then(function (position) {
                    console.log(position);
                    location.latitude = position.coords.latitude;
                    location.longitude = position.coords.longitude;
                })["catch"](function (error) {
                    alert("Could not obtain geolocation access. Error: " + error);
                }));

            case 4:
                return context$1$0.abrupt("return", location);

            case 5:
            case "end":
                return context$1$0.stop();
        }
    }, null, this);
}

// Ensure to either massage the return or create an object that will serialize to it's C# counterpart same/same'

