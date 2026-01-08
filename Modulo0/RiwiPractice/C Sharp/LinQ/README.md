# LINQ en CSharp - Guía rápida

LINQ (Language Integrated Query) es un conjunto de **operadores y métodos** que permiten consultar, filtrar, transformar y agrupar datos de manera declarativa en C#.  
Funciona sobre colecciones (`List<T>`, arrays, `IEnumerable<T>`, etc.) y sobre fuentes de datos más complejas (BD, XML, etc.).

---

## 🚀 Sintaxis básica

### 1. Query Syntax (parecida a SQL)

```csharp
var resultado = from n in numeros
                where n > 5
                orderby n
                select n;
```

### 2. Method Syntax (más usada)

```csharp
var resultado = numeros.Where(n => n > 5)
                       .OrderBy(n => n)
                       .ToList();
```

---

## 🔑 Métodos más usados

- **Where** → Filtra elementos.  
- **Select** → Proyecta (transforma) elementos.  
- **OrderBy / OrderByDescending** → Ordena.  
- **ThenBy / ThenByDescending** → Ordena adicionalmente.  
- **GroupBy** → Agrupa elementos.  
- **Join** → Une colecciones.  
- **Distinct** → Elimina duplicados.  
- **Any / All** → Verifica condiciones.  
- **First / FirstOrDefault** → Obtiene el primer elemento.  
- **Single / SingleOrDefault** → Obtiene un único elemento.  
- **Count / Sum / Min / Max / Average** → Operaciones agregadas.  
- **Take / Skip** → Paginación (ej. tomar los primeros X elementos).  
- **Contains** → Verifica si un elemento existe.  

---

## 📝 Ejemplos rápidos

### Filtrar

```csharp
var mayoresDe18 = personas.Where(p => p.Edad >= 18);
```

### Seleccionar campos específicos

```csharp
var nombres = personas.Select(p => p.Nombre);
```

### Ordenar

```csharp
var ordenados = personas.OrderBy(p => p.Nombre);
```

### Agrupar

```csharp
var agrupados = personas.GroupBy(p => p.Ciudad);
```

### Unir colecciones

```csharp
var query = from c in clientes
            join o in ordenes on c.Id equals o.ClienteId
            select new { c.Nombre, o.Fecha };
```

### Comprobar condiciones

```csharp
bool hayMayores = personas.Any(p => p.Edad > 30);
bool todosMayores = personas.All(p => p.Edad > 18);
```

### Agregaciones

```csharp
int total = numeros.Count();
double promedio = numeros.Average();
int suma = numeros.Sum();
```

---

## 📌 Tips importantes

- LINQ trabaja sobre **`IEnumerable<T>`** → ejecución diferida hasta que se materializa (ej: `ToList()`, `ToArray()`).  
- Usa `FirstOrDefault()` en vez de `First()` para evitar excepciones si no hay elementos.  
- `Select` puede proyectar a un **tipo anónimo**:  

  ```csharp
  var resultado = personas.Select(p => new { p.Nombre, p.Edad });
  ```

- Combina filtros con **operadores encadenados**:
  
  ```csharp
  var query = personas.Where(p => p.Edad > 18)
                      .OrderBy(p => p.Nombre)
                      .Select(p => p.Nombre);
  ```

---

## 🎯 Cuándo usar LINQ

- Para evitar bucles `for`/`foreach` innecesarios.  
- Cuando necesitas consultas claras y declarativas sobre colecciones.  
- Al trabajar con **colecciones grandes**, LINQ hace el código más **legible y mantenible**.  

---

## 🔗 Recursos recomendados

- [Docs oficiales de LINQ - Microsoft](https://learn.microsoft.com/dotnet/csharp/linq)  
- [101 ejemplos LINQ](https://learn.microsoft.com/dotnet/csharp/linq/linq-samples)
