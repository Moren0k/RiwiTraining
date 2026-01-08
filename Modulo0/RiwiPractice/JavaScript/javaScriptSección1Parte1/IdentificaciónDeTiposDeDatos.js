/*Verificar el tipo de un código postal: Tengo un código postal "05001" guardado.
Necesito saber si es tratado como texto o número, así que quiero imprimir tanto
su valor como su tipo de dato*/

let codigoPostal = "05001";
console.log(codigoPostal, typeof codigoPostal);
//typeof Muestra que tipo de dato es (string, number, boolean, undefined, etc)

/*Confirmar el tipo de un conteo de empleados: Manejo el número de empleados
de una sucursal, que es 50. Es crucial confirmar que este número se almacene como
un tipo entero. Imprime su valor y su tipo.*/

let numeroDeEmpleados = 50;
console.log(parseInt(numeroDeEmpleados), typeof numeroDeEmpleados, Number.isInteger(numeroDeEmpleados));
//parseInt Convierte el dato de la variable en un Int(Entero)
//Number.isInteger Muestra y devuelve true si el numero es entero, false si es un numero decimal

/*Asegurar el tipo de un porcentaje: El porcentaje de IVA es 0.19. Para cálculos
precisos, debo verificar que este valor se interprete como un número decimal.
Imprime su valor y su tipo*/

let iva = 0.19;
console.log(iva, Number.isInteger()); //Devuelve false ya que no es un numero entero, Es un numero decimal

/*Comprobar el estado de disponibilidad: Hay una variable disponible con el valor
False. Necesito imprimir tanto su valor como su tipo de dato para confirmar que es
un booleano.*/

let disponible = false;
console.log(disponible, typeof disponible);

/*Clasificar información variada: Para organizar mis datos sobre animales, he
registrado el animal = "perro", su numero_patas = 4 y si es_mamifero = True.
Quiero imprimir el tipo de dato de cada una de estas variables para asegurar su
correcta categorización.*/

let animal = "perro"
let numeroPatas = 4
let esMamifero = true
console.log(typeof animal, typeof numeroPatas, typeof esMamifero)