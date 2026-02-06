

let edad = 17;

if (edad > 18) {
  console.log("Eres mayor de edad.");
} else if (edad === 17) {
  console.log("Casi eres mayor de edad.");
} else {
  console.log("Eres menor de edad.");
}

let diaSemana = "Miercoles";
let mensajeDia;


switch (diaSemana) {
  case "Lunes":
    mensajeDia = "Inicio de semana laboral.";
    break;
  case "Martes":
    mensajeDia = "Martes de trabajo.";
  case "Miercoles": 
    mensajeDia = "Mitad de semana.";
    break;
  default:
    mensajeDia = "Día no reconocido.";
    break;
}
console.log("Mensaje del día: " + mensajeDia);

let temperatura = 25;
let clima = "soleado";


if (temperatura > 20 && clima === "nublado") {
  console.log("Hace calor y está nublado.");
} else if (temperatura <= 20 || clima === "lluvioso") {
  console.log("Hace fresco o está lloviendo.");
} else {
  console.log("Condiciones indeterminadas."); 


const esAdulto = (edad = 18) ? "Sí" : "No"; 
console.log("¿Es adulto? " + esAdulto);
