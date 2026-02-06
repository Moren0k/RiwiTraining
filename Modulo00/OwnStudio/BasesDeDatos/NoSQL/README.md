# Bases de datos NoSQL

---

**Limpiar la consola.**
Muestra todas las bases de datos disponibles.

```js
cls
```

## Comandos basicos (Mostrar,Crear,Modificar,Eliminar)

**Consultar las bases de datos.**
Muestra todas las bases de datos disponibles.

```js
show dabases
```

**Crear o usar una base de datos.**
Selecciona o crea una base de datos para trabajar en ella.

```js
use nombreBaseDeDatos
```

**Eliminar una base de datos.**
Elimina la base de datos actualmente seleccionada por completo.

```js
db.dropDatabase()
```

---

## Colecciones

**Consultar las colecciones.**
Muestra toda las colecciones que hay en la base de datos actual.

```js
show collections
```

**Crear una colección explícitamente.**
Crea una colección vacía manualmente antes de agregar documentos.

```js
db.createCollection("nombreCollection")
```

**Eliminar una colección**
Borra completamente una colección y sus documentos.

```js
db.nombreCollection.drop()
```

---

## Documentos

**Consultar todos los documentos.**
Muestra todos los documentos guardados en la colección.

```js
db.nombreCollection.find()
```

**Consultar documentos con filtro.**
Recupera documentos que cumplen con una condición específica.

```js
db.nombreCollection.find({ clave: "valor" })
```

**Insertar un documento en una colección.**
Agrega un solo documento a una colección existente.

```js
db.nombreCollection.insertOne({ clave: "valor" })
```

**Insertar varios documentos.**
Agrega múltiples documentos a una colección en una sola operación.

```js
db.nombreCollection.insertMany([
    { clave1: "valor1" },
    { clave2: "valor2" },
    { clave3: "valor3" }
])
```

**Modificar un documento.**
Actualiza el primer documento que coincida con el filtro dado.

```js
db.nombreCollection.updateOne(
    { clave: "valor" },
    { $set: { claveModificar: "nuevoValor" } }
)
```

**Modificar varios documentos.**
Actualiza todos los documentos que cumplan el filtro especificado.

```js
db.nombreCollection.updateMany(
    { clave: "valor" },
    { $set: { claveModificar: "nuevoValor" } }
)
```

**Eliminar un documento/tabla.**
Elimina el primer documento que coincida con el filtro indicado.

```js
db.nombreCollection.deleteOne({ clave: "valor" })
```

**Eliminar varios documentos.**
Elimina todos los documentos que coincidan con el filtro dado.

```js
db.nombreCollection.deleteMany({ clave1: "valor1" })
```

---

## Operadores de comparacion para filtrar.

```$eq``` (Equal - Es igual)
Encuentra los documentos donde el valor es equivalente al num especificado

```js
{ "clave": { "$eq": num } } // Me va a devolver todos los documentos donde el valor de la clave sea igual a num
```

```$gt``` (Greather Than - Mayor que)
Encuentra los documentos donde el valor es mayor que el num especificado.

```js
{ "clave": { "$gt": num } } // Me va a devolver todos los documentos donde el valor de la clave sea mayor a num
```

```$lt``` (Less Than - Menor que)
Encuentra los documentos donde el valor es menor al num especificado.

```js
{ "clave": { "$lt": num } } // Me va a devolver todos los documentos donde el valor de la clave sea menor a num
```

```$lte``` y ```$gte``` (Less Than or Equal [Menor o igual a] - Greather Than or Equal [Mayor o igual a]
Funcionan exactamente igual que los anteriores sin la "e", solo que se incluye el valor en si mismo.

```js
{ "clave": { "$gte": num } } // Me va a devolver todos los documentos donde el valor de la clave sea mayor o igual a num
{ "clave": { "$lte": num } } // Me va a devolver todos los documentos donde el valor de la clave sea menor o igual a num
```

```$ne``` (Not Equal - No es igual)

```js
{ "valor": { "$ne": num } } // Devuelve todos los documentos en donde el valor de la clave NO sea num
```
