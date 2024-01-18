document.addEventListener('DOMContentLoaded', function () {
   
    setupRestockForm();
    setupAddItemForm();
    setupEditItemForm();
    setupDelButton();  

})

/*var productInfo = [
    {
        "productID": "1",
        "productName": "Hammer",
        "quantity": 10,
        "unitCost": 150.75,
        "unitPrice": 199.99,
        "measurement": "Each",
        "manufacturerID": "ABC Hardware",
        "isAvailable": true
    },
    {
        "productID": "2",
        "productName": "Screwdriver Set",
        "quantity": 20,
        "unitCost": 75.25,
        "unitPrice": 99.99,
        "measurement": "Set",
        "manufacturerID": "XYZ Tools",
        "isAvailable": true
    },
    {
        "productID": "3",
        "productName": "Plywood Sheet",
        "quantity": 5,
        "unitCost": 300.50,
        "unitPrice": 399.99,
        "measurement": "Sheet",
        "manufacturerID": "DEF Lumber",
        "isAvailable": false
    },
    {
        "productID": "4",
        "productName": "Paint Roller Kit",
        "quantity": 15,
        "unitCost": 50.90,
        "unitPrice": 69.99,
        "measurement": "Kit",
        "manufacturerID": "LMN Supplies",
        "isAvailable": true
    },
    {
        "productID": "5",
        "productName": "Cordless Drill",
        "quantity": 8,
        "unitCost": 200.25,
        "unitPrice": 259.99,
        "measurement": "Each",
        "manufacturerID": "GHI Tools",
        "isAvailable": true
    }
]
*/
function setupRestockForm() {
    var restockItemButton = document.querySelector('.restock-product')
    restockItemButton.addEventListener('click', function (e) {
        var restockItemPopupOverlay = document.createElement('div');

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
                                <input type="text" name="" id="search-restock" placeholder="Search anything here..">
                                <div class="search-suggestion-container search-restock-suggestion-container">

                                </div>
                            </fieldset>
                        </div>
                    </div>

                    <div class="form-row">
                        <div>
                            <p>ID: <span class="productID"><span></p>
                            <p>Name: <span class="productName"><span></p>
                            <p>Manufacturer: <span class="manufacturerID"><span></p>
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

        getManufacturerList();

        document.body.append(restockItemPopupOverlay);

        setupProductRestockSearchSuggestion();
        document.querySelector('#submitRestock').addEventListener('click', function (e) {

            e.preventDefault();


            // ADD VALIDATION CHECKS

            // If no error submit data to server
            // TO BE CHANGED

            restockItemPopupOverlay.remove();


            // Handle exit from edit
        });

        document.getElementById('exitPopupCard').addEventListener('click', function () {
            restockItemPopupOverlay.remove();
        });
    })
}

function setupProductRestockSearchSuggestion() {
    var searchProductInput = document.querySelector("#search-restock");
    var searchSuggestionContainer = document.querySelector(".search-restock-suggestion-container");

    searchProductInput.addEventListener("focus", function () {
        searchSuggestionContainer.style.display = "block";
    });

    searchProductInput.addEventListener("input", function () {
        // Clear the existing timeout if any
        /*clearTimeout(hideSuggestionTimeout);*/
        showProductRestockSuggestion();
    });

    searchSuggestionContainer.addEventListener("click", function (event) {
        var clickedCard = event.target.closest(".search-suggestion-card");
        if (clickedCard) {
            fillWithProductDetails(clickedCard);
            // Call selectProduct with the productID
            selectProductRestock(clickedCard.querySelector('.productID').textContent);
        }
    });

    searchProductInput.addEventListener("blur", function () {
        /*hideSuggestionTimeout = setTimeout(function () {
            hideProductRestockSuggestion();
        }, 200);*/
    });
}

