let free = false;

function validarCliente(time) {
    let edad = prompt("Cual es tu edad?");
    if (edad > 18) {
        if (time >= 2 && time < 7 && free == false) {
            free = true;
            alert(`Puedes pasar gratis!`);
        } else {
            alert(`Son las ${time}00Hr y puedes pasar pero tenes que pagar`);
        }
    } else {
        alert("Eres menor de edad no puedes pasar!");
    }
}

validarCliente(10)
validarCliente(6)
validarCliente(2)
validarCliente(20)