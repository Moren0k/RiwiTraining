def letras_a_numeros(texto):
    unidades = {
        "uno": 1, "una": 1, "dos": 2, "tres": 3, "cuatro": 4, "cinco": 5,
        "seis": 6, "siete": 7, "ocho": 8, "nueve": 9
    }
    especiales = {
        "diez": 10, "once": 11, "doce": 12, "trece": 13, "catorce": 14,
        "quince": 15, "dieciséis": 16, "diecisiete": 17, "dieciocho": 18, "diecinueve": 19,
        "veinte": 20, "veintiuno": 21, "veintidós": 22, "veintitrés": 23, "veinticuatro": 24,
        "veinticinco": 25, "veintiséis": 26, "veintisiete": 27, "veintiocho": 28, "veintinueve": 29
    }
    decenas = {
        "treinta": 30, "cuarenta": 40, "cincuenta": 50, "sesenta": 60,
        "setenta": 70, "ochenta": 80, "noventa": 90
    }
    centenas = {
        "cien": 100, "ciento": 100, "doscientos": 200, "trescientos": 300,
        "cuatrocientos": 400, "quinientos": 500, "seiscientos": 600,
        "setecientos": 700, "ochocientos": 800, "novecientos": 900
    }

    texto = texto.lower().replace(" y ", " ")
    palabras = texto.split()
    total = 0
    parcial = 0

    for palabra in palabras:
        if palabra in especiales:
            parcial += especiales[palabra]
        elif palabra in unidades:
            parcial += unidades[palabra]
        elif palabra in decenas:
            parcial += decenas[palabra]
        elif palabra in centenas:
            parcial += centenas[palabra]
        elif palabra == "mil":
            if parcial == 0:
                parcial = 1
            total += parcial * 1000
            parcial = 0
        elif palabra in ["millón", "millones"]:
            if parcial == 0:
                parcial = 1
            total += parcial * 1000000
            parcial = 0
        # Puedes agregar más magnitudes como "billón", etc.

    total += parcial
    return total

# Ejemplo de uso
entrada = input("Ingrese un número en letras: ")
resultado = letras_a_numeros(entrada)

print(f"El número en letras '{entrada}' es: {resultado}")