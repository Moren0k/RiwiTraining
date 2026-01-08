const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); 
const app = express();

const connection = require('./db.js'); // connection is the conection to data base
const {uploadCsvEmployees} = require('./helpers.js'); // import the funciton to upload employees in the Csv
const {uploadCsvProjects} = require('./helpers.js'); // Import the function to upload projects in the Csv

app.use(cors());
app.use(bodyParser.json());

// Endpoint para insertar un nuevo empleado desde ¡postman!
app.post('/uploadEmploye', (req, res) =>{
    const { name, lastname, second_lastname, email, charge, city, salary, age } = req.body;

    const query = `INSERT INTO employees (name, lastname, second_lastname, email, charge, city, salary, age)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)`;

    connection.query(query, [name, lastname, second_lastname, email, charge, city, salary, age], (err, result) =>{
        if (err){
            console.error("Error al insertar empleado:", err);
            return;
        }
        res.status(201).json({ message: "Empleado insertado correctamente.", id: result.insertId });
    });
});

/* POST */
// Endpoint para subir CSV employees
app.post('/uploadCsvEmployees', (req,res) =>{
    uploadCsvEmployees();
    res.json("Achivo CSV subido correctamente con los Empleados.");
});
// Endpoint para subir CSV projects
app.post('/uploadCsvProjects', (req, res) =>{
    uploadCsvProjects();
    res.json("Archivo CSV subido correctamente con los Proyectos.");
})

/* GET */
// Endpoint para mostrar tabla employees
app.get('/getEmployees', (req, res) =>{
    const query = 'SELECT * FROM employees';

    connection.query(query, (err, results) =>{
        if (err){
            console.error("Error al obtener la tabla empleados.", err);
            return;
        }
        res.json(results);
    });
});
// Endpoint para mostrar tabla projects
app.get('/getProjects', (req, res) =>{
    const query = 'SELECT * FROM projects';

    connection.query(query, (err, results) =>{
        if (err){
            console.error("Error al obtener la tabla proyectos.", err);
            return;
        }
        res.json(results);
    });
});

/* DELETE */
app.delete('/delEmployees', (req, res) =>{
    const query = 'TRUNCATE TABLE employees'; //Employees / Empleados

    connection.query(query, (err, results) =>{
        if (err){
            console.error("Erro al eliminar los datos de la tabla empleados.", err);
            return;
        }
        res.status(200).json({ message: 'Todos los empleados han sido eliminados correctamente.' });
    });
});

app.delete('/delProjects', (req, res) => {
    const query = 'TRUNCATE TABLE projects'; //Projects / Proyectos

    connection.query(query, (err, results) => {
        if (err) {
            console.error("Error al eliminar los datos de la tabla projects.", err);
            return;
        }
        res.status(200).json({ message: 'Todos los proyectos han sido eliminados correctamente.' });
    });
});


/* CONNECT */
app.listen(3000, () =>{
    console.log("Servidor corriendo en http://localhost:3000");
});