const express = require('express'); //Importa Express (Permite crear rutas y manejar peticiones)
const mongoose = require('mongoose'); //Importa Mongoose (Para conectar y trabajar con MongoDB)
const dotenv = require('dotenv'); //Importa Dotenv (Carga variables del archivo .env)
const cors = require('cors'); //Importa Cors (Permite que el frontend pueda hacer peticiones a este backend)
const {uploadCSVBack} = require('./helpers.js'); //Importa la logica de la const de helpers.js

//Importa el modelo Person
const Person = require('./models/Person');

dotenv.config(); //Carga las varibles de .env

//Crea una instancia de Express. app es el servidor que va a ecuchar peticiones
const app = express();
//Permite peticiones CORS desde cualquier origen
app.use(cors());
//Transforma los body de las peticiones en JSON
app.use(express.json());


//Conexion a mongo
/*intenta conectarse a tu base de datos MongoDB usando la URL de MONGO_URI desde tu archivo .env.
    .then() se ejecuta si la conexión fue exitosa.
    .catch() se ejecuta si hubo un error.  */
mongoose.connect(process.env.MONGO_URL)
    .then(()=> console.log('Connected to MongoDB'))
    .catch((err)=> console.error('Connection failed to MongoDB', err));


//GET
//endpoint devuelve todas las personas guardadas en la base de datos.
app.get('/people', async (req, res) =>{
    const people = await Person.find();
    res.json(people);
});

//POST
//endpoint guarda una nueva persona que recibe en el body.
app.post('/people', async (req, res) =>{
    const newPerson = new Person(req.body);
    await newPerson.save();
    res.json({ message: 'Person added successfully'});
});

//Endpoint uploadData
app.post('/uploadCSV', (req,res)=>{
    //uploadCSVBack();
    console.log("Funciono");
    res.json({result:"DataBase Actualizada"});
});

//El servidor escucha en el puerto definido en .env, o en el 3000 si no hay ninguno definido.
const PORT = process.env.PORT || 3000;
app.listen(PORT, ()=> console.log(`Server running on port ${PORT}`));