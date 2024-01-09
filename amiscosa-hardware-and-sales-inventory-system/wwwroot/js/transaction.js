document.addEventListener('DOMContentLoaded', function () {

/*    document.querySelectorAll('.custom-number-input').forEach(function (inputGroup) {
        inputGroup.addEventListener('click', function (e) {
            e.preventDefault();
            const target = e.target;
            const input = target.closest('.custom-number-input').querySelector('input[type="number"]');

            if (target.classList.contains('increment')) {
                input.stepUp();
            } else if (target.classList.contains('decrement')) {
                input.stepDown();
            }
        });
    });

    document.querySelectorAll('input[type="number"]').forEach(function (inputField) {
        inputField.addEventListener("input", function (e) {
            e.preventDefault();
            console.log(1)
            const row = e.target.closest('tr');
            const quantity = parseFloat(row.querySelectorAll('td')[3].textContent);
            console.log(quantity);

            const unitPrice = parseFloat(row.querySelectorAll('td')[4].textContent);
            const totalPriceElement = row.querySelectorAll('td')[5].textContent;

            const totalPrice = quantity * unitPrice;
            totalPriceElement.textContent = totalPrice.toFixed(2);
        });
    });*/

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
            /*e.preventDefault();
            updateTotalPrice(e.target);*/

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
    });

});
