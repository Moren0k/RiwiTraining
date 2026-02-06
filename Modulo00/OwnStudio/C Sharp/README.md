# C# - C Sharp

---

## Tipos de datos

### Numeros Enteros

```c#
    byte numeroCorto = 127;                // Valor máximo para byte (rango: -128 a 127)
    short numeroPequeno = 32_767;          // Valor máximo para short (rango: -32,768 a 32,767)
    int numero = 1_000_000_000;            // Dentro del rango de int (-2,147,483,648 a 2,147,483,647)
    long numeroGrande = 1_000_000_000_000_000_000L; // Se añade 'L' para indicar literal long
```

### Numeros Decimales

```c#
    float numeroGrande2 = 1e20f;           // Notación científica (más legible, dentro del rango de float)
    double numeroGigante = 1e100;          // Uso de double para valores mucho más grandes
```

### Booleanos

```c#
    bool verdadero = true;                  // Valores booleanos (true o false)
    bool falso = false;

    Guid idUnico = Guid.NewGuid();          // Genera un identificador único (UUID)
```

### Variables

```c#
    string nombre = "JhosKevinAgudeloMoreno"; // Declaración de una variable string
    char unCaracter = 'A';               // Declaración de una variable char (un solo carácter)
    var numeroVariable = 42;              // Uso de 'var' para inferencia de tipo (tipo int en este caso)
```

## Concatenación de Strings

```c#
    string nombre = "JhosKevin";
    string apellido = "AgudeloMoreno";

    // Concatenación usando el operador +
    string nombreCompleto = nombre + " " + apellido;

    // Interpolación de cadenas (similar a f-strings en Python)
    string nombreCompletoInterpolado = $"{nombre} {apellido}";

    Console.WriteLine(nombreCompleto);
    Console.WriteLine(nombreCompletoInterpolado);
```

---

## Listas

### List

```c#
    // Crear una lista de enteros
    List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

    // Agregar un elemento a la lista
    numeros.Add(6);

    // Acceder a elementos por índice
    int primerNumero = numeros[0]; // 1

    // Recorrer la lista con un bucle foreach
    foreach (int numero in numeros)
    {
        Console.WriteLine(numero);
    }
```

### Array

```c#
    // Crear un array de enteros
    int[] numerosArray = new int[] { 1, 2, 3, 4, 5 };

    // Acceder a elementos por índice
    int primerNumeroArray = numerosArray[0]; // 1

    // Recorrer el array con un bucle foreach
    foreach (int numero in numerosArray)
    {
        Console.WriteLine(numero);
    }
```

### ArrayList

```c#
    // Crear un ArrayList
    ArrayList elementos = new ArrayList { 1, "dos", 3.0, true };

    // Agregar un elemento al ArrayList
    elementos.Add("nuevo elemento");

    // Acceder a elementos por índice
    var primerElemento = elementos[0]; // 1

    // Recorrer el ArrayList con un bucle foreach
    foreach (var elemento in elementos)
    {
        Console.WriteLine(elemento);
    }
```

### Diccionarios

```c#
    // Crear un diccionario con claves de tipo string y valores de tipo int
    Dictionary<string, int> edades = new Dictionary<string, int>
    {
        { "Alice", 30 },
        { "Bob", 25 },
        { "Charlie", 35 }
    };

    // Agregar un nuevo par clave-valor
    edades["Diana"] = 28;

    // Acceder a un valor por su clave
    int edadDeBob = edades["Bob"]; // 25

    // Recorrer el diccionario con un bucle foreach
    foreach (var kvp in edades)
    {
        Console.WriteLine($"{kvp.Key} tiene {kvp.Value} años.");
    }
```

### Tuplas

```c#
    // Crear una tupla con dos elementos
    var persona = (Nombre: "Alice", Edad: 30);

    // Acceder a los elementos de la tupla
    string nombre = persona.Nombre; // "Alice"
    int edad = persona.Edad;        // 30

    // Imprimir los valores de la tupla
    Console.WriteLine($"Nombre: {nombre}, Edad: {edad}");
```

---

## Recorrido de Listas y Arrays

### Bucle For

```c#
    int[] numeros = { 1, 2, 3, 4, 5 };

    for (int i = 0; i < numeros.Length; i++)
    {
        Console.WriteLine(numeros[i]);
    }
```

### Bucle Foreach

```c#
    int[] numeros = { 1, 2, 3, 4, 5 };

    foreach (int numero in numeros)
    {
        Console.WriteLine(numero);
    }
```

### Bucle While

```c#
    int[] numeros = { 1, 2, 3, 4, 5 };
    int i = 0;

    while (i < numeros.Length)
    {
        Console.WriteLine(numeros[i]);
        i++;
    }
```

### Bucle Do-While

```c#
    int[] numeros = { 1, 2, 3, 4, 5 };
    int i = 0;

    do
    {
        Console.WriteLine(numeros[i]);
        i++;
    } while (i < numeros.Length);
```

---