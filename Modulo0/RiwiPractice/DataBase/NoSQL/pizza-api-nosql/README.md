# 🍕 Pizza API NoSQL - Gestión de Clientes con MongoDB y Node.js

Este proyecto es una API RESTful creada con **Node.js**, **Express** y **MongoDB** (a través de Mongoose) que permite **gestionar clientes** en una base de datos NoSQL. Está orientado al aprendizaje y buenas prácticas para el manejo de bases de datos documentales usando MongoDB Atlas.

---

## 🧠 ¿Qué hace este proyecto?

- Se conecta a la base de datos `tienda` alojada en MongoDB Atlas.
- Trabaja sobre la colección **`clientes`**.
- Permite **crear**, **leer** y **actualizar** clientes mediante endpoints HTTP.
- Utiliza **dotenv** para proteger credenciales sensibles como la URL de conexión.

---

## 📁 Estructura del proyecto

    pizza-api-nosql/
    │
    ├── models/
    │ └── cliente.js # Esquema Mongoose del cliente
    │
    ├── node_modules/ # Dependencias del proyecto
    ├── .env # Variables de entorno (incluye la conexión a MongoDB)
    ├── index.js # Archivo principal donde se configuran los endpoints
    ├── package.json # Metadatos del proyecto y scripts de npm
    ├── README.md # Documentación del proyecto (este archivo)

---

## 🔗 Conexión a la base de datos

Este proyecto se conecta a una instancia de MongoDB Atlas a través de la URL definida en `.env`:

```js
MONGO_URL=mongodb+srv://<usuario>:<password>@<cluster>.mongodb.net/tienda
```

---

## Modelo de Cliente (models/cliente.js)

La estructura del documento en la colección clientes es la siguiente:

const cliente = new mongoose.Schema({
    nombre: String,
    edad: Number,
    direccion: String
});

    Este modelo representa a cada cliente como un documento con 3 campos: nombre, edad y dirección.

