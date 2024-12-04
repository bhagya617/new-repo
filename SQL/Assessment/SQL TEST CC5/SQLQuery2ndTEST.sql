use student;
select * from EMP;
--q1===>>>>Write a query to display your birthday( day of week)
SELECT DATENAME(WEEKDAY, '2002-09-16') AS DayOfWeek

--q2==>>>Write a query to display your age in days
SELECT DATEDIFF(DAY, '2002-09-16', GETDATE()) AS AgeInDays

--q3=>>  Query to Display Employees Who Joined Before 5 Years in the Current Month
SELECT *
FROM EMP
WHERE HireDate < DATEADD(YEAR, -5, GETDATE())
  AND MONTH(HireDate) = MONTH(GETDATE());

 --q4==>> Perform Operations in a Single Transaction
 
 
CREATE TABLE Employee (
    EmpNo INT PRIMARY KEY,
    EName NVARCHAR(50),
    Sal DECIMAL(10, 2),
    DOJ DATE
);
 
--single transaction!!!!!!
 
BEGIN TRANSACTION;
 
-- a. Inserting 3 rows!!!!!!
INSERT INTO Employee VALUES (1, 'Alice', 1000, '2020-01-15');
INSERT INTO Employee VALUES (2, 'Bob', 1500, '2019-03-10');
INSERT INTO Employee VALUES (3, 'Charlie', 2000, '2021-05-20');
 
-- b. Update the second row salary with a 15% increment!!!!
UPDATE Employee
SET Sal = Sal * 1.15
WHERE EmpNo = 2;
 
-- c. Delete the first row!!!!!!!!
 BEGIN TRANSACTION;
DELETE FROM Employee
WHERE empno = 1;
ROLLBACK;
SELECT * FROM Employee

 --q5==>>Create a Function to Calculate Bonus
 
CREATE FUNCTION CalculateBonuss(@DeptNo INT, @Salary DECIMAL(10, 2))
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @Bonus DECIMAL(10, 2);
    IF @DeptNo = 10
        SET @Bonus = @Salary * 0.15;
    ELSE IF @DeptNo = 20
        SET @Bonus = @Salary * 0.20;
    ELSE
        SET @Bonus = @Salary * 0.05;
    RETURN @Bonus;
END;
 
--a. For Deptno 10 employees 15% of sal as bonus.
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM Emp
WHERE deptno = 10
 
--b. For Deptno 20 employees  20% of sal as bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno = 20
 
 
--c  For Others employees 5%of sal as bonus
SELECT ename, sal, dbo.CalculateBonus(deptno, sal) AS bonus
FROM EMP
WHERE deptno NOT IN (10, 20)
--q6==>>>Procedure to Update Salary for Employees in Sales Department
 
CREATE  PROCEDURE UpdateSalaryByJob AS
BEGIN
    -- Update the salary for employees with the job SALESMAN
    UPDATE EMP
    SET SAL = SAL + 500
    WHERE JOB = 'SALESMAN'
      AND SAL < 1500;
END;

EXEC UpdateSalaryByJob;

--Modifying here since it has been craeted already!!!!!!!!!!!!
ALTER PROCEDURE UpdateSalaryByJob
AS
BEGIN
    -- Update the salary for employees with the job SALESMAN
    UPDATE EMP
    SET SAL = SAL + 500
    WHERE JOB = 'SALESMAN'
      AND SAL < 1500;
 
    -- Displaying!!!!!!!
    SELECT EMPNO, ENAME, JOB, SAL
    FROM EMP
    WHERE JOB = 'SALESMAN';
END;
 
 --updated 
EXEC UpdateSalaryByJob;

