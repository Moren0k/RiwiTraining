//JavaScript - Conceptos Básicos
/* JavaScript es un lenguaje de programación interpretado, de alto nivel y con tipado dinámico. */
/* Se utiliza principalmente para crear páginas web interactivas y dinámicas. */

//CamelCase
/* Ejemplo de uso de CamelCase
   En JavaScript, es común usar CamelCase para nombrar variables y funciones.
   Se inicia con una letra minúscula y cada nueva palabra comienza con una letra mayúscula.
   Por ejemplo: nombreCompleto, calcularSuma, obtenerDatos. */

var ejemploDeUsoDeCamelCase

//Variables
/* palabraClave nombreVariable = valor;. */
let variableQuePuedeCambiar = "Soy una variable que puede cambiar su valor"; // Se declara una variable que puede cambiar su valor
const variableQueNoPuedeCambiar = "Soy una variable que no puede cambiar su valor (constante)"; // Se declara una variable que no puede cambiar su valor (constante)
var variableGlobal = "Soy una variable global"; // Se declara una variable global (no se recomienda su uso en la actualidad)

let declararVariable; // Se declara la varible pero no se inicializa
let declararIniciarVariable = "Hola" // Se declara la variable y se inicializa

//Tipos De Datos
String = "Cadena de texto"; // Cadena de texto
Number = 123; // Número
Boolean = true; // Valor booleano (true o false)

//Undefined, Null, NaN
let undefined; // Fue declarada pero no inicializada
let Null = null // Para decir que la variable está vacía a propósito
let Nan = "abc" / 2; // Ocurre cuando: intentas hacer operaciones matemáticas con algo que no es numérico

//Prompt
prompt("Mensaje de solicitud", "valor predeterminado");
let nombre = prompt("¿Cómo te llamas?", "Tu nombre acá"); // Lo guarda en la variable nombre

//Alert
alert("Mensaje de alerta"); // Muestra un mensaje emergente al usuario

//Confirm
let confirmacion = confirm("¿Estás seguro?"); // Muestra un mensaje de confirmación y guarda el resultado (true/false) en la variable confirmacion

//Concatenación
let saludo = "Hola" + " " + "Mundo"; // Une dos cadenas de texto
let numeroTexto = "El número es: " + 5; // Convierte el número a texto y lo concatena
let concatenacionCompleta = `Hola, ${saludo}, el número es: ${numeroTexto}`; // Usando comillas invertidas para una concatenación más legible

//Operadores Aritméticos
let suma = 5 + 3; // Suma
let resta = 5 - 3; // Resta
let multiplicacion = 5 * 3; // Multiplicación
let division = 5 / 3; // División
let modulo = 5 % 3; // Módulo (resto de la división)
incremento++; // Incrementa en 1
decremento--; // Decrementa en 1

//Operadores De Asignación
/* Los operadores de asignación se utilizan para asignar valores a variables. */
let asignacion = 10; // Asignación simple
asignacion += 5; // Asignación con suma (equivalente a asignacion = asignacion + 5) Es decir: 10 + 5 = 15
asignacion -= 5; // Asignación con resta (equivalente a asignacion = asignacion - 5) Es decir: 10 - 5 = 5
asignacion *= 2; // Asignación con multiplicación (equivalente a asignacion = asignacion * 2) Es decir: 10 * 2 = 10
asignacion /= 2; // Asignación con división (equivalente a asignacion = asignacion / 2) Es decir: 10 / 2 = 5
asignacion %= 2; // Asignación con módulo (equivalente a asignacion = asignacion % 2) Es decir: 10 % 2 = 0
asignacion **= 2; // Asignación con exponenciación (equivalente a asignacion = asignacion ** 2) Es decir: 10 ** 2 = 100

