create database Employee_Travel_Booking_SystemDB1

use Employee_Travel_Booking_SystemDB1

create table employees (
    employeeid int primary key identity (1806,1),
    emp_name varchar(50),
	email varchar(50),
	emp_password varchar(50),
    department varchar(50),
	position varchar(50),
	hiredate date,
    phonenumber varchar(20),
    address varchar(255),
	managerid int,
	status bit,
	foreign key (managerid) references managers(managerid) -- Reference to the managers table
)

INSERT INTO employees (emp_name, email, emp_password, department, position, hiredate, phonenumber, address, managerid)
VALUES
   
	('Pavan', 'pavan@infinite.com', 'pavan@1', 'IT', 'Software Engineer', '2024-10-16', '+916304936288', 'Visakapatnam',1708 ),
	('Tarun', 'tarun@infinite.com', 'tarun@1', 'Healthcare', 'Developer', '2024-10-16', '+919347623411', 'Visakapatnam',1711)

	
create table managers (
    managerid int primary key identity (1706,1),
    name varchar(50),
    department varchar(50),
    email varchar(50),
	mgr_password varchar(50),
	status bit,
)

INSERT INTO managers (name, department, email, mgr_password, status)
VALUES 
    ('Santhosh', 'HR', 'santhosh@infinite.com', 'santhosh@1', 1),
    ('Srikanth', 'Development', 'srikanth@infinite.com', 'srikanth@1', 0);
	
	
create table admins (
    adminid int primary key,
    name varchar(100),
    email varchar(100),
	admin_password varchar(50),
)

insert into admins values
	(1,'Admin','admin@gmail.com','password')

create table travelagents (
    agentid int primary key,
    name varchar(100),
    email varchar(100),
	travel_agent_password varchar(50),
	status bit,
)

INSERT INTO travelagents (agentid, name, email, travel_agent_password, status)
VALUES 
    (100, 'InfiniteTravels', 'infinite@gmail.com', 'infinite@1', 1);
  
 
create table travelrequest (
    requestid int primary key IDENTITY(1000,1),
    employeename varchar(100),
    employeeemail varchar(100),
    employeeid int,
    reasonfortravel varchar(255),
    flightneeded varchar(10),
    hotelneeded varchar(10),
    departurecity varchar(100),
    arrivalcity varchar(100),
    departuredate date,
    departuretime time,
   -- additionalinformation text,
	bookingstatus varchar(50) DEFAULT 'Pending' check (bookingstatus IN ('Confirmed', 'Not available', 'Pending')), -- Restriction on status
	approvalstatus VARCHAR(50) DEFAULT 'Pending' CHECK (approvalstatus IN ('Approved', 'Rejected','Pending', 'Cancelled')),
	--IdentityProofPath  NVARCHAR(200),
	foreign key (employeeid) references employees(employeeid)
)
create table Menu
(EmployeeId int Primary Key , EmployeeName varchar(40), CompanyName varchar(50), Age int);



select * from Menu


select * from Admins
select * from Employees
select * from managers
select * from TravelAgents
select * from TravelRequest







 