function showProductRestockSuggestion() {
    var searchSuggestionContainer = document.querySelector(".search-restock-suggestion-container");
    var inputValue = document.getElementById("search-restock").value.toLowerCase();

    // Clear existing suggestions
    searchSuggestionContainer.innerHTML = "";

    // Filter productInfo based on input value
    var filteredProducts = productInfo.filter(function (product) {
        var productName = product.productName.toLowerCase();
        return productName.includes(inputValue);
    });

    filteredProducts.forEach(function (product) {
        // Create a new search suggestion card for products
        var suggestionCard = document.createElement("div");
        suggestionCard.classList.add("search-suggestion-card");

        // Add product information to the card
        suggestionCard.innerHTML = `
            <p class="productID">${product.productID}</p>
            <p class="productName">${product.productName}</p>
            <p class="other-info">quantity: ${product.quantity}</p>
            <p class="other-info">Unit Price: ${product.unitPrice.toFixed(2)}</p>
            <p class="other-info">manufacturerID: ${product.manufacturerID}</p>
        `;

        // Append the card to the search suggestion container
        searchSuggestionContainer.appendChild(suggestionCard);
    });
}

function hideProductRestockSuggestion() {
    var searchSuggestionContainer = document.querySelector(".search-restock-suggestion-container");
    searchSuggestionContainer.style.display = "none";
}

function fillWithProductDetails(clickedCard) {
    var productName = clickedCard.querySelector(".productName").textContent;
    document.getElementById("search-restock").value = productName;
    hideProductRestockSuggestion();
}

function selectProductRestock(productID) {

    // Find the selected product in the productInfo array
    var selectedProduct = productInfo.find(product => product.productID === productID);

    // Check if the product is found
    if (selectedProduct) {
        // Get the spans in the restock form
        var productIDSpan = document.querySelector("span.productID");
        var productNameSpan = document.querySelector("span.productName");
        var manufacturerIDSpan = document.querySelector("span.manufacturerID");

        // Update spans with product details
        productIDSpan.innerText = selectedProduct.productID;
        productNameSpan.innerText = selectedProduct.productName;
        manufacturerIDSpan.innerText = selectedProduct.manufacturerID;
    } else {
        console.error("Product not found");
    }
}


function setupAddItemForm() {
    var addItemButton = document.querySelector('.add-product')

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
                            <select id="productManufacturer" name="productManufacturer">

                            </select>
                        </div>
                    </div>
                
                    <div class="form-row">
                        <button id="submitAdd" class="orange-btn medium">Add Item</button>
                    </div>
                    
                </form>
            </div>
        `

        getManufacturerList();
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
                ProductID: '',
                ProductName: productName,
                ProductDescription: "",
                UnitPrice: productUnitPrice,
                Quantity: productQuantity,
                UnitCost: productUnitCost,
                ManufacturerID: productManufacturer,
                Measurement: productMeasurement,
                IsAvailable: true,
                UnitCost: productUnitCost
            };


            // If no error submit data to server
            // TO BE CHANGED

            if (isError == false) {

                addItemFormSendData(addedProductData);
                addItemPopupOverlay.remove();
            }

            // Handle exit from edit
        });


        // Remove the edit pop-up without submitting
        document.getElementById('exitPopupCard').addEventListener('click', function () {

            addItemPopupOverlay.remove();
        });
    });
}

function setupEditItemForm() {

    var editButtons = document.querySelectorAll('.edit-product');
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
                                <select id="productManufacturer" name="productManufacturer">

                                </select>
                            </div>                          
                        </div>
                    
                        <div class="form-row">
                            <button id="submitEdit" class="orange-btn medium">Submit</button>
                        </div>
                    </form>
                </div>
            `;

            getEditManufacturerList(productManufacturer);

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
                    ProductID: productID,
                    ProductName: productName,
                    ProductDescription: "",
                    UnitPrice: productUnitPrice,
                    Quantity: productQuantity,
                    UnitCost: productUnitCost,
                    ManufacturerID: productManufacturer,
                    Measurement: productMeasurement,
                    IsAvailable: true,
                    UnitCost: productUnitCost
                };

                // If no error submit data to server
                // TO BE CHANGED
                if (isError == false) {

                    editItemFormSendData(updatedProductData);
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
}

