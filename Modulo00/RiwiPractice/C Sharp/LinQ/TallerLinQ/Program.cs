using TalleLINQ.Models;
// Student: StudentId Name Age
// Course: CourseId Title Credits
// Enrollment: EnrollmentId StudentId CourseId Grade
namespace TalleLINQ;
public static class Program
{
    static void Main()
    {
        //Create collection for Students
        var students = new List<Student>
        {
            new Student { StudentId = 1, Name = "Kevin", Age = 21 },
            new Student { StudentId = 2, Name = "David", Age = 30 },
            new Student { StudentId = 3, Name = "Andres", Age = 19 },
            new Student { StudentId = 4, Name = "Santiago", Age = 22 },
            new Student { StudentId = 5, Name = "Camilo", Age = 56 }
        };
        //Create collection for Courses
        var courses = new List<Course>
        {
            new Course { CourseId = 1, Title = "C#", Credits = 5 },
            new Course { CourseId = 2, Title = "Java", Credits = 3 },
            new Course { CourseId = 3, Title = "SQL", Credits = 2 },
            new Course { CourseId = 4, Title = "Python", Credits = 10 },
            new Course { CourseId = 5, Title = "HTML", Credits = 6 },
        };
        //Create collection for Enrollments
        var enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentId = 1, StudentIdE = 1, CourseIdE = 1, Grade = 5},
            new Enrollment { EnrollmentId = 2, StudentIdE = 2, CourseIdE = 2, Grade = 4},
            new Enrollment { EnrollmentId = 3, StudentIdE = 5, CourseIdE = 3, Grade = 3},
            new Enrollment { EnrollmentId = 4, StudentIdE = 4, CourseIdE = 5, Grade = 3.5},
            new Enrollment { EnrollmentId = 5, StudentIdE = 3, CourseIdE = 4, Grade = 2},
        };
        /*=============================================LOGICA=============================================*/
        //Filtrar estudiantes mayores de 20 años
        var queryStudents = from s in students where s.Age > 20 select s;
        foreach (var student in queryStudents)
        {
            Console.WriteLine($"[{student.Name}] Tiene mas de 20AÑOS!");
        }
        //Ordenar cursos por creditos
        var queryCredits = courses.OrderByDescending(c => c.Credits);
        foreach (var credit in queryCredits)
        {
            Console.WriteLine($"{credit.Title} Credits: [{credit.Credits}]");
        }
        //Buscar un curso específico
        var searchCourse = "Java";
        var queryCourses = from c in courses where c.Title.Contains(searchCourse) select c;
        foreach (var course in queryCourses)
        {
            Console.WriteLine($"CURSO ENCONTRADO!: {course.Title} Credits: [{course.Credits}]");
        }
        //Contar matrículas
        var queryEnrollment = enrollments.Count;
        Console.WriteLine($"Hay {queryEnrollment} matrículas");
        //Join entre matrículas y estudiantes
        var queryEnSt = from e in enrollments
            join s in students on e.StudentIdE equals s.StudentId
            select new
            {
                e.EnrollmentId,
                s.Name,
                e.Grade,
            };
        foreach (var enrollment in queryEnSt)
        {
            Console.WriteLine($"Estudiante [{enrollment.Name}]: Calificación: [{enrollment.Grade}]");
        }
        //Join triple (estudiante + curso + matrícula)
        var queryEnStCo = from e in enrollments
            join s in students on e.StudentIdE equals s.StudentId
            join c in courses on e.CourseIdE equals c.CourseId
            select new
            {
                e.EnrollmentId,
                s.Name,
                e.Grade,
                c.Title
            };
        foreach (var enrollment in queryEnStCo)
        {
            Console.WriteLine($"Hola soy {enrollment.Name} Estoy en el curso: {enrollment.Title} con calificación: [{enrollment.Grade}]");
        }
        //Validaciones con LINQ (All, Any, Contains)
        bool queryGrade = enrollments.All(g => g.Grade != 0);
        Console.WriteLine($"Todos los estudiantes ya estan calificados?: [{queryGrade}]");
    }
}
