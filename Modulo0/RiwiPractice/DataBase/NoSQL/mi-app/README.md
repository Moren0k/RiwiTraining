# mi-app

---

**Estructura básica.**

    /mi-app
    │
    ├── index.html         ← Tu vista con tabla y modal
    ├── app.js             ← JS para manejar el frontend
    ├── server.js          ← Tu servidor con Express
    ├── models/
    │   └── empleado.js    ← Modelo de empleado (si usas MongoDB)
    ├── .env               ← Variables de entorno
    └── empleados.json     ← O podrías usar MongoDB o MySQL

---

Se inicio en MongoDB Compass con la Password:
"mongodb+srv://jhoskevinagudelomoreno:ek1rAyfUrK6FJIeN@cluster.1d0s8ae.mongodb.net/".

Creamos una base de datos llamada: `database`

Creamos una coleccion para almacenar los datos de las personas como `people` con esta estructura:

*Ejemplo como dato inicial.*

    {
    _id: ObjectId('68950ed190bb8c987f08cbe7'),
    name: 'Kevin',
    lastname: 'Agudelo',
    lastname2: 'Moreno',
    age: 20,
    email: 'Kevin.Moreno@gmail.com',
    country: 'Colombia'
    }

---

**Iniciamos NPM desde la teminal:**

    npm init -y

**Esto crea tu app y le instala:**

    npm install express mongoose dotenv cors

**express**: para manejar el servidor

**mongoose**: para conectar con MongoDB

**dotenv**: para guardar la conexión en .env

**cors**: para permitir peticiones desde tu HTML
npm install express mongoose dotenv cors

---

Creamos el archivo `.env` que contiene la URL de la conexcion de MongoDB Atlas y el PORT

    MONGO_URL=mongodb+srv://jhoskevinagudelomoreno:ek1rAyfUrK6FJIeN@cluster.1d0s8ae.mongodb.net/
    PORT=3000

---

En la carpeta models dentro de `Person.js` vamos a crear un modelo que se usa para interactuar con la base de datos.

En el archivo `server.js` creamos el backend completo de una API REST usando Express + Mongoose + MongoDB

    Este servidor:

    Se conecta a MongoDB

    Expone dos endpoints REST:

        GET /people → Lista todas las personas

        POST /people → Crea una nueva persona

    Usa middlewares para CORS y JSON

    Todo configurado con variables de entorno desde .env
