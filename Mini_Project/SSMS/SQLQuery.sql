CREATE DATABASE RailwayReservationSystem;
USE RailwayReservationSystem;
 
-- Train Table
CREATE TABLE Train (
    TrainId INT PRIMARY KEY IDENTITY(1,1),
    TrainName VARCHAR(100),
    FromLocation VARCHAR(100),
    ToLocation VARCHAR(100),
    FirstClassBerths INT,
    SecondClassBerths INT,
    SleeperClassBerths INT,
    IsStalled BIT
);

-- Users Table
CREATE TABLE Users(
    UserId INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);
 
 
-- Admin Table (Password Protected - Authorized Access ONLY)

CREATE TABLE Admin (
    AdminId INT PRIMARY KEY IDENTITY(1,1),
    AdminName VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);
--Authentication (Restricted Access)
 insert into Admin (adminname,password)values('bhagya','brk123');
 
-- Alter Users Table to Add Email and Phone Number
ALTER TABLE Users
ADD Email VARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber VARCHAR(15) NULL;
 
 
---
 
--SQL Stored Procedures
 
CREATE PROCEDURE AddTrain
    @TrainName VARCHAR(100),
    @FromLocation VARCHAR(100),
    @ToLocation VARCHAR(100),
    @FirstClassBerths INT,
    @SecondClassBerths INT,
    @SleeperClassBerths INT,
    @IsStalled BIT
AS
BEGIN
    INSERT INTO Train (TrainName, FromLocation, ToLocation, FirstClassBerths, SecondClassBerths, SleeperClassBerths, IsStalled)
    VALUES (@TrainName, @FromLocation, @ToLocation, @FirstClassBerths, @SecondClassBerths, @SleeperClassBerths, @IsStalled);
END;
  

CREATE PROCEDURE UpdateTrain
    @TrainId INT,
    @TrainName VARCHAR(100),
    @FromLocation VARCHAR(100),
    @ToLocation VARCHAR(100),
    @FirstClassBerths INT,
    @SecondClassBerths INT,
    @SleeperClassBerths INT,
    @IsStalled BIT
AS
BEGIN
    UPDATE Train
    SET
        TrainName = @TrainName,
        FromLocation = @FromLocation,
        ToLocation = @ToLocation,
        FirstClassBerths = @FirstClassBerths,
        SecondClassBerths = @SecondClassBerths,
        SleeperClassBerths = @SleeperClassBerths,
        IsStalled = @IsStalled
    WHERE TrainId = @TrainId;
END;
  

 
 
CREATE PROCEDURE DeleteTrain --Permanently Delete in case it's been Discontinued permanently............
    @TrainId INT
AS
BEGIN
    DELETE FROM Train WHERE TrainId = @TrainId;
END;
 

CREATE PROCEDURE GetActiveTrains
AS
BEGIN
    SELECT
        TrainId,
        TrainName,
        FromLocation,
        ToLocation,
        FirstClassBerths,
        SecondClassBerths,
        SleeperClassBerths,
        IsStalled
    FROM Train
    WHERE IsStalled = 0;
END;

CREATE PROCEDURE GetStalledTrains
AS
BEGIN
    SELECT
        TrainId,
        TrainName,
        FromLocation,
        ToLocation,
        FirstClassBerths,
        SecondClassBerths,
        SleeperClassBerths,
        IsStalled
    FROM Train
    WHERE IsStalled = 1;
END;
 
--CREATE PROCEDURE AddBooking
--    @UserId INT,
--    @TrainId INT,
--    @BerthClass VARCHAR(10)
--AS
--BEGIN
--    INSERT INTO Booking (UserId, TrainId, BerthClass)
--    VALUES (@UserId, @TrainId, @BerthClass);
--END;
 

CREATE PROCEDURE CancelTrain
    @TrainID INT,
    @Class NVARCHAR(20),
    @TicketsToCancel INT
