def verify_secure_password():
    segura = False

    while not segura:
        passw = input("Ingresa una contraseña Segura: ")
        longitud = len(passw)

        longitudmin = 8 #Longitud minima de caracteres
        tiene_mayus = any(letra.isupper() for letra in passw)
        tiene_num = any(letra.isdigit() for letra in passw)

        if longitud <= longitudmin:
            print("La contraseña debe tener más de 8 caracteres")
        elif not tiene_mayus:
            print("Debe tener almenos una letra mayúscula")
        elif not tiene_num:
            print("Debe tener almenos un número")
        else:
            print("¡Contraseña Segura!")
            segura = True
verify_secure_password()