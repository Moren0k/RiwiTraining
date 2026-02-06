# Taller de LINQ en C Sharp

## Contexto del taller

Una universidad necesita gestionar información sobre sus **estudiantes**, **cursos** y **matrículas**.  
Tu tarea es crear modelos en C#, inicializar colecciones con datos de ejemplo y resolver los ejercicios usando **LINQ**.

---

## Crear los modelos

Crea las siguientes clases en C#:

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}

public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public double Grade { get; set; }
}
```

---

## Crear colecciones con objetos

En el método `Main`, inicializa listas con datos de ejemplo.  
**Debe haber al menos 5 objetos por lista** (`students`, `courses`, `enrollments`).

Ejemplo:

```csharp
var students = new List<Student> { ... };
var courses = new List<Course> { ... };
var enrollments = new List<Enrollment> { ... };
```

---

## Ejercicios con LINQ

1. **Filtrar estudiantes mayores de 20 años**  
2. **Ordenar cursos por créditos**  
3. **Buscar un curso específico**  
4. **Contar matrículas**  
5. **Join entre matrículas y estudiantes**  
6. **Join triple (estudiante + curso + matrícula)**  
7. **Validaciones con LINQ (`All`, `Any`, `Contains`)**  

---
