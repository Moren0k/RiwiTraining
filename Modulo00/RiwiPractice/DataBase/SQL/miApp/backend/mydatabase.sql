-- database.sql
CREATE DATABASE IF NOT EXISTS mydatabase;
USE contacts_db;

CREATE TABLE IF NOT EXISTS works (
    id INT AUTO_INCREMENT PRIMARY KEY,
    job_title VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS people (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    second_lastname VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    birth_date DATE NOT NULL,
    work_id INT,
    FOREIGN KEY (work_id) REFERENCES works(id) ON DELETE SET NULL ON UPDATE CASCADE
);

INSERT INTO works (job_title) VALUES
('Diseñadora'), ('UX Lead'), ('Vendedor'), ('Desarrollador');

INSERT INTO people (name, lastname, second_lastname, email, phone, birth_date, work_id) VALUES
('Ana','Gómez','Pérez','ana.gomezp@example.com','3001112233','1995-04-12',1),
('Luis','Martínez','Rodríguez','luis.martinezr@example.com','3102223344','1990-09-05',2),
('María','López','García','maria.lopezg@example.com','3203334455','1988-12-22',3),
('Carlos','Ruiz','Fernández','carlos.ruizf@example.com','3014445566','1999-01-15',4),
('Sofía','Hernández','Torres','sofia.hernandezt@example.com','3155556677','2001-07-30',3);