//Operadores De Comparación
/* Los operadores de comparación se utilizan para comparar valores y devuelven un valor booleano (true o false). */
let esIgual = (5 == 5); // Igualdad (valor)
let esIdentico = (5 === 5); // Identidad (valor y tipo)
let esDiferente = (5 != 3); // Diferencia (valor)
let esNoIdentico = (5 !== 3); // No identidad (valor y tipo)
let esMayor = (5 > 3); // Mayor que
let esMenor = (5 < 3); // Menor que
let esMayorOIgual = (5 >= 3); // Mayor o igual que
let esMenorOIgual = (5 <= 3); // Menor o igual que

//Operadores Lógicos
/* Los operadores lógicos se utilizan para combinar o invertir valores booleanos. */
let and = (true && false); // AND lógico es verdadero si ambos son verdaderos (Devuelve: false)
let or = (true || false); // OR lógico es verdadero si al menos uno es verdadero (Devuelve: true)
let not = !true; // NOT lógico invierte el valor booleano (Devuelve: false)

//Condicionales
/* La estructura básica de una sentencia if es: */
if (condicion) {
    // Código a ejecutar si la condición es verdadera
}
else if (otraCondicion) {
    // Código a ejecutar si la otra condición es verdadera
}
else {
    // Código a ejecutar si ninguna de las condiciones anteriores es verdadera
};

//Arrays o Listas
/* Un array es una colección de elementos, que pueden ser de cualquier tipo de dato. */
let arrayVacio = []; // Un array vacío
let arrayNumeros = [0, 1, 2]; // Un array con números
let arrayCadenas = ["cero", "uno", "dos"]; // Un array con cadenas de texto
let arrayBooleanos = [true, false, true]; // Un array con valores booleanos

//Mostrar Un Array En La Consola
console.log(arrayNumeros); // Muestra el array en la consola

//Acceso A Elementos Del Array
/* Las posiciones de los elementos en un array comienzan desde 0. 
   let array = [posición0, posición1, posición2];
   para acceder a un elemento, se usa el nombreDelArray[posición];. */
let primerElemento = arrayNumeros[0]; // Accede al primer elemento (0)
let segundoElemento = arrayNumeros[1]; // Accede al segundo elemento (1)

//Array Asociativo
/* Un array asociativo es un array que usa cadenas de texto como índices en lugar de números. 
   Se usa un objeto en lugar de un array para crear un array asociativo. */
let arrayAsociativo = {
    "posicion0": "valor1",
    "posicion1": "valor2",
    "posicion2": "valor3"
};

//Acceso A Elementos Del Array Asociativo
let valor1 = arrayAsociativo["posicion0"]; // Accede al valor de la posición "posicion0" y muestra "valor1"
let valor2 = arrayAsociativo["posicion1"]; // Accede al valor de la posición "posicion1" y muestra "valor2"
let valor3 = arrayAsociativo["posicion2"]; // Accede al valor de la posición "posicion2" y muestra "valor3"

//Bucles E Iteraciones
/* Los bucles se utilizan para repetir un bloque de código varias veces.
   Existen diferentes tipos de bucles, como for, while y do-while. */

//While
/* Un bucle while ejecuta un bloque de código infinitamente mientras una condición sea verdadera. 
   La sintaxis básica es:. */
while (condicion) {
    // Código a ejecutar
};

contador = 0; // Inicializa un contador
while (contador < 5) { // Mientras el contador sea menor que 5
    contador++; // Incrementa el contador en 1
    // Si el contador llega a 5, el bucle se detiene
}

//Do-While
/* Un bucle do-while ejecuta un bloque de código al menos una vez y luego verifica la condición. 
   La sintaxis básica es:. */
do {
    // Código a ejecutar
} while (condicion);

contador = 0; // Inicializa un contador
do {
    contador++; // Incrementa el contador en 1
} while (contador < 5); // Mientras el contador sea menor que 5
// El bucle se ejecuta al menos una vez, incluso si la condición es falsa desde el principio

