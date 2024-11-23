-- Table: Clients
CREATE TABLE Clients (
    Client_ID INT PRIMARY KEY,
    Cname VARCHAR(50),
    Address VARCHAR(100),
    Email VARCHAR(50),
    Phone VARCHAR(15),
    Business VARCHAR(50)
);

-- Table: Employees
CREATE TABLE Employees (
    Emp_ID INT PRIMARY KEY,
    Ename VARCHAR(50),
    Designation VARCHAR(50),
    Salary DECIMAL(10, 2),
    Email VARCHAR(50),
    Phone VARCHAR(15),
    Department_ID INT
);

-- Table: Departments
CREATE TABLE Departments (
    Department_ID INT PRIMARY KEY,
    Dname VARCHAR(50),
    Location VARCHAR(50)
);

-- Table: Projects
CREATE TABLE Projects (
    Project_ID INT PRIMARY KEY,
    Pname VARCHAR(50),
    Start_Date DATE,
    End_Date DATE,
    Client_ID INT,
    Department_ID INT,
    FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
    FOREIGN KEY (Department_ID) REFERENCES Departments(Department_ID)
);

-- Table: Employee_Project_Tasks
CREATE TABLE Employee_Project_Tasks (
    Task_ID INT PRIMARY KEY,
    Task_Name VARCHAR(100),
    Project_ID INT,
    Emp_ID INT,
    Task_Start_Date DATE,
    Task_End_Date DATE,
    FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
    FOREIGN KEY (Emp_ID) REFERENCES Employees(Emp_ID)
);

-- Insert Data into Clients
INSERT INTO Clients (Client_ID, Cname, Address, Email, Phone, Business) VALUES
(1, 'Alpha Corp', 'New York', 'alpha@corp.com', '1234567890', 'Finance'),
(2, 'Beta Solutions', 'San Francisco', 'beta@solutions.com', '9876543210', 'Tech'),
(3, 'Gamma Industries', 'Chicago', 'gamma@ind.com', '5678901234', 'Manufacturing');

-- Insert Data into Departments
INSERT INTO Departments (Department_ID, Dname, Location) VALUES
(10, 'HR', 'New York'),
(20, 'IT', 'San Francisco'),
(30, 'Finance', 'Chicago');

-- Insert Data into Employees
INSERT INTO Employees (Emp_ID, Ename, Designation, Salary, Email, Phone, Department_ID) VALUES
(100, 'Alice Johnson', 'Manager', 80000, 'alice.j@company.com', '1112223334', 10),
(101, 'Bob Smith', 'Developer', 70000, 'bob.s@company.com', '4445556667', 20),
(102, 'Charlie Brown', 'Analyst', 60000, 'charlie.b@company.com', '7778889990', 30);

-- Insert Data into Projects
INSERT INTO Projects (Project_ID, Pname, Start_Date, End_Date, Client_ID, Department_ID) VALUES
(1000, 'Project X', '2024-01-01', '2024-06-30', 1, 10),
(1001, 'Project Y', '2024-02-01', '2024-07-31', 2, 20),
(1002, 'Project Z', '2024-03-01', '2024-08-15', 3, 30);

-- Insert Data into Employee_Project_Tasks
INSERT INTO Employee_Project_Tasks (Task_ID, Task_Name, Project_ID, Emp_ID, Task_Start_Date, Task_End_Date) VALUES
(2000, 'Requirement Analysis', 1000, 100, '2024-01-01', '2024-01-15'),
(2001, 'Development', 1001, 101, '2024-02-01', '2024-05-01'),
(2002, 'Testing', 1002, 102, '2024-03-01', '2024-07-01');

-- Verification Queries

-- View All Clients
SELECT * FROM Clients;

-- View All Departments
SELECT * FROM Departments;

-- View All Employees
SELECT * FROM Employees;

-- View All Projects
SELECT * FROM Projects;

-- View All Employee Project Tasks
SELECT * FROM Employee_Project_Tasks;

-- Join Query to View Employee Participation in Projects and Tasks
SELECT 
    E.Ename AS Employee_Name,
    P.Pname AS Project_Name,
    T.Task_Name AS Task_Name,
    C.Cname AS Client_Name,
    D.Dname AS Department_Name
FROM 
    Employees E
JOIN 
    Employee_Project_Tasks T ON E.Emp_ID = T.Emp_ID
JOIN 
    Projects P ON T.Project_ID = P.Project_ID
JOIN 
    Clients C ON P.Client_ID = C.Client_ID
JOIN 
    Departments D ON E.Department_ID = D.Department_ID;

-- Query to Find Employees Working on a Specific Project
SELECT 
    E.Ename, 
    P.Pname
FROM 
    Employees E
JOIN 
    Employee_Project_Tasks T ON E.Emp_ID = T.Emp_ID
JOIN 
    Projects P ON T.Project_ID = P.Project_ID
WHERE 
    P.Pname = 'Project X';

-- Query to List Departments with Employees Assigned to Projects
SELECT 
    D.Dname, 
    COUNT(DISTINCT E.Emp_ID) AS Employee_Count
FROM 
    Departments D
JOIN 
    Employees E ON D.Department_ID = E.Department_ID
JOIN 
    Employee_Project_Tasks T ON E.Emp_ID = T.Emp_ID
GROUP BY 
    D.Dname;