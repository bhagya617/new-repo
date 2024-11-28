use student;
select * from EMP

--Q1 ==>>Retrieve a list of MANAGERS.
 
SELECT DISTINCT ENAME,JOB
FROM EMP
WHERE JOB = 'MANAGER';

--Q2==>>  Find out the names and salaries of all employees earning more than 1000 per month.
 
SELECT ENAME, SAL
FROM EMP
WHERE SAL > 1000;

--Q3==>>Display the names and salaries of all employees except JAMES.
 
SELECT ENAME, SAL
FROM EMP
WHERE ENAME != 'JAMES';
 
--Q4==>> Find out the details of employees whose names begin with 'S'.
 
SELECT *
FROM EMP
WHERE ENAME LIKE 'S%';
 
 
--Q5==>> Find out the names of all employees that have 'A' anywhere in their name.
 
SELECT ENAME
FROM EMP
WHERE ENAME LIKE '%A%';
 
 
--Q6==>> Find out the names of all employees that have 'L' as their third character in their name.
 
SELECT ENAME
FROM EMP
WHERE ENAME LIKE '__L%';
 
 
--Q7==>>Compute daily salary of JONES.
 
SELECT ENAME, SAL / 30 AS DAILY_SALARY
FROM EMP
WHERE ENAME = 'JONES';
 
 
--Q8==>>Calculate the total monthly salary of all employees.
 
SELECT SUM(SAL) AS TOTAL_MONTHLY_SALARY
FROM EMP;
 
 
--Q9==>>Print the average annual salary.
 
SELECT AVG(SAL * 12) AS AVG_ANNUAL_SALARY
FROM EMP;
 
 
--Q10==>>Select the name, job, salary, department number of all employees except SALESMAN from department number 30.
 
SELECT ENAME, JOB, SAL, DEPTNO
FROM EMP
WHERE DEPTNO = 30 AND JOB != 'SALESMAN';
 
 
--Q11==>> List unique departments of the EMP table.
 
SELECT DISTINCT DEPTNO
FROM EMP;
 
 
--Q12==>> List the name and salary of employees who earn more than 1500 and are in department 10 or 30.
 
SELECT ENAME AS Employee ,SAL AS Monthly_Salary
FROM EMP
WHERE SAL > 1500 AND DEPTNO IN (10, 30);
 
 
--Q13=>>Display the name, job, and salary of all employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
 
SELECT ENAME, JOB, SAL
FROM EMP
WHERE JOB IN ('MANAGER', 'ANALYST') AND SAL NOT IN (1000, 3000, 5000);
 
 
--Q14==>>Display the name, salary, and commission for all employees whose commission amount is greater than their salary increased by 10%.
 
SELECT ENAME, SAL, COMM
FROM EMP
WHERE COMM > SAL * 1.10;
 
 
--Q15==>>Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
 
SELECT ENAME
FROM EMP
WHERE ENAME LIKE '%L%L%' AND (DEPTNO = 30 OR MGR_ID = 7782);
 
 
--Q16==>>Display the names of employees with experience of over 30 years and under 40 years. Count the total number of employees.
SELECT
    ENAME,
    DATEDIFF(YEAR, HIREDATE, GETDATE()) AS EXPERIENCE_YEARS
FROM
    EMP
WHERE
    DATEDIFF(YEAR, HIREDATE, GETDATE()) BETWEEN 30 AND 40
 
SELECT COUNT(*) AS TOTAL_EMPLOYEES
FROM EMP;
 
 
--Q17==>>Retrieve the names of departments in ascending order and their employees in descending order.
 
--SELECT D.DNAME, E.ENAME
--FROM DEPT D
--JOIN EMP E ON D.DEPTNO = E.DEPTNO
--ORDER BY D.DNAME ASC ,E.ENAME DESC;

SELECT D.DNAME
FROM DEPT D
ORDER BY D.DNAME ASC;
 

SELECT E.ENAME
FROM EMP E
ORDER BY E.ENAME DESC;

--Q18 ==>> Find out the experience of MILLER.
SELECT
    ENAME,
    DATEDIFF(YEAR, HIREDATE, GETDATE()) AS EXPERIENCE_YEARS
FROM
    EMP
WHERE
    ENAME = 'MILLER'




 