function setupDelButton() {
    var delButtons = document.querySelectorAll('.del-product');
    delButtons.forEach(function (delButton) {
        delButton.addEventListener('click', function (e) {
            var row = e.target.closest('tr'); // Find the closest row (tr)

            // get data
            var productID = row.querySelectorAll('td')[0].textContent;
            var productName = row.querySelectorAll('td')[1].textContent;
            var productQuantity = row.querySelectorAll('td')[2].textContent;
            var productUnitCost = row.querySelectorAll('td')[3].textContent;
            var productUnitPrice = row.querySelectorAll('td')[4].textContent;
            var productMeasurement = row.querySelectorAll('td')[5].textContent;
            var productManufacturer = row.querySelectorAll('td')[6].textContent;

            var ProductData = {
                ProductID: productID,
                ProductName: productName,
                ProductDescription: "",
                UnitPrice: productUnitPrice,
                Quantity: productQuantity,
                UnitCost: productUnitCost,
                ManufacturerID: productManufacturer,
                Measurement: productMeasurement,
                IsAvailable: false,
                UnitCost: productUnitCost
            };

            delProductSendData(ProductData);

        })
    })
}

function addItemFormSendData(addedProductData) {
    fetch('/Home/AddInventoryProduct', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(addedProductData)
    })
        .then(data => {
            console.log('Product added successfully:', data);
            location.reload();
            // Optionally, perform actions after successful product addition
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}

function editItemFormSendData(editProductData) {
    fetch('/Home/EditInventoryProduct', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(editProductData)
    })
        .then(data => {
            console.log('Product added successfully:', data);
            location.reload();
            // Optionally, perform actions after successful product addition
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}

function delProductSendData(productData) {
    fetch('/Home/DeleteProduct', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productData)
    })
        .then(data => {
            console.log('Product added successfully:', data);
            location.reload();
            // Optionally, perform actions after successful product addition
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}


function getManufacturerList() {
    // Fetch manufacturers from the server
    fetch('/Home/GetManufacturerList')
        .then(response => response.json())
        .then(manufacturerList => {
            // Call a function to populate the manufacturer dropdown
            populateManufacturerDropdown(manufacturerList);
        })
        .catch(error => {
            console.error('Error fetching manufacturers:', error);
        });
}

function populateManufacturerDropdown(manufacturerList) {
    // Get the select element
    var manufacturerDropdown = document.getElementById('productManufacturer');

    // Clear existing options
    manufacturerDropdown.innerHTML = `<option value="" disabled selected hidden>Manufacturer</option>`;


    // Populate options from the manufacturer list
    manufacturerList.forEach(manufacturer => {
        var option = document.createElement('option');
        option.value = manufacturer.manufacturerID;
        option.textContent = manufacturer.manufacturerName;
        manufacturerDropdown.appendChild(option);
    });
}

function getEditManufacturerList(productManufacturer) {
    // Fetch manufacturers from the server
    fetch('/Home/GetManufacturerList')
        .then(response => response.json())
        .then(manufacturerList => {
            // Find the manufacturer in the list based on the given name
            var selectedManufacturer = manufacturerList.find(manufacturer => manufacturer.manufacturerName === productManufacturer);

            // Call a function to populate the manufacturer dropdown with the default option
            populateEditManufacturerDropdown(manufacturerList, selectedManufacturer);
        })
        .catch(error => {
            console.error('Error fetching manufacturers:', error);
        });
}

function populateEditManufacturerDropdown(manufacturerList, selectedManufacturer) {
    var manufacturerDropdown = document.getElementById('productManufacturer');
    manufacturerDropdown.innerHTML = ''; // Clear existing options

    // Populate options from the manufacturer list
    manufacturerList.forEach(manufacturer => {
        var option = document.createElement('option');
        option.value = manufacturer.manufacturerID;
        option.textContent = manufacturer.manufacturerName;

        // Set the default option if it matches the selected manufacturer
        if (selectedManufacturer && manufacturer.manufacturerID === selectedManufacturer.manufacturerID) {
            option.selected = true;
        }

        manufacturerDropdown.appendChild(option);
    });
}



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