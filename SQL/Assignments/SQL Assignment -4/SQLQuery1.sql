use tempdb;
--Q1==>>Write a T-SQL Program to find the factorial of a given number.

CREATE PROCEDURE GetFactorial (@Number INT)
AS
BEGIN
    DECLARE @Factorial INT = 1;
    DECLARE @Counter INT = 1;
    
    IF @Number < 0
    BEGIN
        PRINT 'Factorial is not defined for negative numbers';
        RETURN;
    END
    
    WHILE @Counter <= @Number
    BEGIN
        SET @Factorial = @Factorial * @Counter;
        SET @Counter = @Counter + 1;
    END
    
    PRINT 'Factorial of ' + CAST(@Number AS VARCHAR) + ' is ' + CAST(@Factorial AS VARCHAR);
END;
 
 
EXEC GetFactorial @Number = 5;

--Q2==>>Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number. 

CREATE PROCEDURE dbo.GenerateMultiplicationTable
    @Number INT,
    @MaxMultiplier INT
AS
BEGIN
   
    CREATE TABLE #MultiplicationTable (Multiplier INT, Result INT);
 
    DECLARE @Multiplier INT = 1;

    WHILE @Multiplier <= @MaxMultiplier
    BEGIN
        INSERT INTO #MultiplicationTable (Multiplier, Result)
        VALUES (@Multiplier, @Number * @Multiplier);  -- Fixed multiplication statement

        SET @Multiplier = @Multiplier + 1;  -- Corrected assignment statement
    END

    SELECT * FROM #MultiplicationTable;

    DROP TABLE #MultiplicationTable;
END;
EXEC dbo.GenerateMultiplicationTable @Number = 5, @MaxMultiplier = 10;


--Q3==>>Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly

CREATE FUNCTION GetStudentStatus (@Sid INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Status VARCHAR(10);
    DECLARE @Score INT;
 
    SELECT @Score = Score FROM Marks WHERE Sid = @Sid;
 
    IF @Score >= 50
    BEGIN
        SET @Status = 'Pass';
    END
    ELSE
    BEGIN
        SET @Status = 'Fail';
    END
 
    RETURN @Status;
END;
 

CREATE TABLE Student (
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);
 
INSERT INTO Student VALUES (1, 'Jack'), (2, 'Rithvik'), (3, 'Jaspreeth'), (4, 'Praveen'), (5, 'Bisa'), (6, 'Suraj');
 
CREATE TABLE Marks (
    Mid INT PRIMARY KEY,
    Sid INT,
    Score INT,
    FOREIGN KEY (Sid) REFERENCES Student(Sid)
);
 
INSERT INTO Marks VALUES (1, 1, 23), (2, 2, 95), (3, 3, 98), (4, 4, 17), (5, 5, 53), (6, 6, 13);

SELECT S.Sid, S.Sname, M.Score, dbo.GetStudentStatus(S.Sid) AS Status
FROM Student S
JOIN Marks M ON S.Sid = M.Sid;