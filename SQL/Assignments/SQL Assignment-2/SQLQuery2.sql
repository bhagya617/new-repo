CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(50),
    JOB VARCHAR(50),
    MGR_ID INT,
    HIREDATE DATE,
    SAL INT,
    COMM INT,
    DEPTNO INT
);

CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(50),
    LOC VARCHAR(50)
);

INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

INSERT INTO EMP (EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, NULL, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

--Q1
SELECT * FROM EMP WHERE ENAME LIKE 'A%';

--Q2
SELECT * FROM EMP WHERE MGR_ID IS NULL;

--Q3
SELECT ENAME, EMPNO, SAL FROM EMP WHERE SAL BETWEEN 1200 AND 1400;

--Q4
-- Has to Display employees in the RESEARCH department before the pay rise
SELECT 'Before Update' AS Status, * 
FROM EMP 
WHERE DEPTNO = 20;

-- Have to Update salaries for employees in the RESEARCH department
UPDATE EMP 
SET SAL = SAL * 1.1 
WHERE DEPTNO = 20;

--Have to Display employees in the RESEARCH department after the pay rise
SELECT 'After Update' AS Status, * 
FROM EMP 
WHERE DEPTNO = 20;

--Q5
SELECT COUNT(*) AS "Total Number of Clerks in the Company" 
FROM EMP 
WHERE JOB = 'CLERK';

--Q6
SELECT JOB, AVG(SAL) AS "Average Salary", COUNT(*) AS "Number of Employees"
FROM EMP
GROUP BY JOB;

--Q7
--For lowest salary
SELECT * 
FROM EMP 
WHERE SAL = (SELECT MIN(SAL) FROM EMP);

-- For highest salary
SELECT * 
FROM EMP 
WHERE SAL = (SELECT MAX(SAL) FROM EMP);

--Q8
SELECT D.DEPTNO AS "Department Number", 
       D.DNAME AS "Department Name", 
       D.LOC AS "Location"
FROM DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
WHERE E.DEPTNO IS NULL;
--Q9
SELECT ENAME, SAL 
FROM EMP 
WHERE JOB = 'ANALYST' AND SAL > 1200 AND DEPTNO = 20
ORDER BY ENAME ASC;

--Q10
SELECT DEPT.DNAME, 
       DEPT.DEPTNO, 
       SUM(EMP.SAL)
FROM DEPT
LEFT JOIN EMP ON DEPT.DEPTNO = EMP.DEPTNO
GROUP BY DEPT.DNAME, DEPT.DEPTNO;

--Q11
SELECT ENAME, SAL 
FROM EMP 
WHERE ENAME IN ('MILLER', 'SMITH');

--Q12
SELECT ENAME 
FROM EMP 
WHERE ENAME LIKE 'A%' OR ENAME LIKE 'M%';

--Q13
SELECT ENAME, SAL * 12 AS "Yearly Salary" 
FROM EMP 
WHERE ENAME = 'SMITH';

--Q14
SELECT ENAME, SAL 
FROM EMP 
WHERE SAL NOT BETWEEN 1500 AND 2850;

--Q15
