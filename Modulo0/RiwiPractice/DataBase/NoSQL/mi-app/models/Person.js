const mongoose = require('mongoose'); //Importa la librería mongoose
const Schema = mongoose.Schema; //En lugar de repetir mongoose.Schema varias veces, usas solo Schema

//Está creando un esquema (schema) para los documentos de tipo "persona".
const personSchema = new Schema({
    name:String,
    lastname:String,
    lastname2:String,
    age:Number,
    id:String,
    email:String,
    country:String
});

//Exportamos un modelo que se puede usar en otros archivos. Este modelo se llama Person.
module.exports = mongoose.model('Person', personSchema);