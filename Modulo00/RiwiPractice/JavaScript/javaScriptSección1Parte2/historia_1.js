//Historia de Usuario 1: Perfil de Usuario Dinámico
let nombreUsuario = "Carlos Gómez";
let edadUsuario = 32;
let saldoCuenta = 1500;
let usuarioPremium = false;

if (saldoCuenta > 1000) {
    usuarioPremium = true;
};

console.log(`El usuario:${nombreUsuario}, Edad:${edadUsuario} Su saldo es: ${saldoCuenta}, y su estado es: ${usuarioPremium}`);