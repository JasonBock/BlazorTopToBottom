// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt2(message) {
    return prompt(message, 'Type anything here');
}

export function useCurrentGeolocation() {
    
        navigator.geolocation.getCurrentPosition((position) => {
            console.log(position);
            return position.coords.latitude;
        }, (error) => {
            alert('User does not allow geolocation access');
            // Denotes the maximum length of time that is allowed to pass from the call to 
            // getCurrentPosition() or watchPosition() until the corresponding successCallback is invoked
        }, { timeout: 10000 })
    }

export async function useCurrentGeolocationAsync() {
    var result = { latitude: null, longitude: null };
    const pos = new Promise((success, error) => {
        if (!navigator.geolocation) {
            reject("Geolocation is not supported by your browser");
        } else {
            navigator.geolocation.getCurrentPosition(success, error);
        }
    });

    await pos.then(
        (position) => {
            console.log(position);
             //Geolocation.mapPositionToResult(position, result)
                result.latitude = position.coords.latitude;
                result.longitude = position.coords.longitude;
            }
        ).catch(
            (error) => { Geolocation.mapErrorToResult(error, result) }
        );

        //navigator.geolocation.getCurrentPosition((position) => {
        //    console.log(position);
        //    latString = position.coords.latitude;
        //}, (error) => {
        //    alert('User does not allow geolocation access');
        //    // Denotes the maximum length of time that is allowed to pass from the call to 
        //    // getCurrentPosition() or watchPosition() until the corresponding successCallback is invoked
        //}, { timeout: 10000 })
    return result;
}

export let Geolocation = {

    getCurrentPosition: async function (options) {
        var result = { position: null, error: null };
        var getCurrentPositionPromise = new Promise((resolve, reject) => {
            if (!navigator.geolocation) {
                reject({ code: 0, message: 'This device does not support geolocation.' });
            } else {
                navigator.geolocation.getCurrentPosition(resolve, reject, options);
            }
        });
        await getCurrentPositionPromise.then(
            (position) => {
                console.log(position);
                this.mapPositionToResult(position, result)
            }
        ).catch(
            (error) => { this.mapErrorToResult(error, result) }
        );
        return result;
    },

    mapPositionToResult: function (position, result) {
        result.position = {
            coords: {
                latitude: position.coords.latitude,
                longitude: position.coords.longitude,
                altitude: position.coords.altitude,
                accuracy: position.coords.accuracy,
                altitudeAccuracy: position.coords.altitudeAccuracy,
                heading: position.coords.heading,
                speed: position.coords.speed
            },
            timestamp: position.timestamp
        }
    },

    mapErrorToResult: function (error, result) {
        result.error = {
            code: error.code,
            message: error.message
        }
    }

}