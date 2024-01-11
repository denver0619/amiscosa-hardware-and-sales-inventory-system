document.addEventListener('DOMContentLoaded', function () {

    setupAddCustomerForm();
    setupEditCustomerForm();
    
})

function setupAddCustomerForm() {
    var addCustomerButton = document.querySelector('.add-customer');
    addCustomerButton.addEventListener('click', function (e) {

        var addCustomerPopupOverlay = document.createElement('div');
        addCustomerPopupOverlay.id = 'PopupOverlay';
        addCustomerPopupOverlay.innerHTML = `    
            <div class="popupCard">
                <button id="exitPopupCard">X</button>
                <h1>Customer Details</h1>
                <form class="popupCardFormContainer">
                
                    <div class="form-row">
                        <div>
                            <label for="firstName">First Name</label>
                            <input type="text" id="firstName" name="firstName" value="" />
                        </div>
                        
                    </div>
                
                    <div class="form-row">
                        <div>
                            <label for="middleName">Middle Name</label>
                            <input type="text" id="middleName" name="middleName" value="" />
                        </div>
                        <div>
                            <label for="lastName">Last Name</label>
                            <input type="text" id="lastName" name="lastName" value="" />
                        </div>                                           
                    </div>
                
                    <div class="form-row">
                        <div>
                            <label for="address">Address</label>
                            <input type="text" id="address" name="address" value="" />
                        </div>
                    </div>

                    <div class="form-row">
                        <div>
                            <label for="contact">Contact No.</label>
                            <input type="text" id="contact" name="contact" value="" />
                        </div>
                    </div>
                
                    <div class="form-row">
                        <button id="submitAdd" class="orange-btn medium">Add Customer</button>
                    </div>
                    
                </form>
            </div >
        `;

        document.body.append(addCustomerPopupOverlay);


        // Event Listener for submitting customer info
        document.querySelector('#submitAdd').addEventListener('click', function (e) {
            e.preventDefault();
            //Retrieved input values
            var firstName = document.getElementById('firstName').value;
            var middleName = document.getElementById('middleName').value;
            var lastName = document.getElementById('lastName').value;
            var address = document.getElementById('address').value;
            var contact = document.getElementById('contact').value;

            // VALIDATION CHECKS
            // TO BE CHANGED

            var isError = false;
            if (firstName === '') {
                applyErrorStyles('firstName');
                isError = true;
            } else {
                resetErrorStyles('firstName');
            }

            if (lastName === '') {
                applyErrorStyles('lastName');
                isError = true;
            } else {
                resetErrorStyles('lastName');
            }

            if (address === '') {
                applyErrorStyles('address');
                isError = true;
            } else {
                resetErrorStyles('address');
            }

            if (contact === '') {
                applyErrorStyles('contact');
                isError = true;
            } else {
                resetErrorStyles('contact');
            }

            // Create an object with the added product data
            var addedCustomerData = {
                CustomerID: "",
                CustomerFName: firstName,
                CustomerMName: middleName,
                CustomerLName: lastName,
                CustomerAddress: address,
                CustomerContact: contact
            };



            // If no error submit data to server
            // TO BE CHANGED
            if (isError == false) {
                addCustomerFormSendData(addedCustomerData);
                addCustomerPopupOverlay.remove();
            }

            // Handle exit from edit
        })

        // Remove the edit pop-up without submitting
        document.getElementById('exitPopupCard').addEventListener('click', function () {

            addCustomerPopupOverlay.remove();
        });
    })
}

function setupEditCustomerForm() {
    var editButtons = document.querySelectorAll('.edit-customer')


    editButtons.forEach(function (editButton) {
        editButton.addEventListener('click', function (e) {
            var row = e.target.closest('tr');

            //get data
            var customerID = row.querySelectorAll('td')[0].textContent;
            var firstName = row.querySelectorAll('td')[1].textContent;
            var middleName = row.querySelectorAll('td')[2].textContent;
            var lastName = row.querySelectorAll('td')[3].textContent;
            var address = row.querySelectorAll('td')[4].textContent;
            var contact = row.querySelectorAll('td')[5].textContent;

            // Create the edit pop-up elements
            var editCustomerPopupOverlay = document.createElement('div');
            editCustomerPopupOverlay.id = 'PopupOverlay';
            editCustomerPopupOverlay.innerHTML = `
                <div class="popupCard" id="editPopup">
                    <button id="exitPopupCard">X</button>
                    <h1>Customer Details</h1>
                    <p>ID: ${customerID}</p>
                    <form class="popupCardFormContainer" >
                    
                        <div class="form-row">
                            <div>
                                <label for="firstName">First Name:</label>
                                <input type="text" id="firstName" name="firstName" value="${firstName}" />
                            </div>
                            
                        </div>                                     
                    
                        <div class="form-row">
                            <div>
                                <label for="middleName">Middle Name:</label>
                                <input type="text" id="middleName" name="middleName" value="${middleName}" />
                            </div>  
                            <div>
                                <label for="lastName">Last Name:</label>
                                <input type="text" id="lastName" name="lastName" value="${lastName}" />
                            </div>
                        </div>

                        <div class="form-row">
                            <div>
                                <label for="address">Address:</label>
                                <input type="text" id="address" name="address" value="${address}" />
                            </div>                                                   
                        </div>

                        <div class="form-row">
                            <div>
                                <label for="contact">Contact:</label>
                                <input type="text" id="contact" name="contact" value="${contact}" />
                            </div>                                                   
                        </div>
                        
                        <div class="form-row">
                            <button id="submitEdit" class="orange-btn medium">Submit</button>
                        </div>
                    </form>
                </div>
            `;

            document.body.append(editCustomerPopupOverlay);

            // Handle edit submission
            document.getElementById('submitEdit').addEventListener('click', function (e) {
                // Perform actions to update data using AJAX or other methods
                e.preventDefault();

                // Create an object with the updated product data

                var firstName = document.getElementById('firstName').value;
                var middleName = document.getElementById('middleName').value;
                var lastName = document.getElementById('lastName').value;
                var address = document.getElementById('address').value;
                var contact = document.getElementById('contact').value;

                // VALIDATION CHECKS
                // TO BE CHANGED
                var isError = false;
                if (firstName === '') {
                    applyErrorStyles('firstName');
                    isError = true;
                } else {
                    resetErrorStyles('firstName');
                }

                if (lastName === '') {
                    applyErrorStyles('lastName');
                    isError = true;
                } else {
                    resetErrorStyles('lastName');
                }

                if (address === '') {
                    applyErrorStyles('address');
                    isError = true;
                } else {
                    resetErrorStyles('address');
                }

                if (contact === '') {
                    applyErrorStyles('contact');
                    isError = true;
                } else {
                    resetErrorStyles('contact');
                }

                // Create an object with the added product data
                var updatedCustomerData = {
                    firstName: firstName,
                    middleName: middleName,
                    lastName: lastName,
                    address: address,
                    contact: contact
                };

                console.log(updatedCustomerData);

                // If no error submit data to server
                // TO BE CHANGED
                if (isError == false) {
                    editCustomerPopupOverlay.remove();
                }

                // Handle exit from edit
            });



            // Remove the edit pop-up without submitting
            document.getElementById('exitPopupCard').addEventListener('click', function () {

                editCustomerPopupOverlay.remove();
            });
        })
    })

}

function addCustomerFormSendData(addedCustomerData) {
    fetch('/Home/AddCustomer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(addedCustomerData)
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