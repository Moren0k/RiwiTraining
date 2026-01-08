age = int(input("Enter your age: ")) ##Ingresa la edad

if age <= 12: # edad es menor o igual a 12
    print("Your are a child")
elif age >= 13 and age <= 17: # edad es mayor o igual a 13 y edad es menor o igual a 17
    print("Your are a teenager")
elif age >= 18 and age <= 59: # edad es mayor o igual a 18 y edad es menor o igual a 59
    print("Your are an adult")
elif age >= 60: # edad es mayor o igual a 60
    print("Your are an older adult")