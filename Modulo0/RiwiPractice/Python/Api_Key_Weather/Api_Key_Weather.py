import urllib.request
import json
api_key = "3485c946eeb4bd9c8b39ec770bede709"

def get_climate():
    api_key = "3485c946eeb4bd9c8b39ec770bede709"
    city = str(input("Ingresa el nombre de la ciudad que deseas consultar: "))
    url = f"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}&units=metric&lang=es"

    with urllib.request.urlopen(url) as response:
        data= response.read()
        print(data)
        jsonData = json.loads(data)
        print(jsonData)

get_climate()
"""
¡Pediente de poder consumir la DATA entregada por la API!
1. Que el usuario peuda ingresar la cuidad que desea consultar el clima y este muestre una descripcion con emojis
si esta lluvioso, la temperatura min y max.
Mostrar o convertir/formatear la hora de cuando amanece(sunrise) y cuando atardece(sunset).
"""