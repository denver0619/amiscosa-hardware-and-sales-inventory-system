document.addEventListener('DOMContentLoaded', function () {
    var editButtons = document.querySelectorAll('.edit-product');
    //var editPopup = document.getElementById('editPopup');


    editButtons.forEach(function (editButtons) {
        editButtons.addEventListener('click', function (e) {

            var row = e.target.closest('tr'); // Find the closest row (tr)

            // get data
            var productID = row.querySelectorAll('td')[0].textContent;
            var productName = row.querySelectorAll('td')[1].textContent;
            var productQuantity = row.querySelectorAll('td')[2].textContent;
            var productUnitCost = row.querySelectorAll('td')[3].textContent;
            var productUnitPrice = row.querySelectorAll('td')[4].textContent;
            var productMeasurement = row.querySelectorAll('td')[5].textContent;
            var productManufacturer = row.querySelectorAll('td')[6].textContent;


            // Create the edit pop-up elements
            var editPopupOverlay = document.createElement('div');
            // editPopupOverlay.classList.add('editFormContainer');
            editPopupOverlay.id = 'editPopupOverlay';
            editPopupOverlay.innerHTML = `
                <div id="editPopup">
                    <button id="exitEdit">X</button>
                    <h1>Product Details</h1>
                    <p>ID: ${productID}</p>
                    <form id="editFormContainer">
                    
                        <div class="form-row">
                            <label for="productName">Name:</label>
                            <input type="text" id="productName" name="productName" value="${productName}" />
                        </div>
                    
                        <div class="form-row">
                            <label for="productQuantity">Quantity:</label>
                            <label for="productUnitCost">Unit Cost:</label>
                            <label for="productUnitPrice">Unit Price:</label>
                    
                            <input type="text" id="productQuantity" name="productQuantity" value="${productQuantity}" />
                            <input type="text" id="productUnitCost" name="productUnitCost" value="${productUnitCost}" />
                            <input type="text" id="productUnitPrice" name="productUnitPrice" value="${productUnitPrice}" />
                        </div>
                    
                        <div class="form-row">
                            <label for="productMeasurement">Measurement:</label>
                            <label for="productManufacturer">Manufacturer:</label>
                    
                            <input type="text" id="productMeasurement" name="productMeasurement" value="${productMeasurement}" />
                            <input type="text" id="productManufacturer" name="productManufacturer" value="${productManufacturer}" />
                        </div>
                    
                        <div class="form-row">
                            <button id="submitEdit">Submit</button>
                        </div>
                    </form>
                </div>
            `;


            document.body.append(editPopupOverlay);


            // Handle edit submission
            document.getElementById('submitEdit').addEventListener('click', function () {
                // Perform actions to update data using AJAX or other methods

                // Create an object with the updated product data
                var updatedProductData = {
                    productID: productID,
                    productName: document.getElementById('productName').value,
                    productQuantity: document.getElementById('productQuantity').value,
                    productUnitCost: document.getElementById('productUnitCost').value,
                    productUnitPrice: document.getElementById('productUnitPrice').value,
                    productMeasurement: document.getElementById('productMeasurement').value,
                    productManufacturer: document.getElementById('productManufacturer').value
                };

                console.log(updatedProductData);

                // After submitting, remove the edit pop-up
                editPopupOverlay.remove();
            });

            // Handle exit from edit
            document.getElementById('exitEdit').addEventListener('click', function () {
                // Remove the edit pop-up without submitting
                editPopupOverlay.remove();
            });
        })

    })
})