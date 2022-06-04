USE PracticaSQL
GO

/*A – Recuperación básica de datos
SQL Básico / Tipos de datos / Operaciones / Alias de columnas / Valor nulo*/

-- 1- Recuperar lista de empleados
-- Tip: usar * para seleccionar todas las columnas

SELECT * FROM TEST.EMPLOYEES
GO

-- 2- Recuperar id, apellido, fecha de contratación de los empleados

SELECT  ID, 
		LAST_NAME, 
		SALARY, 
		HIRE_DATE
FROM TEST.EMPLOYEES
GO

-- 3- Recuperar id, apellido, fecha de contratación, salario de los empleados.
--Tip: notar presencia de valores nulos

SELECT  ID, 
		LAST_NAME, 
		HIRE_DATE, 
		SALARY 
FROM TEST.EMPLOYEES
GO

--4- Recuperar id, apellido, fecha de contratación, salario anual de los empleados.
--Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual.

SELECT  ID, 
		LAST_NAME, 
		HIRE_DATE, 
		(SALARY *12) AS SUELDO_ANUAL
FROM TEST.EMPLOYEES
GO

/*5- Recuperar id, apellido y nombre, fecha de contratación, salario anual de los empleados.
	Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de
	los campos.
*/

SELECT  ID, 
		(LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		HIRE_DATE, 
		(SALARY *12) AS SueldoAnual
FROM TEST.EMPLOYEES
GO

/*6- Recuperar lista de departamentos que tienen empleados:
  6.a- Recuperar lista de departamentos de los empleados
  6.b- Recuperar lista no repetida de departamentos de los empleados
*/
--Punto 6.a
SELECT DEPARTMENT_NAME FROM TEST.DEPARTMENTS
GO

--Punto 6.b
SELECT DISTINCT DEPARTMENT_NAME FROM TEST.DEPARTMENTS
GO

--B – Comparaciones simples y especiales / Comparaciones nulas

--7- Recuperar lista de empleados cuyo departamento sea 10.

SELECT  (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		DEPARTMENT_ID AS NRO_DPTO
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID = 10
GO

-- 8- Recuperar lista de empleados cuyo salario sea menor a 2000.

SELECT  (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		SALARY AS SALARIO
FROM TEST.EMPLOYEES
WHERE SALARY < 2000
GO

/*9- Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
	 Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones
*/

SELECT  (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		SALARY AS SALARIO
FROM TEST.EMPLOYEES
WHERE SALARY BETWEEN 1800 AND 3000
GO

/*  10- Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
	Tip: usar cláusula “in”.
*/

SELECT  (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		DEPARTMENT_ID AS NRO_DPTO
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID in (10,30,31)

/*  11- Recuperar lista de empleados cuyo apellido empiece con F.
	Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de dato de los
	campos.
*/

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE
FROM TEST.EMPLOYEES
WHERE LAST_NAME LIKE 'F%'

/*  12- Recuperar lista de empleados cuyo job_id:
	12.a- no hay sido definido
	12.b- haya sido definido. 
*/

--Punto 12-a 
SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE JOB_ID IS NULL

--Punto 12-b
SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE JOB_ID IS NOT NULL

/* 
13- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’. 
	Tip: Notar comportamiento de la condición con jobs nulos.
*/

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE JOB_ID != 'AD_CTB'

-- C- Comparaciones con nexos lógicos / Precedencia de condiciones

/*  14- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ y cuyo salario sea
	mayor a 1900.
*/

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS Apelido_Nombre,
		SALARY AS SALARIO,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE JOB_ID != 'AD_CTB' AND SALARY > 1900

/*  15- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ o cuyo salario sea
	mayor a 1900.
*/

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS Apelido_Nombre,
		SALARY AS SALARIO,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE JOB_ID != 'AD_CTB' OR SALARY > 1900

/*  16- Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar IN) y cuyo
	salario sea mayor a 1900.
	Tip: Probar precedencia de condiciones con o sin paréntesis.
*/

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS Apelido_Nombre,
		SALARY AS SALARIO,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE 1=1 
AND	JOB_ID = 'AD_CTB'
OR JOB_ID = 'FQ_GRT'
AND SALARY > 1900

--CON PRECEDENCIA DE PARENTESIS
SELECT (LAST_NAME + ' ' + FIRST_NAME) AS Apelido_Nombre,
		SALARY AS SALARIO,
		JOB_ID
FROM TEST.EMPLOYEES
WHERE 1=1 
AND	(JOB_ID = 'AD_CTB' OR JOB_ID = 'FQ_GRT')
AND SALARY > 1900

-- D- Ordenamiento
--17- Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más nuevo).

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		HIRE_DATE AS FEC_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE

-- 18- Recuperar empleados ordenados por fecha de ingreso (desde más nuevo a más viejo).

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		HIRE_DATE AS FEC_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE DESC

-- 19- Recuperar empleados ordenados por fecha de ingreso descendente y apellido ascendente.

SELECT (LAST_NAME + ' ' + FIRST_NAME) AS APELLIDO_NOMBRE,
		HIRE_DATE AS FEC_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE DESC, LAST_NAME ASC

/*
	20- Recuperar apellido y salario anual de empleados ordenados por salario anual.
	Tip: Usar alias de columna para ordenar por salario anual.
*/

SELECT  LAST_NAME AS APELLIDO,
		(SALARY * 12) AS SALARIO_ANUAL
FROM TEST.EMPLOYEES
WHERE SALARY IS NOT NULL
ORDER BY SALARIO_ANUAL DESC

-- E- Recuperación de datos de múltiples tablas

/* 21- Recuperar lista de empleados con la descripción del departamento al que cada uno
pertenece. Tip: evitar producto cartesiano.
Completar: select * from TEST.EMPLOYEES, … */

SELECT (EMP.LAST_NAME + ' ' + EMP.FIRST_NAME) AS APELLIDO_NOMBRE,
		DEP.DEPARTMENT_DESCRIPTION AS DESCRIPCION
FROM TEST.EMPLOYEES AS EMP, TEST.DEPARTMENTS AS DEP
WHERE EMP.DEPARTMENT_ID = DEP.ID

-- 22- Seleccionar apellido de empleado y nombre de departamento

SELECT  EMP.LAST_NAME AS APELLIDO,
		DEP.DEPARTMENT_NAME AS DEPARTAMENTO
FROM TEST.EMPLOYEES AS EMP, TEST.DEPARTMENTS AS DEP
WHERE EMP.DEPARTMENT_ID = DEP.ID

--23- Agregar id de empleado y id de departamento
--Tip: desambiguar campos usando alias de tablas.

SELECT  EMP.ID AS NUM_EMPLEADO,
		EMP.LAST_NAME  AS APELLIDO,
		DEP.ID AS NUM_DEPARTAMENTO,
		DEP.DEPARTMENT_NAME AS DESCRIPCION
FROM TEST.EMPLOYEES AS EMP, TEST.DEPARTMENTS AS DEP
WHERE EMP.DEPARTMENT_ID = DEP.ID

--24- Recuperar lista de empleados con descipción de departamentos y ciudades.

SELECT  (EMP.LAST_NAME + ' ' + EMP.FIRST_NAME) AS APELLIDO_NOMBRE,
		DEP.DEPARTMENT_NAME AS DEPARTAMENTO,
		LOC.CITY AS CIUDAD
FROM TEST.EMPLOYEES AS EMP, 
	 TEST.DEPARTMENTS AS DEP,
	 TEST.LOCATIONS AS LOC
WHERE EMP.DEPARTMENT_ID = DEP.ID
AND DEP.LOCATION_ID = LOC.ID

-- F- Uso de cláusula JOIN
--25- Recuperar lista de empleados con la descripción del departamento al que cada uno
--pertenece.

SELECT (EMP.LAST_NAME + ' ' + EMP.FIRST_NAME) AS APELLIDO_NOMBRE,
		DEP.DEPARTMENT_DESCRIPTION AS DESCRIPCION
FROM TEST.EMPLOYEES AS EMP
JOIN TEST.DEPARTMENTS AS DEP
ON EMP.DEPARTMENT_ID = DEP.ID

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