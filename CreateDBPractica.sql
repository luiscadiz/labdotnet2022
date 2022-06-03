/*V2 - 16/10/2015 */
USE [master]
GO
IF EXISTS (SELECT * FROM sys.databases d WHERE d.[name]='PracticaSQL')
BEGIN
	ALTER DATABASE [PracticaSQL] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
END
GO
USE [master]
GO
IF EXISTS (SELECT * FROM sys.databases d WHERE d.[name]='PracticaSQL')
BEGIN
	DROP DATABASE [PracticaSQL]
END
GO
CREATE DATABASE PracticaSQL
GO
USE PracticaSQL
GO
CREATE SCHEMA TEST 
GO
-- Tablas
create table TEST.EMPLOYEES (ID INT primary key, FIRST_NAME VARCHAR(50) NOT NULL, LAST_NAME VARCHAR(50) NOT NULL, SALARY DECIMAL (10,2), DEPARTMENT_ID INT, JOB_ID VARCHAR(6), HIRE_DATE DATETIME NOT NULL, MANAGER_ID INT);

create table TEST.DEPARTMENTS (ID INT primary key, DEPARTMENT_NAME VARCHAR(100) NOT NULL, LOCATION_ID INT NOT NULL, DEPARTMENT_DESCRIPTION VARCHAR(256));

create table TEST.LOCATIONS (ID INT primary key, CITY VARCHAR(100) NOT NULL);

create table TEST.JOBS (ID VARCHAR(6) primary key, JOB_NAME VARCHAR(100) NOT NULL);

-- Relaciones
alter table TEST.EMPLOYEES add constraint EMP_DEP foreign key (DEPARTMENT_ID) references TEST.DEPARTMENTS;
alter table TEST.EMPLOYEES add constraint EMP_JOB foreign key (JOB_ID) references TEST.JOBS;
alter table TEST.EMPLOYEES add constraint EMP_EMP foreign key (MANAGER_ID) references TEST.EMPLOYEES;
alter table TEST.DEPARTMENTS add constraint DEP_LOC foreign key (LOCATION_ID) references TEST.LOCATIONS;

-- Datos
insert into TEST.JOBS (ID, JOB_NAME) VALUES ('AD_CTB', 'Administrativo / Contable');
insert into TEST.JOBS (ID, JOB_NAME) VALUES ('AD_PBC', 'Atención al público');
insert into TEST.JOBS (ID, JOB_NAME) VALUES ('FQ_GRT', 'Gerente');
insert into TEST.JOBS (ID, JOB_NAME) VALUES ('FQ_SPV', 'Supervisor');
insert into TEST.JOBS (ID, JOB_NAME) VALUES ('FQ_OPR', 'Operario');

insert into TEST.LOCATIONS (ID, CITY) VALUES (1, 'Buenos Aires');
insert into TEST.LOCATIONS (ID, CITY) VALUES (2, 'Rosario');
insert into TEST.LOCATIONS (ID, CITY) VALUES (3, 'Córdoba');

insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID) VALUES (10, 'Administración y Finanzas', 1);
insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID, DEPARTMENT_DESCRIPTION) VALUES (20, 'Recursos Humanos', 1, 'Selección y administración de personal');
insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID) VALUES (30, 'Ensamblaje A1', 2);
insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID) VALUES (31, 'Ensamblaje A2', 3);
insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID) VALUES (40, 'Empaquetado', 1);
insert into TEST.DEPARTMENTS (ID, DEPARTMENT_NAME, LOCATION_ID) VALUES (50, 'Control de calidad', 1);

