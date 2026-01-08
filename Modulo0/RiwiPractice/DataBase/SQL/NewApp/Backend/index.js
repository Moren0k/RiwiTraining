const express = require('express');
const bodyParser = require('body-parser');
const db = require('./db');
const { uploadCSVBack } = require('./helpers');
const cors = require('cors'); 
const app = express();

app.use(cors()); 
app.use(bodyParser.json());

// Endpoint para insertar un nuevo empleado
app.post('/empleados', (req, res) => {
    const { name, lastname, second_lastname, email, charge, city, salary, age } = req.body;

    const sql = `
        INSERT INTO people (name, lastname, second_lastname, email, charge, city, salary, age)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
    `;

    db.query(sql, [name, lastname, second_lastname, email, charge, city, salary, age], (err, result) => {
        if (err) {
            console.error('Error al insertar empleado:', err);
            return res.status(500).json({ error: 'Error al insertar empleado' });
        }
        res.status(201).json({ message: 'Empleado insertado correctamente', id: result.insertId });
    });
});

//endponit uploadData
app.post('/uploadCSV', (req,res) =>{
    uploadCSVBack();
    res.json({result:"bd actualizada"});
});

// Obtener todos los clientes
app.get('/getEmpleados', (req, res) => {
    const sql = 'SELECT * FROM people';

    db.query(sql, (err, results) => {
        if (err) {
            console.error('Error al obtener los empleados:', err);
            return res.status(500).json({ error: 'Error al obtener los empleados' });
        }
        res.json(results);
    });
});


app.listen(3000, () => {
    console.log('Servidor corriendo en http://localhost:3000');
});
