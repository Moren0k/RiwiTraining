//Historia de Usuario 9: Temporizador de Cuenta Regresiva
let segundosTotales = 3670;
let minutos = Math.floor(segundosTotales / 60); // Convertir segundos totales a minutos
let segundos = segundosTotales % 60; // Obtener los segundos restantes después de convertir a minutos
let horas = Math.floor(minutos / 60); // Convertir minutos a horas

console.log(`Tiempo total: ${horas} horas, ${minutos % 60} minutos, ${segundos} segundos`);