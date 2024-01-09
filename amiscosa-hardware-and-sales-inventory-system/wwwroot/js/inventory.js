document.addEventListener('DOMContentLoaded', function () {

    var restockItemButton = document.querySelector('.restock-product')
    var addItemButton = document.querySelector('.add-product');
    var editButtons = document.querySelectorAll('.edit-product');

    // RESTOCK ITEM POPUP 
    restockItemButton.addEventListener('click', function (e) {
        var restockItemPopupOverlay = document.createElement('div');

        console.log(1)

        restockItemPopupOverlay.id = 'PopupOverlay';
        restockItemPopupOverlay.innerHTML = `
        <div class="popupCard"  id="restockPopup">
                <button id="exitPopupCard">X</button>
                <h1>Restock Product</h1>

                <form class="popupCardFormContainer">
                    <div class="search-and-filter restock-search">
                        <div>
                            <label>Product Name</label>
                            <fieldset class="search-bar search-field medium">
                            <label for="search-input" id="search-icon">
                                <a href="">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 14 14" fill="none">
                                        <g clip-path="url(#clip0_11_108)">
                                            <path d="M6 11.5C9.03757 11.5 11.5 9.03757 11.5 6C11.5 2.96243 9.03757 0.5 6 0.5C2.96243 0.5 0.5 2.96243 0.5 6C0.5 9.03757 2.96243 11.5 6 11.5Z" stroke="black" stroke-linecap="round" stroke-linejoin="round" />
                                            <path d="M13.5 13.5L10 10" stroke="black" stroke-linecap="round" stroke-linejoin="round" />
                                        </g>
                                        <defs>
                                            <clipPath id="clip0_11_108">
                                                <rect width="14" height="14" fill="white" />
                                            </clipPath>
                                        </defs>
                                    </svg>
                                </a>

                            </label>
                            <input type="text" name="" id="search-input" placeholder="Search anything here..">
                        </fieldset>
                        </div>
                    </div>

                    <div class="form-row">
                        <div>
                            <label for="restockQuantity">Quantity</label>
                            <input type="number" name="restockQuantity" id="restockQuantity" min="1" value="1">
                        </div>
                    </div>

                    <div class="form-row">
                        <button id="submitRestock" class="orange-btn medium">Restock</button>
                    </div>
                </form>
            </div>
        `

        document.body.append(restockItemPopupOverlay);

        document.querySelector('#submitRestock').addEventListener('click', function (e) {

            e.preventDefault();

            isError = false;

            // ADD VALIDATION CHECKS

            // If no error submit data to server
            // TO BE CHANGED
            if (isError == false) {
                restockItemPopupOverlay.remove();
            }

            // Handle exit from edit
        });

        document.getElementById('exitPopupCard').addEventListener('click', function () {

            restockItemPopupOverlay.remove();
        });
    })

    // ADD ITEM POPUP
    addItemButton.addEventListener('click', function (e) {
        var addItemPopupOverlay = document.createElement('div');

        addItemPopupOverlay.id = 'PopupOverlay';
        addItemPopupOverlay.innerHTML = `
            <div class="popupCard"  id="addPopup">
                <button id="exitPopupCard">X</button>
                <h1>Product Details</h1>
                <form class="popupCardFormContainer">
                
                    <div class="form-row">
                        <div>
                            <label for="productName">Name:</label>
                            <input type="text" id="productName" name="productName" value="" />
                        </div>
                        
                    </div>
                
                    <div class="form-row">
                        <div>
                            <label for="productQuantity">Quantity:</label>
                            <input type="text" id="productQuantity" name="productQuantity" value="" />
                        </div>
                        <div>
                            <label for="productUnitCost">Unit Cost:</label>
                            <input type="text" id="productUnitCost" name="productUnitCost" value="" />

                        </div>
                        <div>
                            <label for="productUnitPrice">Unit Price:</label>                                                         
                            <input type="text" id="productUnitPrice" name="productUnitPrice" value="" />
                        </div>                                             
                    </div>
                
                    <div class="form-row">
                        <div>
                            <label for="productMeasurement">Measurement:</label>
                            <input type="text" id="productMeasurement" name="productMeasurement" value="" />
                        </div>
                        <div>
                            <label for="productManufacturer">Manufacturer:</label>                         
                            <input type="text" id="productManufacturer" name="productManufacturer" value="" />
                        </div>
                    </div>
                
                    <div class="form-row">
                        <button id="submitAdd" class="orange-btn medium">Add Item</button>
                    </div>
                    
                </form>
            </div>
        `
        document.body.append(addItemPopupOverlay);




        // Event listener for submitting added product data
        document.querySelector('#submitAdd').addEventListener('click', function (e) {

            e.preventDefault();
            // Retrieve input values
            var productName = document.getElementById('productName').value;
            var productQuantity = parseFloat(document.getElementById('productQuantity').value);
            var productUnitCost = parseFloat(document.getElementById('productUnitCost').value);
            var productUnitPrice = parseFloat(document.getElementById('productUnitPrice').value);
            var productMeasurement = document.getElementById('productMeasurement').value;
            var productManufacturer = document.getElementById('productManufacturer').value;

            // VALIDATION CHECKS
            // TO BE CHANGED
            var isError = false;
            if (productName === '') {
                applyErrorStyles('productName');
                isError = true;
            } else {
                resetErrorStyles('productName');
            }

            if (isNaN(productQuantity)) {
                applyErrorStyles('productQuantity');
                isError = true;
            } else {
                resetErrorStyles('productQuantity');
            }

            if (isNaN(productUnitCost)) {
                applyErrorStyles('productUnitCost');
                isError = true;
            } else {
                resetErrorStyles('productUnitCost');
            }

            if (isNaN(productUnitPrice)) {
                applyErrorStyles('productUnitPrice');
                isError = true;
            } else {
                resetErrorStyles('productUnitPrice');
            }

            if (productMeasurement === '') {
                applyErrorStyles('productMeasurement');
                isError = true;
            } else {
                resetErrorStyles('productMeasurement');
            }

            if (productManufacturer === '') {
                applyErrorStyles('productManufacturer');
                isError = true;
            } else {
                resetErrorStyles('productManufacturer');
            }

            // Create an object with the added product data
            var addedProductData = {
                productName: productName,
                productQuantity: productQuantity,
                productUnitCost: productUnitCost,
                productUnitPrice: productUnitPrice,
                productMeasurement: productMeasurement,
                productManufacturer: productManufacturer
            };

            console.log(addedProductData);

            // If no error submit data to server
            // TO BE CHANGED
            if (isError == false) {
                addItemPopupOverlay.remove();
            }

            // Handle exit from edit
        });


        // Remove the edit pop-up without submitting
        document.getElementById('exitPopupCard').addEventListener('click', function () {
            
            addItemPopupOverlay.remove();
        });
    });


    editButtons.forEach(function (editButton) {
        editButton.addEventListener('click', function (e) {

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
            editPopupOverlay.id = 'PopupOverlay';
            editPopupOverlay.innerHTML = `
                <div class="popupCard" id="editPopup">
                    <button id="exitPopupCard">X</button>
                    <h1>Product Details</h1>
                    <p>ID: ${productID}</p>
                    <form class="popupCardFormContainer" >
                    
                        <div class="form-row">
                            <div>
                                <label for="productName">Name:</label>
                                <input type="text" id="productName" name="productName" value="${productName}" />
                            </div>
                            
                        </div>
                    
                        <div class="form-row">
                            <div>
                                <label for="productQuantity">Quantity:</label>
                                <input type="text" id="productQuantity" name="productQuantity" value="${productQuantity}" />
                            </div>
                          
                            <div>
                                <label for="productUnitCost">Unit Cost:</label>
                                <input type="text" id="productUnitCost" name="productUnitCost" value="${productUnitCost}" />
                            </div>

                            <div>
                                <label for="productUnitPrice">Unit Price:</label>
                                <input type="text" id="productUnitPrice" name="productUnitPrice" value="${productUnitPrice}" />
                            </div>                                                                                                                              
                        </div>
                    
                        <div class="form-row">
                            <div>
                                <label for="productMeasurement">Measurement:</label>
                                <input type="text" id="productMeasurement" name="productMeasurement" value="${productMeasurement}" />
                            </div>

                            <div>
                                <label for="productManufacturer">Manufacturer:</label>
                                <input type="text" id="productManufacturer" name="productManufacturer" value="${productManufacturer}" />
                            </div>                          
                        </div>
                    
                        <div class="form-row">
                            <button id="submitEdit" class="orange-btn medium">Submit</button>
                        </div>
                    </form>
                </div>
            `;

            document.body.append(editPopupOverlay);

            // Handle edit submission
            document.getElementById('submitEdit').addEventListener('click', function (e) {
                // Perform actions to update data using AJAX or other methods
                e.preventDefault();

                // Create an object with the updated product data

                var productName = document.getElementById('productName').value;
                var productQuantity = parseFloat(document.getElementById('productQuantity').value);
                var productUnitCost = parseFloat(document.getElementById('productUnitCost').value);
                var productUnitPrice = parseFloat(document.getElementById('productUnitPrice').value);
                var productMeasurement = document.getElementById('productMeasurement').value;
                var productManufacturer = document.getElementById('productManufacturer').value;

                // VALIDATION CHECKS
                // TO BE CHANGED
                var isError = false;
                if (productName === '') {
                    applyErrorStyles('productName');
                    isError = true;
                } else {
                    resetErrorStyles('productName');
                }

                if (isNaN(productQuantity)) {
                    applyErrorStyles('productQuantity');
                    isError = true;
                } else {
                    resetErrorStyles('productQuantity');
                }

                if (isNaN(productUnitCost)) {
                    applyErrorStyles('productUnitCost');
                    isError = true;
                } else {
                    resetErrorStyles('productUnitCost');
                }

                if (isNaN(productUnitPrice)) {
                    applyErrorStyles('productUnitPrice');
                    isError = true;
                } else {
                    resetErrorStyles('productUnitPrice');
                }

                if (productMeasurement === '') {
                    applyErrorStyles('productMeasurement');
                    isError = true;
                } else {
                    resetErrorStyles('productMeasurement');
                }

                if (productManufacturer === '') {
                    applyErrorStyles('productManufacturer');
                    isError = true;
                } else {
                    resetErrorStyles('productManufacturer');
                }

                // Create an object with the added product data
                var updatedProductData = {
                    productName: productName,
                    productQuantity: productQuantity,
                    productUnitCost: productUnitCost,
                    productUnitPrice: productUnitPrice,
                    productMeasurement: productMeasurement,
                    productManufacturer: productManufacturer
                };

                console.log(updatedProductData);

                // If no error submit data to server
                // TO BE CHANGED
                if (isError == false) {
                    editPopupOverlay.remove();
                }

                // Handle exit from edit
            });

            // Remove the edit pop-up without submitting
            document.getElementById('exitPopupCard').addEventListener('click', function () {

                editPopupOverlay.remove();
            });
        })

    })

    // Function to apply error styles to input fields
    function applyErrorStyles(elementId) {
        var element = document.getElementById(elementId);
        element.style.border = '1px solid red';
        element.classList.add('shake'); // Adding a shake class for animation
        setTimeout(function () {
            element.classList.remove('shake'); // Remove the shake class after the animation ends
        }, 500);
    }

    function resetErrorStyles(elementId) {
        var element = document.getElementById(elementId);
        element.style.border = '1px solid #ccc'; // Reset the border
    }

})