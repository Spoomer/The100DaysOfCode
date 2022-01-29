// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function fetchPutFormData(url, dataObj) {
    let formData = new FormData();
    for (const [key, value] of Object.entries(dataObj)) {
        formData.append(key, value);
    }
    fetch(url, { method: "PUT", body: formData })
        .then(response => {
            if (!response.ok) {
                alert("Error: " + response.status + " " + response.statusText);
            }
        })
        .catch(error => {
            alert(error);
        });
}

function fetchPostFormData(url, dataObj) {
    let formData = new FormData();
    for (const [key, value] of Object.entries(dataObj)) {
        formData.append(key, value);
    }
    fetch(url, { method: "POST", body: formData })
        .then(response => {
            if (!response.ok) {
                alert("Error: " + response.status + " " + response.statusText);
            }
        })
        .catch(error => {
            alert(error);
        });
}