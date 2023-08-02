export function updateChart(element, data, labels) {
    var chart = new Chart(element, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Values',
                data: data,
            }]
        },
        options: {
            responsive: false
        }
    });
}