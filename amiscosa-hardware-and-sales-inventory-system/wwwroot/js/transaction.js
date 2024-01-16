document.addEventListener('DOMContentLoaded', function () {
    console.log(1)
    setupCustomerSearchSuggestion();
    setupProductSearchSuggestion();
    selectCustomer();
    setupCustomNumberInput();
    removeProduct();

});

var customerInfo = [
    {
        CustomerId: 1,
        CustomerFName: "Hazee Marie Joy Batumbakal",
        CustomerMName: "Daileg",
        CustomerLName: "Ilao",
        CustomerAddress: "Mariveles, Bataan",
        CustomerContact: "09453571568"
    },
    {
        CustomerId: 2,
        CustomerFName: "John Drexler",
        CustomerMName: "Gueco",
        CustomerLName: "Cubebe",
        CustomerAddress: "Limay, Bataan",
        CustomerContact: "09764659815"
    },
    {
        CustomerId: 3,
        CustomerFName: "Anna",
        CustomerMName: "Marie",
        CustomerLName: "Smith",
        CustomerAddress: "Manila, Philippines",
        CustomerContact: "09123456789"
    },
    {
        CustomerId: 4,
        CustomerFName: "Michael",
        CustomerMName: "James",
        CustomerLName: "Johnson",
        CustomerAddress: "Quezon City, Philippines",
        CustomerContact: "09234567890"
    },
    {
        CustomerId: 5,
        CustomerFName: "Elena",
        CustomerMName: "Grace",
        CustomerLName: "Garcia",
        CustomerAddress: "Makati, Philippines",
        CustomerContact: "09345678901"
    }

]

var productInfo = [
    {
        "ProductID": 1,
        "ProductName": "Hammer",
        "Quantity": 10,
        "UnitCost": 150.75,
        "UnitPrice": 199.99,
        "Measurement": "Each",
        "Manufacturer": "ABC Hardware",
        "IsAvailable": true
    },
    {
        "ProductID": 2,
        "ProductName": "Screwdriver Set",
        "Quantity": 20,
        "UnitCost": 75.25,
        "UnitPrice": 99.99,
        "Measurement": "Set",
        "Manufacturer": "XYZ Tools",
        "IsAvailable": true
    },
    {
        "ProductID": 3,
        "ProductName": "Plywood Sheet",
        "Quantity": 5,
        "UnitCost": 300.50,
        "UnitPrice": 399.99,
        "Measurement": "Sheet",
        "Manufacturer": "DEF Lumber",
        "IsAvailable": false
    },
    {
        "ProductID": 4,
        "ProductName": "Paint Roller Kit",
        "Quantity": 15,
        "UnitCost": 50.90,
        "UnitPrice": 69.99,
        "Measurement": "Kit",
        "Manufacturer": "LMN Supplies",
        "IsAvailable": true
    },
    {
        "ProductID": 5,
        "ProductName": "Cordless Drill",
        "Quantity": 8,
        "UnitCost": 200.25,
        "UnitPrice": 259.99,
        "Measurement": "Each",
        "Manufacturer": "GHI Tools",
        "IsAvailable": true
    }
]

function setupCustomerSearchSuggestion() {
    var searchCustomerInput = document.querySelector("#search-customer")
    var searchSuggestionContainer = document.querySelector(".search-customer-form .search-suggestion-container");

    searchCustomerInput.addEventListener("focus", function () {
        searchSuggestionContainer.style.display = "block";
    })

    searchSuggestionContainer.addEventListener("click", function (event) {
        var clickedCard = event.target.closest(".search-suggestion-card");
        if (clickedCard) {
            fillInputWithCustomerName(clickedCard);
        }
    });

    searchCustomerInput.addEventListener("input", function () {
        showCustomerSuggestion();
    });

    searchCustomerInput.addEventListener("blur", function () {
        hideSuggestionTimeout = setTimeout(function () {
            hideCustomerSuggestion();
        }, 200);
    });

   



}

