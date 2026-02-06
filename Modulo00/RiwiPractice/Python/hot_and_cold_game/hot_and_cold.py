#Importamos la libreria random
import random

def game():
    num_random = random.randint(0,100) #Definimos una variable para guardar el numero aleatorio como un entero de 0 a 100
    attempts = 0 #Definimos una variable para contar el numero de intentos que incia en 0
    print("¡Bienvenido al juego de frío o caliente!")
    print("Tengo un número secreto entre 1 y 100.")
    
    while True: #Se crea un bucle verdadero con while que:
        tried = int(input("¿Cuál es tu intento? "))#Muestra el mensaje para que el usuario ingrese el numero de el intento
        attempts += 1
        
        if tried < num_random:
            print("Frio")
            
        elif tried > num_random:
            print("caliente")
        else:
            print(f"¡Correcto! ¡Has acertado el número en {attempts} intentos!")
            break
game()