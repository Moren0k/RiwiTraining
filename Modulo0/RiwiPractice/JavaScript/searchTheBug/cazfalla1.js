
let cantidad = "25";
let precio = 10;


let total = cantidad + precio; 
console.log("El total es: " + total); 
console.log("El tipo de 'total' es: " + typeof total); 

let cadenaNumerica = "123.45";
let numeroEntero = parseInt(cadenaNumerica); 
console.log("Número entero parseado: " + numeroEntero);

let valorBooleano = Boolean(null); // Error 3: ¿Qué resultado esperas al convertir 'null' a booleano?
console.log("Valor booleano de null: " + valorBooleano);

let textoNumerico = "50";let resultadoMultiplicacion = textoNumerico * 2;
console.log("Resultado de la multiplicación: " + resultadoMultiplicacion);
console.log("El tipo de 'resultadoMultiplicacion' es: " + typeof resultadoMultiplicacion);


function saludar(nombre) {
  console.log("Hola, " + nombre + "!");
}

saludar();

function calcularAreaRectangulo(largo, ancho) {
  return largo * ancho;
}

let area = calcularAreaRectangulo(5); 
console.log("El área del rectángulo es: " + area);

function mostrarMensaje() {
  console.log("Este es un mensaje.");
  return; 
  console.log("Este código nunca se ejecutará."); 
}

let mensajeRetornado = mostrarMensaje();
console.log("Lo que retorna mostrarMensaje: " + mensajeRetornado);


miFuncion(a, b) {
    return a + b;
}
