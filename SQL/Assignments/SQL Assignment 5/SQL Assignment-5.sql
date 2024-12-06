use tempdb;
--Q1==>> Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

CREATE PROCEDURE GeneratePayslip
    @EmployeeID INT,
    @Salary FLOAT
AS
BEGIN
    DECLARE @HRA FLOAT, @DA FLOAT, @PF FLOAT, @IT FLOAT;
    DECLARE @GrossSalary FLOAT, @Deductions FLOAT, @NetSalary FLOAT;
 
  
    SET @HRA = @Salary * 0.10; 
    SET @DA = @Salary * 0.20; 
    SET @PF = @Salary * 0.08; 
    SET @IT = @Salary * 0.05; 
 
   
    SET @GrossSalary = @Salary + @HRA + @DA;
    SET @Deductions = @PF + @IT;

    SET @NetSalary = @GrossSalary - @Deductions;
 
    PRINT 'Payslip for Employee ID: ' + CAST(@EmployeeID AS VARCHAR);
    PRINT '---------------------------------------';
    PRINT 'Basic Salary: ' + CAST(@Salary AS VARCHAR);
    PRINT 'HRA: ' + CAST(@HRA AS VARCHAR);
    PRINT 'DA: ' + CAST(@DA AS VARCHAR);
    PRINT 'PF: ' + CAST(@PF AS VARCHAR);
    PRINT 'IT: ' + CAST(@IT AS VARCHAR);
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR);
    PRINT 'Deductions: ' + CAST(@Deductions AS VARCHAR);
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR);
    PRINT '---------------------------------------';
END;
 EXEC GeneratePayslip
 @employeeid=101,@salary=50000;


--Q2==>> 2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

CREATE TABLE Holidays (
    holiday_date DATE NOT NULL,
    holiday_name NVARCHAR(50) NOT NULL
);
 

INSERT INTO Holidays (holiday_date, holiday_name)
VALUES
    ('2024-08-15', 'Independence Day'),
    ('2024-01-26', 'Republic Day'),
    ('2024-10-02', 'Gandhi Jayanti'),
    ('2024-11-12', 'Diwali');
 

CREATE TABLE EMP (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Salary FLOAT
);
 

CREATE TRIGGER RestrictOnHolidays
ON EMP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @today DATE = CAST(GETDATE() AS DATE);
    DECLARE @holiday_name NVARCHAR(50);
 
    SELECT @holiday_name = holiday_name
    FROM Holidays
    WHERE holiday_date = @today;
 
    IF @holiday_name IS NOT NULL
    BEGIN
        RAISERROR ('Due to %s, you cannot manipulate data', 16, 1, @holiday_name);
        ROLLBACK TRANSACTION;
    END
END;
 

INSERT INTO EMP (EmployeeID, Name, Salary)
VALUES (1011, 'Jane desoza', 50000);
 

DELETE FROM Holidays WHERE holiday_date = CAST(GETDATE() AS DATE);
 
INSERT INTO EMP (EmployeeID, Name, Salary)
VALUES (102, 'Jones Aron', 60000);