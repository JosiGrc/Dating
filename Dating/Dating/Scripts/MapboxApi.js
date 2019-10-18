var geocoder = new MapboxGeocoder({ // Initialize the geocoder
    accessToken: mapboxgl.accessToken, // Set the access token
    mapboxgl: mapboxgl, // Set the mapbox-gl instance
    marker: false, // Do not use the default marker style
    placeholder: 'Search for places in the US', // Placeholder text for the search bar
    bbox: [0, 0, 0], // Boundary for Berkeley
    proximity: {
        longitude: x, x
        latitude: " "
    } 
});