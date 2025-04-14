CREATE TABLE CustomerRegistrations (
    CustomerId INT PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PolicyReference NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NULL,
    Email NVARCHAR(100) NULL
);