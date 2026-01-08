def max_longitud (texto, maxlong):
    longitud = len(texto) 

    if longitud >= maxlong: 
        print("\n--- - ---")
        print(texto[:maxlong]+"...")
        print("El Texto Original es: ",texto)
    else:
        print(texto)

texto = input("Ingresa el texto: ")
maxlong = int(input("Ingresa la longitud máxima deseada: "))
max_longitud(texto, maxlong)