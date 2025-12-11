document.addEventListener("DOMContentLoaded", function () {
    const cardInput = document.getElementById("CardNumber");
    const expInput = document.getElementById("ExpDate");

    if (cardInput) {
        cardInput.addEventListener("input", function () {
            let value = this.value.replace(/\D/g, ''); 
            if (value.length > 16) {
                value = value.slice(0, 16); 
            }
            this.value = value.replace(/(\d{4})(?=\d)/g, '$1 '); 
        });
    }

    if (expInput) {
        expInput.addEventListener("input", function () {
            let value = this.value.replace(/\D/g, ''); 
            if (value.length > 4) {
                value = value.slice(0, 4); 
            }
            if (value.length >= 3) {
                this.value = value.slice(0, 2) + '/' + value.slice(2);
            } else {
                this.value = value;
            }
        });
    }
});


