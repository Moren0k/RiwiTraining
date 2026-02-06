print("\n---Bienvenido---")
num_students = int(input("Ingresa la cantidad de estudiantes: "))
students = []

def add_student(num_students):
    for i in range(num_students):
        name = input("Ingresa el nombre del estudiante: ")
        grades = []
        for j in range(3):
            while True:
                grade = float(input(f"Ingresa la calificación {j+1} del estudiante {name}: "))
                if 0 <= grade <= 5:
                    break
                else:
                    print("Calificación inválida. Debe estar entre 0 y 5")
            grades.append(grade)
        students.append({"name": name, "grades": grades})
    print("\nEstudiantes agregados con éxito.")
    return grades

def calculate_average(grades):
    average = sum(grades) / len(grades)
    return average

def check_pass_status(average):
    if average >= 3.0:
        return "Aprobado"
    else:
        return "Reprobado"

def main():
    add_student(num_students)
    for student in students:
        name = student["name"]
        grades = student["grades"]
        average = calculate_average(grades)
        status = check_pass_status(average)
        print(f"\n{name} tiene un promedio de {average:.2f} - {status}")

main()