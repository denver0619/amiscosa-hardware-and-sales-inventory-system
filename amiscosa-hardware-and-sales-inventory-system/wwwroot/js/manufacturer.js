document.addEventListener('DOMContentLoaded', function () {

    setupAddManufacturerForm();
    setupEditManufacturerForm();

})

function setupAddManufacturerForm() {
    var addCustomerButton = document.querySelector('.add-manufacturer');
    addCustomerButton.addEventListener('click', function (e) {

        var addManufacturerPopupOverlay = document.createElement('div');
        addManufacturerPopupOverlay.id = 'PopupOverlay';
        addManufacturerPopupOverlay.innerHTML = `    
            <div class="popupCard">
                <button id="exitPopupCard">X</button>
                <h1>Manufacturer Details</h1>
                <form class="popupCardFormContainer">
                
                    <div class="form-row">
                        <div>
                            <label for="ManufacturerName">Manufacturer Name</label>
                            <input type="text" id="ManufacturerName" name="ManufacturerName" value="" />
                        </div>
                        
                    </div>
                
                    <div class="form-row">
                        <div>
                            <label for="ManufacturerAddress">Address</label>
                            <input type="text" id="ManufacturerAddress" name="ManufacturerAddress" value="" />
                        </div>
                        <div>
                            <label for="ManufacturerContact">Contact</label>
                            <input type="text" id="ManufacturerContact" name="ManufacturerContact" value="" />
                        </div>                                           
                    </div>
                 
                
                    <div class="form-row">
                        <button id="submitAdd" class="orange-btn medium">Add Manufacturer</button>
                    </div>
                    
                </form> 
            </div >
        `;

        document.body.append(addManufacturerPopupOverlay);


        // Event Listener for submitting customer info
        document.querySelector('#submitAdd').addEventListener('click', function (e) {
            e.preventDefault();
            //Retrieved input values
            var ManufacturerName = document.getElementById('ManufacturerName').value;
            var ManufacturerAddress = document.getElementById('ManufacturerAddress').value;
            var ManufacturerContact = document.getElementById('ManufacturerContact').value;        

            // VALIDATION CHECKS
            // TO BE CHANGED

            var isError = false;
            if (ManufacturerName === '') {
                applyErrorStyles('ManufacturerName');
                isError = true;
            } else {
                resetErrorStyles('ManufacturerName');
            }

            if (ManufacturerAddress === '') {
                applyErrorStyles('ManufacturerAddress');
                isError = true;
            } else {
                resetErrorStyles('ManufacturerAddress');
            }

            if (ManufacturerContact === '') {
                applyErrorStyles('ManufacturerContact');
                isError = true;
            } else {
                resetErrorStyles('ManufacturerContact');
            }


            // Create an object with the added product data
            var addedManufacturerData = {
                ManufacturerID: "",
                ManufacturerName: ManufacturerName,
                ManufacturerContact: ManufacturerContact,
                ManufacturerAddress: ManufacturerAddress
            };



            // If no error submit data to server
            // TO BE CHANGED
            if (isError == false) {
                addManufacturerFormSendData(addedManufacturerData);
                addManufacturerPopupOverlay.remove();
            }

            // Handle exit from edit
        })

        // Remove the edit pop-up without submitting
        document.getElementById('exitPopupCard').addEventListener('click', function () {

            addManufacturerPopupOverlay.remove();
        });
    })
}

function setupEditManufacturerForm() {
    var editButtons = document.querySelectorAll('.edit-manufacturer')


    editButtons.forEach(function (editButton) {
        editButton.addEventListener('click', function (e) {
            var row = e.target.closest('tr');

            //get data
            var ManufacturerID = row.querySelectorAll('td')[0].textContent;
            var ManufacturerName = row.querySelectorAll('td')[1].textContent;
            var ManufacturerContact = row.querySelectorAll('td')[2].textContent;
            var ManufacturerAddress = row.querySelectorAll('td')[3].textContent;
            

            // Create the edit pop-up elements
            var editManufacturerPopupOverlay = document.createElement('div');
            editManufacturerPopupOverlay.id = 'PopupOverlay';
            editManufacturerPopupOverlay.innerHTML = `
                <div class="popupCard" id="editPopup">
                    <button id="exitPopupCard">X</button>
                    <h1>Manufacturer Details</h1>
                    <p>ID: ${ManufacturerID}</p>
                    <form class="popupCardFormContainer">
                    
                        <div class="form-row">
                            <div>
                                <label for="ManufacturerName">Manufacturer Name:</label>
                                <input type="text" id="ManufacturerName" name="ManufacturerName" value="${ManufacturerName}"/>
                            </div>
                            
                        </div>                                     
                    
                        <div class="form-row">
                            <div>
                                <label for="ManufacturerContact">Manufacturer Contact:</label>
                                <input type="text" id="ManufacturerContact" name="ManufacturerContact" value="${ManufacturerContact}"/>
                            </div>  

                            <div>
                                <label for="ManufacturerAddress">Manufacturer Address:</label>
                                <input type="text" id="ManufacturerAddress" name="ManufacturerAddress" value="${ManufacturerAddress}"/>
                            </div>
                        </div>

                                    
                        <div class="form-row">
                            <button id="submitEdit" class="orange-btn medium">Submit</button>
                        </div>
                    </form>
                </div>
            `;

            document.body.append(editManufacturerPopupOverlay);

            // Handle edit submission
            document.getElementById('submitEdit').addEventListener('click', function (e) {
                // Perform actions to update data using AJAX or other methods
                e.preventDefault();

                // Create an object with the updated product data

                var ManufacturerName = document.getElementById('ManufacturerName').value;
                var ManufacturerContact = document.getElementById('ManufacturerContact').value;
                var ManufacturerAddress = document.getElementById('ManufacturerAddress').value;
                

                // VALIDATION CHECKS
                // TO BE CHANGED
                var isError = false;
                if (ManufacturerName === '') {
                    applyErrorStyles('ManufacturerName');
                    isError = true;
                } else {
                    resetErrorStyles('ManufacturerName');
                }

                if (ManufacturerContact === '') {
                    applyErrorStyles('ManufacturerContact');
                    isError = true;
                } else {
                    resetErrorStyles('ManufacturerContact');
                }

                if (ManufacturerAddress === '') {
                    applyErrorStyles('ManufacturerAddress');
                    isError = true;
                } else {
                    resetErrorStyles('ManufacturerAddress');
                }
        

                // Create an object with the added product data
                var updatedManufacturerData = {
                    ManufacturerID: ManufacturerID,
                    ManufacturerName: ManufacturerName,
                    ManufacturerContact: ManufacturerContact,
                    ManufacturerAddress: ManufacturerAddress,
                };

                console.log(updatedManufacturerData);

                // If no error submit data to server
                // TO BE CHANGED
                if (isError == false) {
                    editManufacturerFormSendData(updatedManufacturerData);
                    editManufacturerPopupOverlay.remove();
                }

                // Handle exit from edit
            });



            // Remove the edit pop-up without submitting
            document.getElementById('exitPopupCard').addEventListener('click', function () {

                editManufacturerPopupOverlay.remove();
            });
        })
    })

}

function addManufacturerFormSendData(addedManufacturerData) {
    fetch('/Home/AddManufacturer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(addedManufacturerData)
    })
        .then(data => {
            location.reload();
            console.log('Product added successfully:', data);

            // Optionally, perform actions after successful product addition
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });
}

function editManufacturerFormSendData(updatedManufacturerData) {
    fetch('/Home/EditManufacturer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedManufacturerData)
    })
        .then(data => {
            location.reload();
            console.log('Product added successfully:', data);

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
