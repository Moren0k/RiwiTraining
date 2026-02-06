# Bases de datos SQL – Comandos MySQL

Instalar MySQL
[Ver Instalación](/BasesDeDatos/SQL/mysql.md)

---

## Comandos básicos (Mostrar, Crear, Modificar, Eliminar)

**Entrar a MySQL desde la terminal**  
Inicia la consola de MySQL con el usuario root.

```sql
mysql -u root -p
```

**Crear una base de datos nueva**  
Crea una nueva base de datos vacía.

```sql
CREATE DATABASE nombre_de_la_base_de_datos;
```

**Ver las bases de datos creadas**  
Muestra todas las bases de datos existentes.

```sql
SHOW DATABASES;
```

**Usar una base de datos**  
Selecciona una base de datos para trabajar con ella.

```sql
USE nombre_de_la_base_de_datos;
```

**Eliminar una base de datos**  
Elimina por completo una base de datos.

```sql
DROP DATABASE nombre_de_la_base_de_datos;
```

---

## Tablas (Crear, Ver, Modificar, Eliminar)

**Crear una tabla**  
Define la estructura de una nueva tabla con columnas y tipos de datos.

```sql
CREATE TABLE nombre_tabla (
    id INT AUTO_INCREMENT PRIMARY KEY,
    clave1 VARCHAR(50),
    clave2 VARCHAR(100)
);
```

**Ver todas las tablas**  
Lista todas las tablas de la base de datos actual.

```sql
SHOW TABLES;
```

**Ver estructura de una tabla**  
Muestra las columnas y tipos de una tabla específica.

```sql
DESCRIBE nombre_tabla;
```

**Eliminar una tabla**  
Elimina una tabla y todos sus datos.

```sql
DROP TABLE nombre_tabla;
```

---

## Insertar y Consultar Datos

**Insertar un registro en una tabla**  
Agrega un solo registro (fila) a una tabla.

```sql
INSERT INTO nombre_tabla (clave1, clave2) 
VALUES (valor1, valor2);
```

**Insertar múltiples registros**  
Inserta varios registros a la vez.

```sql
INSERT INTO nombre_tabla (clave1, clave2)
VALUES
(valor1, valor2),
(valor1, valor2);
```

**Consultar todos los registros de una tabla**  
Muestra todos los datos almacenados.

```sql
SELECT * FROM nombre_tabla;
```

---

## Modificar y Eliminar Datos

**Actualizar un registro**  
Modifica el valor de un campo en un registro específico.

```sql
UPDATE nombre_tabla
SET clave1 = 'nuevo_dato'
WHERE id = 1;
```

**Eliminar un registro específico**  
Elimina un solo registro usando una condición.

```sql
DELETE FROM nombre_tabla WHERE id = 1;
```

**Eliminar todos los registros**  
Limpia completamente la tabla, pero sin eliminarla.

```sql
DELETE FROM nombre_tabla;
```

---

## Llaves primarias y foráneas

**Crear tabla con llave foránea**  
Define una relación entre dos tablas mediante una foreign key.

```sql
CREATE TABLE nombre_tabla_2 (
    id INT AUTO_INCREMENT PRIMARY KEY,
    clave_foranea INT,
    FOREIGN KEY (clave_foranea) REFERENCES nombre_tabla(id)
);
```
