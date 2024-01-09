document.addEventListener('DOMContentLoaded', function () {
    var logoutBtn = document.getElementById("logout-btn");
    console.log(1)
    logoutBtn.addEventListener("click", function(e) {
        e.preventDefault();

        var LogoutPopupOverlay = document.createElement('div');

        LogoutPopupOverlay.id = 'PopupOverlay';
        LogoutPopupOverlay.innerHTML = `
        <div class="logoutCard">
            <p>Are you sure you want to logout?</p>
            <div class="logout-choices">
                <a href="" id="no-btn">No</a>
                <a href="" id="yes-btn">Yes</a>
            </div>
        </div>`

        document.body.append(LogoutPopupOverlay)



        var yesLogout = document.getElementById("yes-btn");
        var noLogout = document.getElementById("no-btn");

        yesLogout.addEventListener("click", function (e) {
            e.preventDefault();


            fetch('/Home/Logout', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json' // Adjust content type as needed
                }
            })
            .then(response => {
                    // Handle the response as needed (e.g., redirect to a new page)
                    window.location.href = '/Account/Login'; // Redirect to the home page after logout
            })
            .catch(error => {
                    // Handle any errors that occur during the request
                    console.error('Error:', error);
            });
        })

        noLogout.addEventListener("click", function (e) {
            e.preventDefault();

            LogoutPopupOverlay.remove();
        })
    })
})