AS
BEGIN
    DECLARE @OriginalBookedTickets INT;
    -- Check if there are enough tickets for the specific class and train
    SELECT @OriginalBookedTickets = AvailableTickets
    FROM Tickets
    WHERE TrainID = @TrainID AND Class = @Class;
    IF @OriginalBookedTickets >= @TicketsToCancel
    BEGIN
        -- Update available tickets for the specific train and class
        UPDATE Tickets
        SET AvailableTickets = AvailableTickets - @TicketsToCancel
        WHERE TrainID = @TrainID AND Class = @Class;
    END
    ELSE
    BEGIN
        PRINT 'Not enough tickets to cancel or invalid ticket selection.';
    END
END;
--CREATE PROCEDURE CancelTrain
--    @TrainID INT,
--    @Class VARCHAR(20),
--    @TicketsToCancel INT,
--    @UserId INT
--AS
--BEGIN
--    DECLARE @OriginalBookedTickets INT;
 
--    -- Check if the user has a booking for the specific train and class
--    IF NOT EXISTS (
--        SELECT 1 FROM AddBooking
--        WHERE UserId = @UserId AND TrainId = @TrainID AND BerthClass = @Class
--    )
--    BEGIN
--        PRINT 'No booking found for this user and train class combination.';
--        RETURN
--    END
 
--    -- Check current available tickets for the given TrainID and Class
--    SELECT @OriginalBookedTickets = AvailableTickets
--    FROM Tickets
--    WHERE TrainID = @TrainID AND Class = @Class;
 
--    -- If requested tickets to cancel are greater than available tickets, exit
--    IF @TicketsToCancel > @OriginalBookedTickets
--    BEGIN
--        PRINT 'Not enough tickets to cancel.'
--        RETURN
--    END
 
--    -- Update available tickets
--    UPDATE Tickets
--    SET AvailableTickets = AvailableTickets - @TicketsToCancel
--    WHERE TrainID = @TrainID AND Class = @Class;
 
--    PRINT 'Cancellation successful! Refund will be processed.'
--END



---Soft delete (Trains which are just Temporarily Deactivated or will be Resumed after Maintenence/Operational issues are solved)......

CREATE PROCEDURE MarkTrainDeleted 
    @TrainId INT
AS
BEGIN
    UPDATE Train
    SET IsStalled = 1
    WHERE TrainId = @TrainId AND IsStalled = 0; -- Only mark active trains as deleted
END;

CREATE PROCEDURE RestoreTrains
    @TrainId INT
AS
BEGIN
    UPDATE Train
    SET IsStalled = 0
    WHERE TrainId = @TrainId AND IsStalled = 1; -- Only restore stalled trains
END;




   
--Alter PROCEDURE AddBooking
--    @UserId INT,
--    @TrainId INT,
--    @BerthClass VARCHAR(10),
--    @BookingId INT OUTPUT
--AS
--BEGIN
--    -- Insert the booking
--    INSERT INTO Booking (UserId, TrainId, BerthClass)
--    VALUES (@UserId, @TrainId, @BerthClass);
    
--    -- Retrieve the latest BookingId manually
--    DECLARE @MaxBookingId INT = (
--        SELECT MAX(BookingId)
--        FROM Booking
--        WHERE UserId = @UserId
--          AND TrainId = @TrainId
--          AND BerthClass = @BerthClass
--    );
 
--    -- Check if a BookingId was found
--    IF @MaxBookingId IS NOT NULL
--    BEGIN
--        SET @BookingId = @MaxBookingId;
--    END
--    ELSE
--    BEGIN
--        SET @BookingId = 0; -- Default value if no BookingId found
--    END
 
--    SELECT @BookingId;
--END;


 CREATE TABLE Tickets (
    TrainId INT,
    Class NVARCHAR(50),
    AvailableTickets INT,
    PRIMARY KEY (TrainId, Class)
);



CREATE TABLE TicketPrices (
    Class VARCHAR(50) PRIMARY KEY,
    Price INT
);
 
-- Insert initial ticket prices
INSERT INTO TicketPrices (Class, Price) VALUES
('First', 1000),
('Second', 700),
('Sleeper', 300);


 select * from Train
 select * from dbo.Admin

  
SELECT * FROM Users;
SELECT * FROM Train;



