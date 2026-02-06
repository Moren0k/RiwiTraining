# Proyecto

## Instalaciones

Instalamos `express`,`mysql2`,`csv-parser`,`multer`

```js
npm i express mysql2 csv-parser multer
```

### Creamos

**Base de datos llamada Riwi**
CREATE DATABASE riwi;

**Tabla llamada employees**
CREATE TABLE employees(idEmployee INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(100) NOT NULL, lastname VARCHAR(50) NOT NULL, lastname2 VARCHAR(50) NOT NULL, email VARCHAR(50) NOT NULL, charge VARCHAR(50) NOT NULL, city VARCHAR(100) NOT NULL, salary FLOAT NOT NULL, age DECIMAL(10,0) NOT NULL);

### consola

```js
npm init -y
```
