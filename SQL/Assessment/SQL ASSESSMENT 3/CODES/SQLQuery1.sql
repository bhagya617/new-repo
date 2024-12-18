use tempdb

CREATE TABLE ProductsDetails  
(  
    ProductId INT IDENTITY(1,1) PRIMARY KEY,  
    ProductName VARCHAR(100) NOT NULL,  
    Price FLOAT NOT NULL,  
    DiscountedPrice FLOAT NOT NULL  
);
CREATE PROCEDURE ProdDetailsInsertion  
    @ProductName NVARCHAR(25),  
    @Price INT,  
    @ProductID INT OUTPUT  
AS  
BEGIN  
    -- Generate ProductId manually
    DECLARE @NextProductId INT;
    SET @NextProductId = ISNULL((SELECT MAX(ProductId) FROM ProductsDetails), 0) + 1;
 
    -- Insert record into ProductsDetails
    INSERT INTO ProductsDetails (ProductName, Price, ProductId)  
    VALUES (@ProductName, @Price, @NextProductId);  
 
    -- Set the generated ProductId
    SET @ProductID = @NextProductId;  
END;