//Break
/* La instrucción break se utiliza para salir de un bucle antes de que se complete su iteración. 
   Se puede usar en cualquier tipo de bucle.
   La sintaxis básica es:. */
contador = 0; // Inicializa un contador
while (contador < 10) { // Mientras el contador sea menor que 10
    contador++; // Incrementa el contador en 1
    if (contador === 5) { // Si el contador es igual a 5
        break; // Sale del bucle
        // El bucle se detiene cuando el contador llega a 5, por lo que no se muestra el valor 5 en la consola
    }
};

//For
/* Un bucle for se utiliza para iterar sobre un rango de valores o elementos de un array. 
   La sintaxis básica es:

   declararVariable; // Inicializa una variable
   for (inicialización; condición; actualización) {
    // Código a ejecutar
   }. */
for (let incremento = 0; incremento < 6; incremento++) {
    console.log(incremento); // Muestra los números del 0 al 5 en la consola
};

//Continue
/* La instrucción continue se utiliza para saltar a la siguiente iteración de un bucle. 
   Se puede usar en cualquier tipo de bucle.
   La sintaxis básica es:. */
contador = 0; // Inicializa un contador
while (contador < 10) { // Mientras el contador sea menor que 10
    contador++; // Incrementa el contador en 1
    if (contador === 5) { // Si el contador es igual a 5
        continue; // Salta a la siguiente iteración del bucle
        // El valor 5 no se muestra en la consola, pero el bucle continúa con el siguiente valor
    }
};

//For...In
/* El bucle for...in se utiliza para iterar sobre las propiedades enumerables de un objeto. 
   La sintaxis básica es:
   for (variable in objeto) {
    // Código a ejecutar
   }. */
let objeto = ["valor1", "valor2", "valor3"];
for (let i in objeto) {
    console.log(i); // Muestra las propiedades del objeto en la consola
    // Muestra los índices de los valores del objeto en la consola (0, 1, 2)
}

//For...Of
/* El bucle for...of se utiliza para iterar sobre los valores de un objeto iterable, como un array. 
   La sintaxis básica es:
   for (variable of objetoIterable) {
    // Código a ejecutar
   }. */
let iterable = ["valor1", "valor2", "valor3"];
for (let valor of iterable) {
    console.log(valor); // Muestra los valores del objeto iterable en la consola
    // Muestra los valores del iterable en la consola ("valor1", "valor2", "valor3")
}

//Funciones
/* Las funciones son bloques de código reutilizables que realizan una tarea específica.
   Se pueden definir con la palabra clave function, seguida del nombre de la función, paréntesis y llaves.
   La sintaxis básica es:
   function nombreFuncion(parametros) {
       // Código a ejecutar
   }. */
function saludar() {
    let nombre = "Mundo"; // Variable local dentro de la función
    console.log("Hola, " + nombre);
}
    // Llamada a la función
    saludar(); // Muestra "Hola, Mundo" en la consola

//Funciones Con Parámetros y Retorno
/* Las funciones pueden aceptar parámetros y devolver un valor.
   La sintaxis básica es:
   function nombreFuncion(parametros) {
       // Código a ejecutar
       return valor; // Devuelve un valor
   }. */
function sumar() {
    let numero1 = 2
    let numero2 = 3
    let resultado = numero1 + numero2; // Suma los dos Números
    return resultado; // Devuelve el resultado de la suma
}
    // Llamada a la función y almacenamiento del resultado
    let resultadoSuma = sumar(); // Llama a la función y guarda el resultado en la variable resultadoSuma
    console.log(resultadoSuma); // Muestra el resultado de la suma en la consola (5)

//Funciones Con Parámetros
/* Las funciones pueden aceptar parámetros para recibir valores externos.
   La sintaxis básica es:
   function nombreFuncion(parametro1, parametro2) {
       // Código a ejecutar
       return valor; // Devuelve un valor
   }. */
