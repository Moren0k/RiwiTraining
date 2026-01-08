import mysql from 'mysql2';

const db = mysql.createConnection({
    hots: 'localhost',
    user: 'root',
    password: '',
    database: 'riwi'
});

db.connect(err =>{
    if(err) {
        console.error("Error al conectar al mysql", err);
        return;
    }
    console.log("Conectadoa la BD");
});

export default db;