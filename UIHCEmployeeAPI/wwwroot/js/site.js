// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const uri = 'api/employeereceipts';

async function addReceipt() {

    const addDate = document.getElementById('date');
    const addAmount = document.getElementById('amount');
    const addDescription = document.getElementById('description');
    const addReceipt = document.getElementById('receipt');
    const addSuccess = document.getElementById('success');

    const formData = new FormData();
    formData.append('date', addDate.value.trim());
    formData.append('amount', addAmount.value.trim());
    formData.append('description', addDescription.value.trim());
    formData.append('receiptFile', addReceipt.files[0]);
    formData.append('employeeId', 1);

    //const EmployeeReceipt = {
    //    EmployeeID: 1,
    //    Date: addDate.value.trim(),
    //    Amount: addAmount.value.trim(),
    //    Description: addDescription.value.trim(),
    //};

    fetch(uri, {
        method: 'POST',
        headers: {
            //'Accept': 'application/json',
            //'Content-Type': 'application/json'
        },
        body: formData,
    })
        .then(response => {
            if (response.ok) {
                addSuccess.innerHTML = 'Receipt uploaded successfully;'
            } else {
                addSuccess.innerHTML = 'An error occurred upon receipt submission';
            }
        })        
        .catch(error => addSuccess.innerHTML = 'An error occurred upon receipt submission');
}
