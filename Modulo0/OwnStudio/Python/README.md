# Fundamentos de Python

---

## Variables y Tipos de Datos

**Declaración de variables básicas**  
Diferentes tipos de datos en Python.

```python
str = "Texto"
int = 10
float = 9.5
bool = True, False
```

**Asignación de variables**  
Usamos `=` para asignar un valor.

```python
nombre_variable = "Dato para almacenar"
```

**Convenciones para nombres de variables.**

```python
# camelCase (menos usado en Python)
NombreCompleto = "JhosKevinAgudeloMoreno"

# snake_case (RECOMENDADO)
nombre_completo = "jhos_kevin_agudelo_moreno"
```

---

## Operadores Aritméticos

**Operaciones básicas.**

```python
a = 2
b = 3

suma = a + b
resta = a - b
multiplicacion = a * b
division = a / b
modulo = a % b
exponente = a ** b
division_baja = a // b

print(suma, resta, multiplicacion, division, modulo, exponente, division_baja)
```

---

## Strings

**Concatenación y f-strings.**

```python
bienvenida = "Hola " + nombre_completo + " ¿Como estas?"
bienvenida = f"Hola {nombre_completo} ¿Como estas?"
print(bienvenida)
```

**Operadores de pertenencia.**

```python
print("Kevin" in bienvenida)
print("Kevin" not in bienvenida)
```

**Métodos útiles para cadenas.**

```python
chain = "jhos Kevin agudelo Moreno   "

mayus = chain.upper()
minus = chain.lower()
first_mayus = chain.capitalize()
search_find = chain.find("K")
# search_index = chain.index("X") # Devuelve ERROR si no encuentra
numeric = chain.isnumeric()
alphanumeric = chain.isalpha()
count_coincidences = chain.count("a")
count_characters = len(chain)
starts_with = chain.startswith("jhos")
end_with = chain.endswith(" ")
replace = chain.replace("jhos", "Hola")
separate = chain.split(",")
```

---

## Operadores Lógicos

```python
# AND
True and True     # True
False and True    # False

# OR
True or False     # True

# NOT
not True          # False
```

---

## Estructuras de Control

**Condicionales if, elif, else.**

```python
age = 9
if age <= 18:
    print("Eres menor")
else:
    print("Eres mayor")
```

**Condicional anidado.**

```python
income = 200
bills = 200
if income >= 10000:
    print("Ganas muy bien 10k")
elif income >= 5000:
    print("Ganas bien 5k")
elif income >= 200:
    print("Ganas mal 200")
    if income - bills >= 0:
        print("Ganas poco y gastas mucho")
else:
    print("Ganas mal -5k")
```

---

## Listas

```python
lista = ["Jhos Kevin", "Agudelo Moreno", True, 20, 1.60]
print(lista[1])  # Acceso por índice
lista[2] = False  # Modificar
print(lista[2])

list = list(["Element0", "Element1", "Element2"])
count_list = len(list)
list.append("NewElement3")
list.insert(2, "NewElementIn2Position")
list.extend(["NewElement4", "NewElement5"])
```

---

## Tuplas

```python
tupla = ("Jhos Kevin", "Agudelo Moreno", True, 20, 1.60)
print(tupla)
# tupla[2] = False  # ERROR: no se pueden modificar
```

---

## Conjuntos

```python
conjunto = {"Jhos Kevin", "Agudelo Moreno", True, 20, 1.60}
# No índices, no duplicados
```

---

## Diccionarios

```python
diccionario = {
    "nombre": "Jhos Kevin",
    "Apellido": "Agudelo Moreno",
    "fov": True,
    "edad": "20",
    "estatura": "1.60"
}
print(diccionario["nombre"])
```
