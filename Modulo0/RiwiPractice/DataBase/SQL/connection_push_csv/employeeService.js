import fs from 'fs';
import csv from 'csv-parser';
import db from './db.js';

export const cargarCSV = (rutaCSV) =>{
    fs.createReadStream(rutaCSV)
    .pipe(csv())
    .on('data', (row) =>{
        const {name, lastname, lastname2, email, charge, city, salary, age} = row;

        const insertQuery = `
            INSERT INTO employees(name, lastname, lastname2, email, charge, city, salary, age)
            VALUES(?,?,?,?,?,?,?,?)
        `;

        db.query(
            insertQuery,
            [name, lastname, lastname2, email, charge, city, salary, age],
            (err, result) =>{
                if (err) {
                    console.error("Error al insertar fila",err.message)
                    return
                } else {
                    console.log("Se logro insertar")
                    return
                }
            }
        )
    })
}