const express = require('express');
const cors = require('cors');
const db = require('./db');

const app = express();
app.use(cors());
app.use(express.json());

//Obtener todos los datos de la tabla people
app.get('/people', (req,res)=> {
    const sql = "SELECT * FROM people";
    db.query(sql,(err,results)=>{
        if(err){
            console.error("Error al obtener datos de la tabla people", err);
            res.status(400).json({error: "Error al obtener datos"});
        } else {
            res.json(results)
        }
    });
});

//Obtener todos los datos de la tabla works
app.get('/works', (req,res)=>{
    const sql = "SELECT * FROM works";
    db.query(sql,(err,results)=>{
        if(err){
            console.error("Error al obtener datos de la tabla works", err);
            res.status(400).json({error: "Error al obtener datos"});
        } else {
            res.json(results)
        }
    })
});

//Insertar persona
app.post('/people',(req,res)=>{
    const { name, lastname, second_lastname, email, phone, birth_date, work_id } = req.body;
    const sql = `INSERT INTO people (name, lastname, second_lastname, email, phone, birth_date, work_id)
        VALUES (?,?,?,?,?,?,?)`;
    db.query(sql, [name, lastname, second_lastname, email, phone, birth_date, work_id], (err, result) =>{
        if (err) {
            console.error("Error al insertar datos:", err);
            return res.status(400).json({error: "Error al insertar"});
        }
        res.json({message: "Persona agregada correctamente", id: result.insertId});
    });
});

//Insertar trabajo
app.post('/works', (req,res)=>{
    const {job_title} = req.body;
    const sql = `INSERT INTO works (job_title)
        VALUES (?)`;
    db.query(sql, [job_title], (err, result) =>{
        if (err) {
            console.error("Error al insertar datos:", err);
            return res.status(400).json({error: "Error al insertar"});
        }
        res.json({message: "Trabajo agregado correctamente", id: result.insertId});
    });
});







//Arranque del servidor
app.listen(process.env.PORT, ()=>{
    console.log(`Servidor backend corriendo en http://localhost:${process.env.PORT}`)
})