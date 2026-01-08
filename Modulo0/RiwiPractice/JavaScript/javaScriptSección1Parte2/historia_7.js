//Historia de Usuario 7: Monitoreo de Estado de Servidor
let servidor = {
    nombre: "Web_Server_01",
    status: "Activo",
    pingMs: 24,
};

let mensajeEstado = (`El servidor: ${servidor["nombre"]}
Estado: ${servidor["status"]}
Con una latencia: ${servidor["pingMs"]}.`);

console.log(mensajeEstado);