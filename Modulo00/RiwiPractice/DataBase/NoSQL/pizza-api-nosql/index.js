const express = require('express');
const mongoose = require('mongoose');
const clientes = require('./models/cliente')
require('dotenv').config();

const app = express();
app.use(express.json());

//Conexón
mongoose.connect(process.env.MONGO_URL)
.then(() => console.log('Conectado a mongo'))
.catch(err => console.error('Error en la conexion', err));

//Endpoint encargado de insertar un nuevo cliente
app.post('/cliente', async(req,res)=>{
    try {
        const nuevoCliente = new clientes(req.body);
        const clienteGuardado = await nuevoCliente.save();
        res.status(201).json(clienteGuardado);
    } catch (error){
        console.error('Error al guardar el cliente', error)
        res.status(400).json({ error: "Error al guardar el cliente" });
    }
});

//Mostrar todos los datos
app.get('/cliente', async (req, res) =>{
    try {
        const obtenerClientes = await clientes.find();
        res.json(obtenerClientes);
    } catch (error) {
        console.error('Error al obtener el cliente', error)
        res.status(500).json({error: 'Error al obtener los clientes'})
    }
});

//Actualizar por el ID
app.put('/cliente/:id', async(req, res) =>{
    try {
        const clienteActualizado = await clientes.findByIdAndUpdate(
            req.params.id,{
                nombre: req.body.nombre,
                edad: req.body.edad,
                direccion: req.body.direccion
            },
            {new : true}
        );
        if (!clienteActualizado) {
            return res.status(404).json({error: 'Cliente no encontrado'});
        }
        res.json(clienteActualizado);
    } catch (err){
        res.status(400).json({error: 'Error al actualizar el cliente'})};
});

//Port
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log('Servidor esta corriendo en el puerto: 3000', PORT);
});
