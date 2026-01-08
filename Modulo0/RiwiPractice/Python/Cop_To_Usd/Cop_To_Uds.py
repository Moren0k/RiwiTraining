def cop_a_usd(cop,usd):
    copusd = (cop/usd)
    print("\n--- - ---")
    print("Equivalente en USD: ",copusd)

cop = float(input("Ingresa tu salario en COP: "))  # Pregunta cuántos pesos colombianos
usd = float(input("Tasa USD: "))  # Pregunta la tasa de cambio actual
cop_a_usd(cop,usd)