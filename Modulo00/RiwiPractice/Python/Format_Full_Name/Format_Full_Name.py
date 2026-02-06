def format_full_name (nombre,segundo_nombre, apellido1, apellido2):
    nombre = nombre.capitalize()
    segundo_nombre = segundo_nombre.capitalize()
    apellido1 = apellido1.capitalize()
    apellido2 = apellido2.capitalize()
    nombre_completo = nombre + " " + segundo_nombre + " " + apellido1 + " " + apellido2
    return nombre_completo

nombre = input("Ingrese su nombre: ")
segundo_nombre = input("Ingrese su segundo nombre: ")
apellido1 = input("Ingrese su apellido: ")
apellido2 = input("Ingrese su segundo apellido: ")

nombre_completo = format_full_name(nombre, segundo_nombre, apellido1, apellido2)
print("El nombre completo es: " + nombre_completo)