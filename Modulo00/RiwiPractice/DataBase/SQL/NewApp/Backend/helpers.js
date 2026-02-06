const fs = require('fs');
const path = require('path');
const csv = require('csv-parser');
const connection = require('./db');

const uploadCSVBack = () => { // Función encargada de subir el archivo CSV

    const result=[];
    const filePath = path.join(__dirname, 'people.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) =>{
        result.push(row);
    });

    result.forEach((empleado) =>{
        const query = `INSERT INTO people(name, lastname, second_lastname, email, charge, city, salary, age)
        VALUES(?,?,?,?,?,?,?,?)`;

        const values = [
            empleado.name,
            empleado.lastname,
            empleado.second_lastname,
            empleado.email,
            empleado.charge,
            empleado.city,
            empleado.salary,
            empleado.age
        ];

    connection.query(query, values, (err, result)=>{
            if(err){
                console.error("Error al insertar");
            } else {
                console.log(`"Empleado insertado" ${result.insertId}`);
            }
        });
    });
};

module.exports = { uploadCSVBack };
