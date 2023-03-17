// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}

export function useCurrentGeolocation() {
    navigator.geolocation.getCurrentPosition((position) => {
        return position;
    }, (error) => {
        alert('User does not allow geolocation access');
        // Denotes the maximum length of time that is allowed to pass from the call to 
        // getCurrentPosition() or watchPosition() until the corresponding successCallback is invoked
    }, { timeout: 10000 })
}
