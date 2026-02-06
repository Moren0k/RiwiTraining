CREATE DATABASE riwi;

USE riwi;

CREATE TABLE employees (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    second_lastname VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    charge VARCHAR(50),
    city VARCHAR(50),
    salary INT,
    age INT NOT NULL
);


CREATE TABLE projects (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    description TEXT,
    start_date DATE,
    end_date DATE,
    status VARCHAR(50)
);
