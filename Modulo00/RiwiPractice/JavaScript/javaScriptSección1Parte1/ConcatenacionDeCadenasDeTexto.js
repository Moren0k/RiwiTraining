/*Construir un número de contacto completo: Tengo el prefijo "Teléfono: " y el
numero "3101234567". Necesito combinarlos para formar el contacto completo y
poder imprimirlo en un directorio.*/

let prefijo = "+57";
let telefono = 3101234567;
let contacto = ("Contacto: ", prefijo + telefono);
console.log(contacto);

/*Crear un mensaje de ubicación personalizado: Quiero generar una frase que
indique mi ubicación. Tengo ciudad = "Medellín" y pais = "Colombia". El mensaje
debe decir: "Estoy en Medellín, Colombia."*/

let cuidad = "Medellín";
let pais = "Colombia";
console.log(`Estoy en ${cuidad}, ${pais}`);

/*Generar una descripción de artículo para un catálogo: Necesito una descripción
estandarizada para mis productos. Si tengo articulo = "Libro" y genero = "Ficción",
quiero que la descripción sea: "El artículo es un Libro de género Ficción.*/

let articulo = "Libro";
let genero = "Ficción";
let descripción = (`El artículo es un ${articulo} De género ${genero}`);
console.log(descripción);

/*Formar una fecha simple: Tengo el dia = "Lunes" y la fecha = 16. Quiero imprimir
la frase "Hoy es Lunes 16". (Recuerda que, dependiendo del lenguaje, puede que
necesites un paso adicional que verás más adelante para unir texto y números
directamente).*/

let dia = "Lunes";
let fecha = 16;
console.log(`Hoy es ${dia}, ${fecha}`);

/*Expresar una preferencia personal: Para mi perfil, quiero una frase que diga lo
que me gusta hacer. Tengo accion = "Aprender" y objeto = "programación". La frase
final debe ser: "Me gusta aprender programación."*/

let accion = "Aprender";
let objeto = "programación";
let fraseFinal = ("Me gusta " + accion + " " + objeto);
console.log(fraseFinal)