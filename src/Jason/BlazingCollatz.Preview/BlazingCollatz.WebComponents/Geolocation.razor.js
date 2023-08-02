export function getGeolocation(instance) {
    // https://developer.mozilla.org/en-US/docs/Web/API/Geolocation/getCurrentPosition
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition((position) => {
            instance.invokeMethodAsync('Change',
                position.coords.latitude, position.coords.longitude, position.coords.accuracy);
        });
    }
}