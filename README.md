# API EscuelaXYZ

## Descripción del Proyecto

Daniel es un desarrollador fullstack que fue contratado como freelance por una empresa del sector educativo. La tarea consistió en crear una API para gestionar la información relacionada con aulas, docentes y alumnos de una institución educativa.

## Funcionalidades de la API

La API desarrollada tiene las siguientes funcionalidades:

1. **Ver la lista de alumnos por cada aula**: Permite a los docentes visualizar los alumnos que están asignados a cada aula.
2. **Control de acceso por docente**: Un docente solo puede ver la lista de alumnos si está asignado a esa aula.
3. **Asignación de alumnos a aulas**: Permite asignar alumnos a aulas, asegurando que no se superen los 5 alumnos por aula. Si se intenta asignar más de 5, se muestra un mensaje correspondiente.
4. **Actualizar información de alumnos**: Los docentes pueden actualizar la información de los alumnos asignados a sus aulas.
5. **Eliminar alumnos de un aula**: Se permite eliminar un alumno de un aula si es necesario.

## Estructura de la Base de Datos

Se creó una base de datos llamada `EscuelaXYZ`, que incluye las siguientes tablas:

- **Aulas**: Contiene información sobre las aulas disponibles.
- **Docentes**: Contiene información sobre los docentes.
- **Alumnos**: Contiene información sobre los alumnos y su asignación a aulas.

### Sentencias SQL Utilizadas

A continuación, se presentan las sentencias SQL utilizadas para crear la base de datos y las tablas:

```sql
CREATE DATABASE EscuelaXYZ;

USE EscuelaXYZ;

CREATE TABLE Aulas (
    AulaID INT PRIMARY KEY IDENTITY(1,1), 
    NombreAula NVARCHAR(100) NOT NULL,    
    Capacidad INT NOT NULL                
);

CREATE TABLE Docentes (
    DocenteID INT PRIMARY KEY IDENTITY(1,1), 
    Nombre NVARCHAR(100) NOT NULL,           
    Especialidad NVARCHAR(100)               
);

CREATE TABLE Alumnos (
    AlumnoID INT PRIMARY KEY IDENTITY(1,1),  
    Nombre NVARCHAR(100) NOT NULL,           
    Edad INT,                               
    AulaID INT,                              
    FOREIGN KEY (AulaID) REFERENCES Aulas(AulaID)
);

ALTER TABLE Aulas
ADD DocenteID INT,
CONSTRAINT FK_Aula_Docente FOREIGN KEY (DocenteID) REFERENCES Docentes(DocenteID);

INSERT INTO Aulas (NombreAula, Capacidad)
VALUES ('Aula 101', 30), 
       ('Aula 102', 25);

INSERT INTO Docentes (Nombre, Especialidad)
VALUES ('Salvador M.', 'Matemáticas'),
       ('Hugo Ernesto', 'Geografía');

INSERT INTO Alumnos (Nombre, Edad, AulaID)
VALUES 
    ('Pedro Ramírez', 15, 1), 
    ('Ana Fernández', 14, 1), 
    ('Luis Martínez', 16, 2), 
    ('Sofía López', 15, 2),   
    ('Miguel Sánchez', 14, 1); 
