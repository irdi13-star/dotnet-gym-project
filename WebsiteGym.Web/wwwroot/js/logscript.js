document.addEventListener("DOMContentLoaded", function () {
    const registerLink = document.getElementById("registerLink");
    const loginLink = document.getElementById("loginLink");
    const transitionContainer = document.querySelector(".transition-container");
    const formContainer = document.querySelector(".form-container");
    const loginFormContainer = document.getElementById("loginFormContainer");
    const registerFormContainer = document.getElementById("registerFormContainer");
    const leftSection = document.querySelector(".left-section");

    function isMobile() {
        return window.innerWidth <= 768; // Detectează dacă ecranul este de telefon/tabletă
    }

    if (registerLink && loginLink) {
        // Când apasă pe "Register Now"
        registerLink.addEventListener("click", function (event) {
            event.preventDefault();

            if (!isMobile()) {
                transitionContainer.style.transform = "translateX(100%)";
                formContainer.style.transform = "translateX(-100%)";
            }
            
            loginFormContainer.classList.add("d-none");
            registerFormContainer.classList.remove("d-none");

            if (isMobile()) {
                transitionContainer.style.transform = "none"; // Elimină mișcarea pe telefon
                leftSection.style.display = "none"; // Ascunde imaginea pe mobil
            }
        });

        // Când apasă pe "Login"
        loginLink.addEventListener("click", function (event) {
            event.preventDefault();

            if (!isMobile()) {
                transitionContainer.style.transform = "translateX(0)";
            }

            registerFormContainer.classList.add("d-none");
            loginFormContainer.classList.remove("d-none");

            if (isMobile()) {
                transitionContainer.style.transform = "none"; // Elimină mișcarea pe telefon
                leftSection.style.display = "flex"; // Reafișează imaginea pe mobil
            }
        });
    }
});
