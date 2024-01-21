document.addEventListener('DOMContentLoaded', function () {
    console.log(1)


    fetch('/Home/GetTransactionDataList')
        .then(response => response.json())
        .then(data => {
            // Update customerInfo and productInfo with the fetched data
            customerInfo = data.customers;
            productInfo = data.products;
            /*console.log(data)
            console.log(customerInfo)
            console.log(customerInfo)*/

            setupCustomerSearchSuggestion();
            setupProductSearchSuggestion();
            selectCustomer();
            setupCustomNumberInput();
            removeProduct();
            
        })
        .catch(error => console.error('Error fetching data:', error));


    setupTransactionConfirmation();
});

/*var customerInfo = [
    {
        customerID: 1,
        customerFName: "Hazee Marie Joy Batumbakal",
        customerMName: "Daileg",
        customerLName: "Ilao",
        customerAddress: "Mariveles, Bataan",
        customerContact: "09453571568"
    },
    {
        customerID: 2,
        customerFName: "John Drexler",
        customerMName: "Gueco",
        customerLName: "Cubebe",
        customerAddress: "Limay, Bataan",
        customerContact: "09764659815"
    },
    {
        customerID: 3,
        customerFName: "Anna",
        customerMName: "Marie",
        customerLName: "Smith",
        customerAddress: "Manila, Philippines",
        customerContact: "09123456789"
    },
    {
        customerID: 4,
        customerFName: "Michael",
        customerMName: "James",
        customerLName: "Johnson",
        customerAddress: "Quezon City, Philippines",
        customerContact: "09234567890"
    },
    {
        customerID: 5,
        customerFName: "Elena",
        customerMName: "Grace",
        customerLName: "Garcia",
        customerAddress: "Makati, Philippines",
        customerContact: "09345678901"
    }

]*/

/*var productInfo = [
    {
        "productID": 1,
        "productName": "Hammer",
        "quantity": 10,
        "unitCost": 150.75,
        "unitPrice": 199.99,
        "measurement": "Each",
        "manufacturerID": "ABC Hardware",
        "isAvailable": true
    },
    {
        "productID": 2,
        "productName": "Screwdriver Set",
        "quantity": 20,
        "unitCost": 75.25,
        "unitPrice": 99.99,
        "measurement": "Set",
        "manufacturerID": "XYZ Tools",
        "isAvailable": true
    },
    {
        "productID": 3,
        "productName": "Plywood Sheet",
        "quantity": 5,
        "unitCost": 300.50,
        "unitPrice": 399.99,
        "measurement": "Sheet",
        "manufacturerID": "DEF Lumber",
        "isAvailable": false
    },
    {
        "productID": 4,
        "productName": "Paint Roller Kit",
        "quantity": 15,
        "unitCost": 50.90,
        "unitPrice": 69.99,
        "measurement": "Kit",
        "manufacturerID": "LMN Supplies",
        "isAvailable": true
    },
    {
        "productID": 5,
        "productName": "Cordless Drill",
        "quantity": 8,
        "unitCost": 200.25,
        "unitPrice": 259.99,
        "measurement": "Each",
        "manufacturerID": "GHI Tools",
        "isAvailable": true
    }
]*/

/*var customerInfo = []*/
/*var productInfo = []*/

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
        var fullName = `${customer.customerFName} ${customer.customerMName ? customer.customerMName + ' ' : ''}${customer.customerLName}`.toLowerCase();
        return fullName.includes(inputValue);
    });
    filteredCustomers.forEach(function (customer) {
        // Create a new search suggestion card
        var suggestionCard = document.createElement("div");
        suggestionCard.classList.add("search-suggestion-card");

        // Add customer information to the card
        suggestionCard.innerHTML = `
            <p class="name">${customer.customerFName} ${customer.customerMName ? customer.customerMName + ' ' : ''}${customer.customerLName}</p>
            <p class="other-info">${customer.customerAddress}</p>
            <p class="other-info">${customer.customerContact}</p>
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
            fillInputWithproductName(clickedCard);
            // Call selectProduct with the productID
            selectProduct(clickedCard.querySelector('.productID').textContent);
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
            <p class="name">${product.productName}</p>
            <p class="other-info">quantity: ${product.quantity}</p>
            <p class="other-info">Unit Price: ${product.unitPrice.toFixed(2)}</p>
            <p class="other-info">manufacturerID: ${product.manufacturerID}</p>
        `;

        // Append the card to the search suggestion container
        searchSuggestionContainer.appendChild(suggestionCard);
    });
}

function hideProductSuggestion() {
    var searchSuggestionContainer = document.querySelector(".select-product-form .search-suggestion-container");
    searchSuggestionContainer.style.display = "none";
}

function fillInputWithproductName(clickedCard) {

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

function selectProduct(productID) {
    // Find the selected product in the productInfo array
    var selectedProduct = productInfo.find(product => product.productID === productID);

/*    console.log(productID)
    console.log(selectedProduct)*/
    // Check if the product is found
    if (selectedProduct) {
        // Get the table body element
        var tableBody = document.querySelector("#product-listing tbody");

        // Create a new table row
        var newRow = document.createElement("tr");

        // Fill the row with product information using template literals
        newRow.innerHTML = `
            <td>${selectedProduct.productID}</td>
            <td>${selectedProduct.productName}</td>
            <td>
                <div class="custom-number-input">
                    <button class="decrement">-</button>
                    <input type="number" min="1" max="${selectedProduct.quantity}" value="1">
                    <button class="increment">+</button>
                </div>
            </td>
            <td>${selectedProduct.unitPrice.toFixed(2)}</td>
            <td>${(selectedProduct.unitPrice).toFixed(2)}</td>
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


function setupTransactionConfirmation() {
    console.log("setup")
   

    // Add an event listener for the Confirm button
    document.querySelector('.confirm-btn').addEventListener('click', function () {
        // Call a function to gather and process the data
        console.log("click")

        gatherAndProcessData();
    });

}


function gatherAndProcessData() {

    var selectedCustomerName = document.getElementById('search-customer').value;

    // Find the selected customer in the customerInfo array
    var selectedCustomer = customerInfo.find(function (customer) {
        var fullName = `${customer.customerFName} ${customer.customerMName ? customer.customerMName + ' ' : ''}${customer.customerLName}`;
        return fullName === selectedCustomerName;
    });

    var customerID = selectedCustomer.customerID;
    console.log(customerID)


    var transactionData = {
        CustomerID: customerID,
        IsInvalid: false,
        TransactionDate: new Date(),
        StaffID: "1",
        TransactionID: "",
    }  



    // Get all rows in the table
    var tableRows = document.querySelectorAll("#product-listing tbody tr");

    // Create an array to store product data
    var productsData = [];

    // Iterate over each row
    tableRows.forEach(function (row) {
        // Extract product ID and quantity from the row
        var productID = row.querySelector('td:nth-child(1)').textContent;
        var quantity = parseInt(row.querySelector('input[type="number"]').value, 10);

        // Create an object with product data
        var productData = {
            TransactionID: "",
            TransactionDetailID: "",
            ProductID: productID,
            Quantity: quantity
        };

        // Push the object to the array
        productsData.push(productData);
    });


    var requestData = {
        TransactionData: transactionData,
        TransactionDetails: productsData
    };



    console.log(requestData)

    fetch('/Home/SendTransaction', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestData)
    })
        .then(data => {
            //console.log('Product added successfully:', data);
            //location.reload();
            // Optionally, perform actions after successful product addition
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}