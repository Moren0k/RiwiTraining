# Ejercicio de practica JavaScript sección 2 parte 1

## Sesión 1: Variables y Condicionales

1. Clasificación de edades
Como desarrollador de una app de registro, quiero clasificar a las personas por rango de edad
(niñez, adolescencia, adultez, adultez mayor) para personalizar la experiencia del usuario.
2. Comparador de tres números
Como usuario de una calculadora, quiero saber cuál de tres números ingresados es el mayor
o si hay empate para tomar decisiones basadas en comparación.
3. Verificación múltiple
Como estudiante, quiero ingresar un número y saber si es divisible por 3, 5 o ambos, para
practicar lógica matemática.
4. Validación de acceso con rol
Como administrador del sistema, quiero validar si un usuario tiene credenciales y rol de
superusuario para permitir o denegar el acceso a funcionalidades críticas.
5. Validar año bisiesto
Como organizador de eventos, quiero saber si un año es bisiesto para planificar
correctamente los calendarios anuales.

## Sesión 2: Estructuras de Control y Funciones

1. Generar patrón de triángulo
Como usuario de una herramienta educativa, quiero generar un patrón de triángulo de
asteriscos para visualizar estructuras en la consola.
2. Verificar número capicúa
Como usuario de una app matemática, quiero saber si un número es capicúa para aprender
sobre simetrías numéricas.
3. Contador de palabras
Como escritor digital, quiero saber cuántas palabras tiene un texto ingresado para controlar
la extensión de mis escritos.
4. Validación de contraseña segura
Como desarrollador de formularios, quiero verificar que una contraseña contenga caracteres
seguros para evitar vulnerabilidades.
5. Juego piedra, papel o tijera
Como jugador, quiero competir contra la computadora en un juego de piedra, papel o tijera
para divertirme y practicar lógica condicional.
6. Invertir una cadena
Como programador, quiero invertir una cadena sin funciones nativas para entender mejor las
estructuras de bucles y arreglos.
7. Validar estructura de correo
Como desarrollador de un formulario de contacto, quiero validar que el correo electrónico
ingresado tenga un formato válido para evitar errores de envío.
8. Encontrar carácter no repetido
Como lector de cadenas, quiero detectar el primer carácter único en una frase para
identificar patrones relevantes.

## Sesión 3: Estructuras de Datos y Truthy/Falsy

1. Frecuencia de caracteres
Como analista de texto, quiero contar cuántas veces aparece cada letra en un texto para
realizar análisis de frecuencia.
2. Filtrar edades válidas
Como responsable de encuestas, quiero limpiar una lista de edades eliminando valores
inválidos o vacíos para obtener resultados precisos.
3. Promedio de calificaciones
Como profesor virtual, quiero calcular el promedio de notas de los estudiantes para evaluar
el rendimiento del grupo.
4. Transformar arreglo a diccionario
Como desarrollador backend, quiero convertir un array de objetos con IDs a un objeto tipo
diccionario para acceder más fácilmente a los datos.
5. Buscar producto en inventario
Como gestor de tienda online, quiero encontrar un producto por su código dentro del
inventario para mostrar su información al cliente.
6. Eliminar duplicados
Como desarrollador, quiero eliminar los elementos duplicados de un arreglo para garantizar
la unicidad de los datos.
7. Reemplazar valores falsy
Como programador, quiero recorrer un arreglo y reemplazar los valores falsy por “N/A” para
asegurarme de tener datos visibles y coherentes.
lenguaje norma

## Sesión 1: Variables y Condicionales (Dificultad media)

1. Clasificador de edades
Declara una variable edad y usa condicionales para clasificarla como:
• "Niñez" (0-12)
• "Adolescencia" (13-17)
• "Adulto" (18-59)
• "Adulto mayor" (60+)
2. Comparador de tres números
Pide tres números diferentes y muestra cuál es el mayor. Considera también si hay algún
empate.
3. Verificación múltiple
Crea una variable numero y muestra si:
• Es divisible por 3
• Es divisible por 5
• Es divisible por ambos
• No es divisible por ninguno
4. Validación de acceso con rol
Simula un sistema que permita acceso solo si el usuario tiene la combinación correcta de
usuario === "admin" y rol === "superusuario".
5. Año bisiesto
Crea una función que reciba un año y determine si es bisiesto. (Pista: divisible por 4 y no
por 100, excepto si es divisible por 400).

## Sesión 2: Estructuras de Control y Funciones (Dificultad media)

1. Generar patrón de triángulo
Crea una función que reciba un número n y devuelva un triángulo de asteriscos con n filas
(ejemplo: para n = 3: *, **, ***).
2. Verificar número capicúa (palíndromo)
Crea una función que determine si un número (por ejemplo 12321) es igual al invertido.
3. Contador de palabras
Escribe una función que reciba una cadena y cuente cuántas palabras tiene. Considera
múltiples espacios y puntuación.
4. Validación de contraseña segura
Valida si una contraseña contiene al menos una mayúscula, una minúscula, un número y
un carácter especial (!@#$%^&*).
5. Juego piedra, papel o tijera
Simula una ronda de "piedra, papel o tijera" contra la computadora. La computadora debe
elegir aleatoriamente.
6. Invertir una cadena
Haz una función que reciba una cadena y devuelva su reverso sin usar .reverse().
7. Mini validador de correo
Escribe una función que reciba un string y valide si tiene estructura básica de email: un @
y al menos un . después.
8. Encontrar el primer carácter no repetido
Crea una función que reciba una cadena y devuelva el primer carácter que no se repite.

## Sesión 3: Estructuras de Datos y Truthy/Falsy (Dificultad media)

1. Frecuencia de caracteres
Crea una función que reciba una cadena y devuelva un objeto con la frecuencia de cada
letra.
2. Filtrar edades válidas
Dado un arreglo de edades (puede incluir null, NaN, undefined, "", etc.), devuelve un
nuevo arreglo con solo las edades numéricas mayores o iguales a 18.
3. Promedio de calificaciones
Dado un arreglo de objetos {nombre, nota}, crea una función que devuelva el promedio
general.
4. Transformar array de objetos a diccionario
Convierte un array de objetos con id y valor en un objeto tipo diccionario { id1: valor1, id2:
valor2, ... }.
5. Buscar producto en inventario
Crea una función que reciba un arreglo de productos {codigo, nombre, precio} y un código
a buscar, devolviendo el producto correspondiente o null.
6. Eliminar duplicados de un arreglo
Dado un arreglo de números, retorna uno nuevo sin duplicados. (Pista: usa Set o un bucle
con condición).
7. Reemplazar valores falsy
Dado un arreglo con valores variados (undefined, 0, false, "texto", etc.), reemplaza los
falsy por "N/A" y devuelve el nuevo arreglo.
