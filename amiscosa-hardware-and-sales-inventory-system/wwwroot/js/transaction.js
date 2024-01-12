document.addEventListener('DOMContentLoaded', function () {

    setupCustomerSearchSuggestion();
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
    }

]

function setupCustomerSearchSuggestion() {
    var searchCustomerInput = document.querySelector("#search-customer")

    searchCustomerInput.addEventListener("focus", function () {
        var searchSuggestionContainer = document.querySelector(".search-customer-form .search-suggestion-container");
        searchSuggestionContainer.style.display = "block";
    })

    searchCustomerInput.addEventListener("blur", function () {
        hideCustomerSuggestion();

    });

    searchCustomerInput.addEventListener("input", function () {
        showCustomerSuggestion();
    });



}

function showCustomerSuggestion() {
    var searchSuggestionContainer = document.querySelector(".search-customer-form .search-suggestion-container");

    customerInfo.forEach(function (customer) {
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
