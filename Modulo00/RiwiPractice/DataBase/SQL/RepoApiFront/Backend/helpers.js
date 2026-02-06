const fs = require('fs');
const path = require('path');
const csv = require('csv-parser');

const connection = require('./db'); //Import db for connection from db.js

const uploadCsvEmployees = () =>{
    const result = []; 
    const filePath = path.join(__dirname, './CSVs/employees.csv');

    fs.createReadStream(filePath)
        .pipe(csv())
        .on('data', (row) =>{result.push(row);})
        .on('end', () => {
            result.forEach((employe) => {
                const query = `INSERT INTO employees (name, lastname, second_lastname, email, charge, city, salary, age)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?)`;

                const values = [
                    employe.name,
                    employe.lastname,
                    employe.second_lastname,
                    employe.email,
                    employe.charge,
                    employe.city,
                    employe.salary,
                    employe.age
                ];

                connection.query(query, values, (err, result) => {
                    if (err) {
                        console.error("Error al insertar un empleado", err);
                    } else {
                        console.log(`Empleado insertado correctamente con ID ${result.insertId}`);
                    }
                });
            });
        });
};

const uploadCsvProjects = () =>{
    const result = [];
    const filePath = path.join(__dirname, './CSVs/projects.csv');

    fs.createReadStream(filePath)
        .pipe(csv())
        .on('data', (row) =>{result.push(row);})
        .on('end', () =>{
            result.forEach((project) =>{
                const query = `INSERT INTO projects (name, description, start_date, end_date, status)
                    VALUES (?, ?, ?, ?, ?)`;

                const values = [
                    project.name,
                    project.description,
                    project.start_date,
                    project.end_date,
                    project.status
                ];

                connection.query(query, values, (err, result) =>{
                    if (err) {
                        console.error("Error al insertar un empleado", err);
                    } else {
                        console.log(`Proyecto insertado correctamente con ID ${result.insertId}`);
                    }
                });
            });
        });
};

module.exports = { uploadCsvEmployees, uploadCsvProjects };