function multiplicar(numero1, numero2) {
    let resultado = numero1 * numero2; // Multiplica los dos números
    return resultado; // Devuelve el resultado de la multiplicación
}
    // Llamada a la función con parámetros
    let resultadoMultiplicacion = multiplicar(4, 5); // Llama a la función con los números 4 y 5
    console.log(resultadoMultiplicacion); // Muestra el resultado de la multiplicación en la consola (20)
    // Reutilización de la función con diferentes parámetros
    let otroResultadoMultiplicacion = multiplicar(2, 3); // Llama a la función con los números 2 y 3
    console.log(otroResultadoMultiplicacion); // Muestra el resultado de la multiplicación en la consola (6)

//Funciones Flecha
/* Las funciones flecha son una forma más concisa de definir funciones en JavaScript.
   La sintaxis básica es:
   const nombreFuncion = (parametros) => {
       // Código a ejecutar
       return valor; // Devuelve un valor
   }. */
const saludarFlecha = (nombre) => console.log("Hola, " + nombre);
    // Llamada a la función flecha
    saludarFlecha("Mundo"); // Muestra "Hola, Mundo" en la consola

//POO (Programación Orientada a Objetos)
/* La Programación Orientada a Objetos (POO) es un paradigma de programación que
   organiza el código en objetos que contienen propiedades y métodos.
   En JavaScript, los objetos se pueden crear utilizando la sintaxis de objeto literal o mediante
   la creación de clases. */

//Clases
/* Una clase es una plantilla para crear objetos. 
   Define las propiedades y métodos que tendrán los objetos creados a partir de ella.
   La sintaxis básica es:
   class NombreClase {
       constructor(parametros) {
           // Inicialización de propiedades
       }
       metodo() {
           // Código del método
       }
   }. */
class animal {
    constructor(especie,edad,color){
        this.especie = especie;
        this.edad = edad;
        this.color = color;
        this.info = `Soy ${this.especie}, Tengo ${this.edad} años y soy de color ${this.color}.`;
    };
};
let perro = new animal("perro",5,"blanco");
console.log(perro.info);

//Metodos
/* Un método es una función definida dentro de una clase que puede ser llamada en los objetos creados a partir de esa clase.
   La sintaxis básica es:
   class NombreClase {
       constructor(parametros) {
           // Inicialización de propiedades
       }
       metodo() {
           // Código del método
       }
   }. */
class persona {
    constructor(nombre,edad,altura){
        this.nombre = nombre;
        this.edad = edad;
        this.altura = altura;
        this.info = `Hola! Soy ${this.nombre}, Tengo ${this.edad} años y mi altura es ${this.altura}.`;
    };
    verInfo(){ // Método para mostrar la información de la persona
        console.log(this.info)
    }
    caminar(){ // Método para simular que la persona camina
        console.log(`${this.nombre} está caminando.`)
    }
    ladrar(){
        if (this.nombre === "perro") {
            console.log(`${this.nombre} está ladrando.`)
        }
        else {
            console.log(`${this.nombre} no puede ladrar porque no es un perro.`)
        }
    }
}
let kevin = new persona("Kevin Moreno",20,"1.60cm") // Crea una instancia de la clase persona
kevin.verInfo(); // Muestra la información de la persona en la consola
kevin.caminar(); // Llama al método caminar de la persona
let perros = new persona("perro",5,"blanco"); // Crea una instancia de la clase persona con el nombre "perro"
kevin.ladrar(); // Llama al método ladrar de la persona devuelve "Kevin Moreno no puede ladrar porque no es un perro."
perros.ladrar(); // Llama al método ladrar de la persona devuelve "perro está ladrando."

//Herencia
/* La herencia permite que una clase herede propiedades y métodos de otra clase.
   La sintaxis básica es:
   class ClaseBase {
       constructor(parametros) {
           // Inicialización de propiedades
       }
       metodo() {
           // Código del método
       }
   } */