-- Managers
insert into TEST.EMPLOYEES VALUES (1, 'Mariana', 'Frankovich', 2050.0, 10, 'FQ_GRT', '2008-10-01', NULL);
insert into TEST.EMPLOYEES VALUES (2, 'Ernesto', 'Gonzalez', 2000.0, 10, 'FQ_GRT', '2008-10-01', NULL);
-- Supervisores
insert into TEST.EMPLOYEES VALUES (3, 'José', 'Michetti', 1500.0, 30, 'FQ_SPV', '2008-11-01', 1);
insert into TEST.EMPLOYEES VALUES (4, 'María Emilia', 'Uriarte', 1500.0, 31, 'FQ_SPV', '2008-11-15', 1);
insert into TEST.EMPLOYEES VALUES (5, 'Juan Cruz', 'Angeloz', 1650.0, 40, 'FQ_SPV', '2009-01-12', 2);
-- Operarios
insert into TEST.EMPLOYEES VALUES (6, 'Juan Andrés', 'Cosimo', 1000.0, 30, 'FQ_OPR', '2008-11-01', 3);
insert into TEST.EMPLOYEES VALUES (7, 'Nora Carla', 'Feliciano', 1100.0, 30, 'FQ_OPR', '2008-11-01', 3);
insert into TEST.EMPLOYEES VALUES (8, 'Cristina', 'Nuncio', 980.0, 31, 'FQ_OPR', '2009-02-01', 4);
insert into TEST.EMPLOYEES VALUES (9, 'Nicanor', 'Petronelli', 980.0, 31, 'FQ_OPR', '2009-03-24', 4);
insert into TEST.EMPLOYEES VALUES (10, 'Fernando', 'Quesada', 1000.0, 31, 'FQ_OPR', '2009-04-01', 4);
insert into TEST.EMPLOYEES VALUES (11, 'Máximo', 'Ventino', 980.0, 40, 'FQ_OPR', '2009-04-01', 5);
insert into TEST.EMPLOYEES VALUES (12, 'Gustavo', 'Boulette', 850.0, 40, 'FQ_OPR', '2010-11-03', 5);
-- Adm
insert into TEST.EMPLOYEES VALUES (13, 'Fermín', 'Dominicis', 1880.0, 10, 'AD_CTB', '2008-10-01', NULL);
insert into TEST.EMPLOYEES VALUES (14, 'Nanci', 'Juarez', 1050.0, 10, 'AD_PBC', '2010-04-01', 13);
-- RRHH
-- 	Nadie
-- Calidad
insert into TEST.EMPLOYEES VALUES (15, 'Ana María', 'Gomez', 1250.0, 50, 'FQ_OPR', '2010-04-01', 5); 
-- Nuevos ingresos
insert into TEST.EMPLOYEES VALUES (16, 'Hugo Anibal', 'Lopez Ortiz', NULL, NULL, NULL, '2011-10-01', NULL);
insert into TEST.EMPLOYEES VALUES (17, 'Roberto', 'Lupi', NULL, NULL, NULL, '2011-10-01', NULL);
insert into TEST.EMPLOYEES VALUES (18, 'Luisa', 'Curi', NULL, NULL, NULL, '2011-10-01', NULL);

-----------------------------------------CONSULTAS--------------------------------------------------------------


SELECT * FROM TEST.EMPLOYEES

-- 26- Recuperar lista de empleados con la descripción del departamento, tengan o no
-- departamento asignado.

SELECT (E.FIRST_NAME + E.LAST_NAME) AS APELLIDO_COMPLETO,  
        D.DEPARTMENT_DESCRIPTION AS DESCRIPCION
FROM TEST.EMPLOYEES AS E 
LEFT JOIN TEST.DEPARTMENTS AS D
ON E.DEPARTMENT_ID = D.ID


--27- Recuperar lista de departamentos con empleados de cada departamento, tengan o no
-- empleados asociados.

SELECT  D.DEPARTMENT_NAME AS DEPARTAMENTO,
        (E.LAST_NAME + E.FIRST_NAME) AS NOMBRE_COMPLETO
FROM TEST.EMPLOYEES AS E
RIGHT JOIN TEST.DEPARTMENTS AS D
ON E.DEPARTMENT_ID = D.ID

-- 28- Recuperar lista de subordinados por cada manager


SELECT E.LAST_NAME, E.MANAGER_ID AS MANAGER 
FROM TEST.EMPLOYEES AS E
LEFT JOIN TEST.EMPLOYEES AS EM
ON E.ID = EM.MANAGER_ID

--29- Recuperar máximo salario de los empleados.

SELECT  E.LAST_NAME AS NOMBRES,
        MAX(E.SALARY) AS MAXIMO_SALARIO
FROM TEST.EMPLOYEES AS E
GROUP BY LAST_NAME

-- 30- Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.

SELECT  MAX(E.SALARY) MAX_SALARIO,
        MIN(E.SALARY) MIN_SALARIO,
        AVG(E.SALARY) PROM_SALARIO,
        SUM(E.SALARY) SUM_SALARIO
FROM TEST.EMPLOYEES AS E

-- 31- Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de los
--empleados.
--Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de dato.

SELECT  MAX(E.HIRE_DATE) MAX_FECHA,
        MIN(E.HIRE_DATE) MIN_FECHA
        --AVG(E.HIRE_DATE) PROM_FECHA,
        --SUM(E.HIRE_DATE) SUM_FECHA
FROM TEST.EMPLOYEES AS E


-- 32- Obtener la cantidad de empleados.

SELECT COUNT(ID)
FROM TEST.EMPLOYEES

-- 33- Obtener la cantidad de empleados cuyo departamento sea 10.

SELECT COUNT(E.DEPARTMENT_ID)
FROM TEST.EMPLOYEES AS E
WHERE E.DEPARTMENT_ID = 10

-- VERSION CON SUBCONSULTA 
SELECT COUNT(E.DEPARTMENT_ID)
FROM TEST.EMPLOYEES AS E
WHERE E.DEPARTMENT_ID = (SELECT D.ID 
                        FROM TEST.DEPARTMENTS AS D
                        WHERE D.DEPARTMENT_NAME = 'Administración y Finanzas')


-- 34- Obtener la cantidad de empleados de cada departamento.

SELECT  D.DEPARTMENT_NAME AS NOM_DEPARTAMENTO,
        COUNT(E.ID) AS CANT_EMPLEADOS
FROM TEST.EMPLOYEES AS E
RIGHT JOIN TEST.DEPARTMENTS AS D
ON E.DEPARTMENT_ID = D.ID
GROUP BY(DEPARTMENT_NAME)

-- 35- Obtener la cantidad de empleados por cada departamento y job.


