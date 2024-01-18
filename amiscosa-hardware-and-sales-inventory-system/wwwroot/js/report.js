document.addEventListener("DOMContentLoaded", function () {
    // Get current date
    var currentDate = new Date();
    currentDate.setDate(1);
    var currentMonth = currentDate.toISOString().split('T')[0];

    // Set the default selected value for the dropdown
    var monthDropdown = document.getElementById("month-dropdown");
    monthDropdown.value = currentMonth;

    // Add event listener for the change event on the dropdown
    monthDropdown.addEventListener("change", function () {
        updateContent();
    });

});

function updateContent() {
    // Clear the table initially
    clearTable();

    var selectedMonth = document.getElementById("month-dropdown").value;
    console.log(selectedMonth);

    var selectedDate = JSON.stringify(selectedMonth);
    // Make a Fetch request to the controller action
    fetch('/Home/GetReportData', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: selectedDate // Send the selectedMonth as JSON
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            // Update the HTML elements with the retrieved data
            document.getElementById("total-revenue").innerHTML = "₱ " + data.totalRevenue;
            document.getElementById("total-profit").innerHTML = "₱ " + data.totalProfit;
            document.getElementById("transactions-done").innerHTML = data.numberOfTransactionsDone;

            // Convert productTally object to an array
            var productTallyArray = Object.values(data.productTally);

            // Check if productTallyArray is an array
            if (Array.isArray(productTallyArray)) {
                // Calculate the total products sold from the product tally
                var totalProductsSold = productTallyArray.reduce((total, tally) => total + tally, 0);
                document.getElementById("products-sold").innerHTML = totalProductsSold;

                // Update the sales table
                updateSalesTable(data.productList, productTallyArray);
            } else {
                console.error("ProductTally is not an array.");
            }
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
}


function clearTable() {
    // Clear existing rows
    var tableBody = document.getElementById("sales-table-body");
    tableBody.innerHTML = '';
}

function updateSalesTable(productList, productTally) {
    // Update the sales table
    var tableBody = document.getElementById("sales-table-body");

    if (productList && productList.length > 0) {
        for (var i = 0; i < productList.length; i++) {
            var row = tableBody.insertRow(); // Do not specify an index
            row.insertCell(-1).innerHTML = i + 1;
            row.insertCell(-1).innerHTML = productList[i].productName;
            row.insertCell(-1).innerHTML = productTally[i]; // Display the tally instead of quantity
            row.insertCell(-1).innerHTML = "₱ " + productList[i].productSales;
        }
    } else {
        console.error("ProductList is undefined or empty.");
        // Optionally, display a message or handle the case when there is no data.
    }
}
