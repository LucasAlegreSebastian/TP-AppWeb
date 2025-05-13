console.log("Hola que tal, que andas viendo la consola 👀");


//Funcion de bootstraps validaciones
(function () {
    'use strict';
    window.addEventListener('load', function () {
        var forms = document.getElementsByClassName('needs-validation');
        Array.prototype.forEach.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();


//Validacion de campos del formulario
document.addEventListener("DOMContentLoaded", function () {
    const btn = document.getElementById("MainContent_btnParticipar");
    if (!btn) return;

    btn.addEventListener("click", function (event) {
        // Limpiar espacios de campos
        const camposVerificarTrim = [
            "MainContent_txtNombre",
            "MainContent_txtApellido",
            "MainContent_txtDireccion",
            "MainContent_txtCiudad"
        ];

        camposVerificarTrim.forEach(function (id) {
            const campos = document.getElementById(id);
            if (campos) {
                campos.value = campos.value.trim().replace(/\s+/g, ' ');
            }
        });

        // Validación de DNI
        const dni = document.getElementById("MainContent_txtDni");
        if (dni) {
            const dniValor = dni.value.trim();
            if (dniValor.length < 7 || dniValor.length > 50 || !/^\d+$/.test(dniValor)) {
                dni.classList.add("is-invalid");
                event.preventDefault();
                event.stopPropagation();
            } else {
                dni.classList.remove("is-invalid");
                dni.classList.add("is-valid");
            }
        }
    });
});


document.addEventListener('DOMContentLoaded', () => {
    const track = document.getElementById('logoTrack');
    if (!track) return; // Si no existe

    const logos = Array.from(track.children);
    logos.forEach(logo => {
        const clone = logo.cloneNode(true);
        track.appendChild(clone);
    });
});