class humano extends persona { // La clase humano hereda de la clase persona
    constructor(nombre,edad,altura){
        super(nombre,edad,altura); // Llama al constructor de la clase base
    }
    diceLaEdad(){
        console.log(`${this.nombre} tiene ${this.edad} años.`);
    }
}

let juan = new humano("Kevin Moreno",20,"1.60cm"); // Crea una instancia de la clase humano
juan.diceLaEdad(); // Llama al método diceLaEdad de la persona devuelve "Kevin Moreno tiene 20 años."

// Métodos De Cadenas
/* Para usar los métodos con la cadena, se puede utilizar la sintaxis:
   cadena.metodo(); */
let cadena = "Hola, Mundo!";
cadena.length; // Devuelve la longitud de la cadena. #Muestra 13
cadena.charAt(0); // Devuelve el carácter en la posición 0 de la cadena. #Muestra "H"
cadena.concat(" Adiós!"); // Concatena una cadena al final de la cadena original. #Muestra "Hola, Mundo! Adiós!"
cadena.startsWith("Hola"); // Verifica si la cadena comienza con "Hola". #Muestra true
cadena.endsWith("Mundo!"); // Verifica si la cadena termina con "Mundo!". #Muestra true
cadena.includes("Mundo"); // Verifica si la cadena contiene "Mundo". #Muestra true
cadena.indexOf("M"); // Devuelve la posición de la primera aparición de "M" en la cadena. #Muestra 6
cadena.lastIndexOf("o"); // Devuelve la posición de la última aparición de "o" en la cadena. #Muestra 10

cadena.padStart(10, "*"); // Agrega asteriscos al inicio de la cadena hasta que tenga una longitud de 10. #Muestra "*****Hola, Mundo!"
cadena.padEnd(10, "*"); // Agrega asteriscos al final de la cadena hasta que tenga una longitud de 10. #Muestra "Hola, Mundo!*****"
cadena.repeat(2); // Repite la cadena 2 veces. #Muestra "Hola, Mundo!Hola, Mundo!"

cadena.split(","); // Divide la cadena en un array utilizando "," como separador. #Muestra ["Hola", " Mundo!"]
cadena.substring(0, 5); // Extrae una parte de la cadena desde el índice 0 hasta el 5. #Muestra "Hola, "
cadena.slice(0, 5); // Extrae una parte de la cadena desde el índice 0 hasta el 5. #Muestra "Hola "

cadena.toLowerCase(); // Convierte la cadena a minúsculas. #Muestra "hola, mundo!"
cadena.toUpperCase(); // Convierte la cadena a mayúsculas. #Muestra "HOLA, MUNDO!"

let cadena1 = " Hola, Mundo! ";
cadena1.trim(); // Elimina los espacios en blanco al inicio y al final de la cadena. #Muestra "Hola, Mundo!"
cadena1.trimStart(); // Elimina los espacios en blanco al inicio de la cadena. #Muestra "Hola, Mundo! "
cadena1.trimEnd(); // Elimina los espacios en blanco al final de la cadena. #Muestra " Hola, Mundo!"

let num = 123.456;
num.toString(); // Convierte el número a cadena de texto. #Muestra "123.456"
num.toFixed(1); // Formatea el número a una cadena con 1 decimal. #Muestra "123.5"

// Métodos de arrays
/* Los métodos de arrays se aplican igual que los métodos de cadenas, pero se utilizan en arrays */
let metodosArrayNumeros = [1, 2, 3, 4, 5];
let metodosArrayCadenas = ["Hola", "Mundo", "JavaScript"];

