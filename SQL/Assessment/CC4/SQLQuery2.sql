create database assessment1
use assessment1;
--Question => Write a query to fetch the details of the books written by author whose name ends with er.
--Display the Title ,Author and ReviewerName for all the books from the above table
--Display the  reviewer name who reviewed more than one book.
CREATE TABLE books (
    id INT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255) NOT NULL,
    isbn VARCHAR(13) UNIQUE NOT NULL,
    published_date DATETIME NOT NULL
);
 
CREATE TABLE reviews (
    id INT PRIMARY KEY,
    book_id INT,
    reviewer_name VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    published_date DATETIME NOT NULL,
    FOREIGN KEY (book_id) REFERENCES books(id)
);

INSERT INTO books (id, title, author, isbn, published_date) VALUES
(1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');
 

INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date) VALUES
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12'),
(3, 3, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');


SELECT * FROM books
WHERE author LIKE '%er';

SELECT reviewer_name
FROM reviews
GROUP BY reviewer_name
HAVING COUNT(book_id) > 1;

SELECT b.title, b.author, r.reviewer_name
FROM books b
JOIN reviews r ON b.id = r.book_id;

--question => Display the Names of the Employee in lower case, whose salary is null
CREATE TABLE customer (
    ID INT PRIMARY KEY,
    NAME VARCHAR(255),
    AGE INT,
    ADDRESS VARCHAR(255),
    SALARY DECIMAL(10, 2)
);


INSERT INTO customer (ID, NAME, AGE, ADDRESS, SALARY) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 18.00),
(6, 'Komal', 22, 'MP', NULL),  
(7, 'Muffy', 24, 'Indore', NULL);  



SELECT LOWER(NAME)
FROM customer
WHERE SALARY IS NULL;

--question =>Write a query to display the   Date,Total no of customer  placed order on same Date

CREATE TABLE orders (
    OID INT PRIMARY KEY,
    ORDER_DATE DATETIME,
    CUSTOMER_ID INT,
    AMOUNT DECIMAL(10, 2)
);
 

 
INSERT INTO orders (OID, ORDER_DATE, CUSTOMER_ID, AMOUNT) VALUES
(102, '2009-10-08 00:00:00', 3, 3000.00),
(100, '2009-10-08 00:00:00', 3, 1500.00),
(101, '2009-11-20 00:00:00', 2, 1560.00),
(103, '2008-05-20 00:00:00', 41, 2060.00);
 

SELECT ORDER_DATE, COUNT(CUSTOMER_ID) AS total_customers
FROM orders
GROUP BY ORDER_DATE
ORDER BY ORDER_DATE;


--question =>Write a sql server query to display the Gender,Total no of male and female from the above relation
                 
CREATE TABLE StudentDetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    Qualification VARCHAR(50),
    MobileNo BIGINT,
    Mail_id VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1)
);

INSERT INTO StudentDetails (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location, Gender) VALUES
(1, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
(2, 'Kumar', 20, 'BSC', 8904567342, 'Kumar@gmail.com', 'Madurai', 'M'),
(3, 'Selvi', 22, 'B.Tech', 7890125648, 'selvi@gmail.com', 'Selam', 'F'),
(4, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'),
(5, 'Sai Saran', 21, 'B.A', 7890345678, 'saran@gmail.com', 'Madurai', 'F'),
(6, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M');

SELECT Gender, COUNT(*) AS Total_Count
FROM StudentDetails
GROUP BY Gender;

--QUESTION=> Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
CREATE TABLE customer1(
    ID INT PRIMARY KEY,
    NAME VARCHAR(255),
    AGE INT,
    ADDRESS VARCHAR(255),
    SALARY DECIMAL(10, 2)
);
 
 

INSERT INTO customer1(ID, NAME, AGE, ADDRESS, SALARY) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 18.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);
 
SELECT NAME
FROM customer
WHERE ADDRESS LIKE '%o%';
 
 

 
 