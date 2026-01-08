import express from 'express';
import { cargarCSV } from './employeeService.js';
import db from './db.js';

const app = express();
app.use(express.json());

// Cargar CSV al iniciar
const archivo = 'empleados.csv';
cargarCSV(archivo);

// Endpoint para insertar empleado
app.post('/employee', async (req, res) => {
    try {
        const {
            name,
            lastname,
            lastname2,
            email,
            charge,
            city,
            salary,
            age
        } = req.body;

        const query = `
            INSERT INTO employees(name, lastname, lastname2, email, charge, city, salary, age)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)
        `;

        const values = [name, lastname, lastname2, email, charge, city, salary, age];

        db.query(query, values, (err, result) => {
            if (err) {
                console.error('Error al insertar:', err.message);
                return res.status(500).json({ error: 'Error al insertar en la base de datos.' });
            }

            res.status(201).json({
                message: 'Empleado registrado exitosamente.',
                insertedId: result.insertId
            });
        });
    } catch (error) {
        console.error('Error en el servidor:', error.message);
        res.status(500).json({ error: 'Error interno del servidor.' });
    }
});

// Inicialización del servidor en puerto 3000
app.listen(3000, () => {
    console.log('Servidor corriendo en el puerto 3000');
});