metodosArrayNumeros.pop(); // Elimina el último elemento del array y lo devuelve. #Muestra 5
metodosArrayNumeros.shift(); // Elimina el primer elemento del array y lo devuelve. #Muestra 1
metodosArrayNumeros.push(6); // Agrega un elemento al final del array. // Ahora el array es [2, 3, 4, 5, 6]
metodosArrayNumeros.unshift(0); // Agrega un elemento al inicio del array. // Ahora el array es [0, 2, 3, 4, 5, 6]
metodosArrayNumeros.reverse(); // Invierte el orden de los elementos del array // Ahora el array es [6, 5, 4, 3, 2, 0]
metodosArrayNumeros.sort(); // Ordena los elementos del array en orden ascendente // Ahora el array es [0, 2, 3, 4, 5, 6]
metodosArrayNumeros.splice(1, 2); // Elimina 2 elementos a partir del índice 1 // Ahora el array es [0, 4, 5, 6]
metodosArrayNumeros.splice(1, 0, 3); // Inserta el número 3 en el índice 1 sin eliminar ningún elemento // Ahora el array es [0, 3, 4, 5, 6]
metodosArrayNumeros.splice(0, 1, 2); // Reemplaza el elemento en la posición (0) por 2 // Ahora el array es [2, 3, 4, 5, 6]

/* Métodos Accesores */
metodosArrayCadenas.join(", "); // Une los elementos del array en una cadena de texto, separados por ", ". #Muestra "Hola, Mundo, JavaScript"
metodosArrayCadenas.slice(0, 2); // Extrae una parte del array desde el índice 0 hasta el 2 (sin incluir el 2). #Muestra ["Hola", "Mundo"]

metodosArrayCadenas.includes("Mundo"); // Verifica si el array contiene el elemento "Mundo". #Muestra true
metodosArrayCadenas.indexOf("JavaScript"); // Devuelve la posición del primer elemento "JavaScript" en el array. #Muestra 2
metodosArrayCadenas.lastIndexOf("Hola"); // Devuelve la posición del último elemento "Hola" en el array. // Muestra 0

/* Métodos De Repetición */
metodosArrayCadenas.filter(elemento => elemento.length > 6); // Filtra los elementos del array que tienen una longitud mayor a 6. #Muestra ["JavaScript"]

// Objeto Math - Básico
/* El objeto Math proporciona propiedades y métodos para realizar operaciones matemáticas.
   Se utiliza directamente sin necesidad de crear una instancia.
   Algunos de sus métodos más comunes son: */
let numeroMath = 20;
Math.sqrt(numeroMath); // Devuelve la raíz cuadrada del número. #Muestra 4.47213595499958
Math.cbrt(numeroMath); // Devuelve la raíz cúbica del número. #Muestra 2.7144176165949063

Math.max(1, 2, 3); // Devuelve el valor máximo de los números proporcionados. #Muestra 3
Math.min(1, 2, 3); // Devuelve el valor mínimo de los números proporcionados. #Muestra 1
Math.random(); // Devuelve un número pseudo aleatorio entre 0 (incluido) y 1 (excluido). #Muestra un número aleatorio
Math.round(5.999999); // Redondea un número al entero más cercano. #Muestra 6
Math.floor(5.999999); // Redondea un número hacia abajo al entero más cercano. #Muestra 5
Math.ceil(5.000001); // Redondea un número hacia arriba al entero más cercano. #Muestra 6
Math.trunc(5.999999); // Redondea un número hacia cero al entero más cercano. #Muestra 5

/* Propiedades */
Math.PI; // Devuelve el valor de PI. #Muestra 3.141592653589793
Math.E; // Devuelve el valor de e. #Muestra 2.718281828459045
Math.LN2; // Devuelve el logaritmo natural de 2. #Muestra 0.6931471805599453
Math.LN10; // Devuelve el logaritmo natural de 10. #Muestra 2.302585092994046
Math.LOG2E; // Devuelve el logaritmo en base 2 de e. #Muestra 1.442695040888963
Math.LOG10E; // Devuelve el logaritmo en base 10 de e. #Muestra 0.4342944819032518
Math.SQRT1_2; // Devuelve la raíz cuadrada de 1/2. #Muestra 0.7071067811865476
Math.SQRT2; // Devuelve la raíz cuadrada de 2. #Muestra 1.4142135623730951