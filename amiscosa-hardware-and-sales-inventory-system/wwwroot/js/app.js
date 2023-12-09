/*document.querySelectorAll('.nav-btn').forEach(navBtnItem => {
    navBtnItem.addEventListener('click', function (e) {
        //e.preventDefault();

        document.querySelectorAll('.nav-btn.current').forEach(btn => {
            btn.classList.remove('current');
        });

        this.classList.add('current');
    });
});*/

document.querySelectorAll('.nav-btn').forEach(navBtnItem => {
    navBtnItem.addEventListener('click', function () {
        // Remove 'current' class from all nav buttons
        document.querySelectorAll('.nav-btn.current').forEach(btn => {
            btn.classList.remove('current');
        });

        // Add 'current' class to the clicked nav button
        this.classList.add('current');
    });
});

/*document.querySelectorAll('.nav-btn').forEach(navBtnItem => {
    navBtnItem.addEventListener('click', function (e) {
        e.preventDefault();
        // Add 'current' class only if it's not already present
        if (!this.classList.contains('current')) {
            document.querySelectorAll('.nav-btn.current').forEach(btn => {
                btn.classList.remove('current');
            });

            this.classList.add('current');
        } else {
            // If 'current' class is already present, let the default link behavior execute
            return true;
        }
    });
});*/

/*document.querySelectorAll('.nav-btn').forEach(navBtnItem => {
    navBtnItem.addEventListener('click', function (e) {
        // Check if the link is an ASP.NET link
        const isAspNetLink = this.hasAttribute('asp-controller') && this.hasAttribute('asp-action');

        // If it's an ASP.NET link, allow the default behavior
        if (isAspNetLink) {
            return true;
        } else {
            // Prevent the default link behavior for non-ASP.NET links
            e.preventDefault();

            // Add 'current' class only if it's not already present
            if (!this.classList.contains('current')) {
                document.querySelectorAll('.nav-btn.current').forEach(btn => {
                    btn.classList.remove('current');
                });

                this.classList.add('current');
            } else {
                // If 'current' class is already present, prevent the default link behavior
                return false;
            }
        }
    });
});*/