document.addEventListener('DOMContentLoaded', function () {

    setupCustomerSearchSuggestion();
    setupProductSearchSuggestion();
    selectCustomer();
    setupCustomNumberInput();

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
        showProductSuggestion();
    });

    searchSuggestionContainer.addEventListener("click", function (event) {
        var clickedCard = event.target.closest(".search-suggestion-card");
        if (clickedCard) {
            fillInputWithProductName(clickedCard);
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

function setupCustomNumberInput() {
    document.querySelectorAll('.custom-number-input').forEach(function (inputGroup) {
        const inputField = inputGroup.querySelector('input[type="number"]');
        const decrementButton = inputGroup.querySelector('.decrement');
        const incrementButton = inputGroup.querySelector('.increment');

        decrementButton.addEventListener('click', function (e) {
            e.preventDefault();
            inputField.stepDown();
            updateTotalPrice(inputField);
        });

        incrementButton.addEventListener('click', function (e) {
            e.preventDefault();
            inputField.stepUp();
            updateTotalPrice(inputField);
        });

        inputField.addEventListener("input", function (e) {
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