function showCustomerSuggestion() {
    var searchSuggestionContainer = document.querySelector(".search-customer-form .search-suggestion-container");
    var inputValue = document.getElementById("search-customer").value.toLowerCase();

    // Clear existing suggestions
    searchSuggestionContainer.innerHTML = "";

    // Filter customerInfo based on input value
    var filteredCustomers = customerInfo.filter(function (customer) {
        var fullName = `${customer.CustomerFName} ${customer.CustomerMName ? customer.CustomerMName + ' ' : ''}${customer.CustomerLName}`.toLowerCase();
        return fullName.includes(inputValue);
    });
    filteredCustomers.forEach(function (customer) {
        // Create a new search suggestion card
        var suggestionCard = document.createElement("div");
        suggestionCard.classList.add("search-suggestion-card");

        // Add customer information to the card
        suggestionCard.innerHTML = `
            <p class="name">${customer.CustomerFName} ${customer.CustomerMName ? customer.CustomerMName + ' ' : ''}${customer.CustomerLName}</p>
            <p class="other-info">${customer.CustomerAddress}</p>
            <p class="other-info">${customer.CustomerContact}</p>
        `;

        // Append the card to the search suggestion container
        searchSuggestionContainer.appendChild(suggestionCard);

    });
}

function hideCustomerSuggestion() {
    var searchSuggestionContainer = document.querySelector(".search-customer-form .search-suggestion-container");
    var searchSuggestionCards = document.querySelectorAll(".search-suggestion-card");

    searchSuggestionCards.forEach(function (card) {
        searchSuggestionContainer.removeChild(card);
    });

    searchSuggestionContainer.style.display = "none";
}

function fillInputWithCustomerName(clickedCard) {
    var customerName = clickedCard.querySelector(".name").textContent;
    document.getElementById("search-customer").value = customerName;
    hideCustomerSuggestion();
}





function setupProductSearchSuggestion() {
    var searchProductInput = document.querySelector("#select-product");
    var searchSuggestionContainer = document.querySelector(".select-product-form .search-suggestion-container");

    searchProductInput.addEventListener("focus", function () {
        searchSuggestionContainer.style.display = "block";
    });

    searchProductInput.addEventListener("input", function () {
        // Clear the existing timeout if any
        /*clearTimeout(hideSuggestionTimeout);*/
        showProductSuggestion();
    });

    searchSuggestionContainer.addEventListener("click", function (event) {
        var clickedCard = event.target.closest(".search-suggestion-card");
        if (clickedCard) {
            fillInputWithProductName(clickedCard);
            // Call selectProduct with the ProductID
            selectProduct(parseInt(clickedCard.querySelector('.productID').textContent));
        }
    });

    searchProductInput.addEventListener("blur", function () {
        hideSuggestionTimeout = setTimeout(function () {
            hideProductSuggestion();
        }, 200);
    });
}

function showProductSuggestion() {
    var searchSuggestionContainer = document.querySelector(".select-product-form .search-suggestion-container");
    var inputValue = document.getElementById("select-product").value.toLowerCase();

    // Clear existing suggestions
    searchSuggestionContainer.innerHTML = "";

    // Filter productInfo based on input value
    var filteredProducts = productInfo.filter(function (product) {
        var productName = product.ProductName.toLowerCase();
        return productName.includes(inputValue);
    });

    filteredProducts.forEach(function (product) {
        // Create a new search suggestion card for products
        var suggestionCard = document.createElement("div");
        suggestionCard.classList.add("search-suggestion-card");

        // Add product information to the card
        suggestionCard.innerHTML = `
            <p class="productID">${product.ProductID}</p>
            <p class="name">${product.ProductName}</p>
            <p class="other-info">Quantity: ${product.Quantity}</p>
            <p class="other-info">Unit Price: ${product.UnitPrice.toFixed(2)}</p>
            <p class="other-info">Manufacturer: ${product.Manufacturer}</p>
        `;

        // Append the card to the search suggestion container
        searchSuggestionContainer.appendChild(suggestionCard);
    });
}

function hideProductSuggestion() {
    var searchSuggestionContainer = document.querySelector(".select-product-form .search-suggestion-container");
    searchSuggestionContainer.style.display = "none";
}

