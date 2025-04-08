// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = 'api/employeeresumes';

async function addResume() {
    const addDate = document.getElementById('date');
    const addAmount = document.getElementById('amount');
    const addDescription = document.getElementById('description');
    const addReceipt = document.getElementById('receipt');
    const addSuccess = document.getElementById('success');

    const receipt = {
        EmployeeID: 1,
        Date: addDate.value.trim(),
        Amount: addAmount.value.trim(),
        Description: addDescription.value.trim(),
        Receipt: addReceipt.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(receipt)
    })
        .then(response => response.json())
        .then(() => {
            success.value = 'Receipt successfully uploaded';
        })
        .catch(error => success.value = 'Receipt successfully uploaded');
}
