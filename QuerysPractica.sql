
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