function fillInputWithProductName(clickedCard) {

    var productName = clickedCard.querySelector(".name").textContent;
    document.getElementById("select-product").value = productName;
    hideProductSuggestion();
}





function selectCustomer() {
    document.getElementById('select-customer').addEventListener('click', function (event) {
        event.preventDefault(); // Prevent form submission (if the form has an action attribute)

        // Get the selected customer information
        var selectedCustomerName = document.getElementById('search-customer').value;

        // Update the content of the customer-name-container
        document.getElementById('selected-customer-name').innerText = selectedCustomerName;
    });
}

function selectProduct(productId) {
    // Find the selected product in the productInfo array
    var selectedProduct = productInfo.find(product => product.ProductID === productId);

    // Check if the product is found
    if (selectedProduct) {
        // Get the table body element
        var tableBody = document.querySelector("#product-listing tbody");

        // Create a new table row
        var newRow = document.createElement("tr");

        // Fill the row with product information using template literals
        newRow.innerHTML = `
            <td>${selectedProduct.ProductID}</td>
            <td>${selectedProduct.ProductName}</td>
            <td>
                <div class="custom-number-input">
                    <button class="decrement">-</button>
                    <input type="number" min="1" max="${selectedProduct.Quantity}" value="1">
                    <button class="increment">+</button>
                </div>
            </td>
            <td>${selectedProduct.UnitPrice.toFixed(2)}</td>
            <td>${(selectedProduct.UnitPrice).toFixed(2)}</td>
            <td>
                <button class="del-listing">
                    -
                </button>
            </td>
        `;

        // Append the new row to the table body
        tableBody.appendChild(newRow);
    } else {
        console.error("Product not found");
    }
}



function removeProduct() {
    var tableBody = document.querySelector("#product-listing tbody");

    tableBody.addEventListener("click", function (event) {
        var deleteButton = event.target.closest(".del-listing");

        if (deleteButton) {
            console.log("Remove button clicked");

            var row = deleteButton.closest("tr");
            if (row) {
                console.log("Row found and removed");
                row.remove();
            }
        }
    });
}


function setupCustomNumberInput() {
    var tableBody = document.querySelector("#product-listing tbody");

    tableBody.addEventListener("click", function (event) {
        var target = event.target;

        // Check if the clicked element is a decrement or increment button
        if (target.classList.contains("decrement") || target.classList.contains("increment")) {
            event.preventDefault();

            // Find the input field in the same row
            var inputField = target.closest("tr").querySelector('input[type="number"]');

            // Perform the appropriate action based on the button clicked
            if (target.classList.contains("decrement")) {
                inputField.stepDown();
            } else if (target.classList.contains("increment")) {
                inputField.stepUp();
            }

            // Update the total price
            updateTotalPrice(inputField);
        }
    });

    document.querySelectorAll('.custom-number-input').forEach(function (inputGroup) {
        const inputField = inputGroup.querySelector('input[type="number"]');
        const decrementButton = inputGroup.querySelector('.decrement');
        const incrementButton = inputGroup.querySelector('.increment');

        inputField.addEventListener("input", function (e) {
            e.preventDefault();
            const currentValue = parseFloat(e.target.value);

            if (currentValue <= 0 || isNaN(currentValue)) {
                e.target.value = '1';
            }

            updateTotalPrice(e.target);
        });

        inputField.addEventListener("keydown", function (e) {
            const key = e.key;
            const currentValue = parseFloat(e.target.value);

            if ((key === "-" && currentValue <= 1) || isNaN(currentValue)) {
                e.preventDefault();
            }
        });
    });
}

function updateTotalPrice(input) {
    const row = input.closest('tr');
    const quantity = parseFloat(input.value);

    if (isNaN(quantity) || quantity <= 0) {
        input.value = '1';
        quantity = 1;
    }

    const unitPrice = parseFloat(row.querySelectorAll('td')[3].textContent);
    const totalPriceElement = row.querySelectorAll('td')[4];

    const totalPrice = quantity * unitPrice;
    totalPriceElement.textContent = totalPrice.toFixed(2);
}
