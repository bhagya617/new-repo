use tempdb
--==>>>>question 1

CREATE TABLE Course_Details (
    C_id NVARCHAR(10),
    C_Name NVARCHAR(50),
    Start_date DATE,
    End_date DATE,
    Fee INT
);

INSERT INTO Course_Details (C_id, C_Name, Start_date, End_date, Fee)
VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);

SELECT * FROM Course_Details
 



CREATE FUNCTION Calculatetheduration(@Start_Date DATE, @End_Date DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @Start_Date, @End_Date);
END;

SELECT C_id,C_Name,Start_date,End_date, dbo.Calculatetheduration(Start_date,End_date) AS CourseDuration
FROM Course_Details



CREATE TRIGGER trigger_InsertCourseInfo
ON Course_Details
AFTER INSERT
AS
BEGIN
    INSERT INTO Course_Details(C_Name, Start_date)
    SELECT C_Name, Start_Date
    FROM INSERTED;
END;


INSERT INTO Course_Details (C_id, C_Name, Start_date, End_date, Fee)
VALUES ('PY005', 'Software enginer course', '2024-12-01', '2024-12-31', 20000);
 
SELECT * FROM Course_Details;

 
