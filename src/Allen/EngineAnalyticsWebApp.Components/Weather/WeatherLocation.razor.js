// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
    return prompt(message, 'Type anything here');
}

export function showAlert(message) {
    return alert(message);
}

export async function useCurrentGeolocationAsync() {
    // Ensure to either massage the return or create an object that will serialize to it's C# counterpart same/same'
    var location = { latitude: null, longitude: null };

    const pos = new Promise((success, error) => {
        if (!navigator.geolocation) {
            reject("Geolocation is not supported by your browser");
        } else {
            // 10000 (milliseconds) represents the maximum length of time the device is allowed to take in order to return a position (or calls error)
            navigator.geolocation.getCurrentPosition(success, error, { timeout: 10000 });
        }
    });

    await pos.then(
        (position) => {
            console.log(position);
            location.latitude = position.coords.latitude;
            location.longitude = position.coords.longitude;
        }
    ).catch(
        (error) => {
            alert(`Could not obtain geolocation access. Error: ${error}`);
        }
    );

    return location;
}