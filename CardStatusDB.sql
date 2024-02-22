CREATE DATABASE cardStatus;

USE cardStatus;

-- Tabla de usuarios
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
);

-- Tabla de tarjetas de cr�dito
CREATE TABLE CreditCards (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Number NVARCHAR(16) NOT NULL,
    Limit DECIMAL(18,2) NOT NULL,
    UserId INT FOREIGN KEY REFERENCES Users(Id)
);

-- Tabla de transacciones
CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Date DATETIME NOT NULL,
    Description NVARCHAR(100) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    TransactionTypeId INT FOREIGN KEY REFERENCES TransactionTypes(Id),
    CreditCardId INT FOREIGN KEY REFERENCES CreditCards(Id),
);

-- Tabla de tipos de transacci�n
CREATE TABLE TransactionTypes (
    TransactionTypeId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL
);

-- Datos de usuarios
INSERT INTO Users (Name, LastName) VALUES ('Juan', 'Pérez');
INSERT INTO Users (Name, LastName) VALUES ('María', 'García');
INSERT INTO Users (Name, LastName) VALUES ('Carlos', 'López');

-- Datos de tarjetas de crédito
INSERT INTO CreditCards (Number, Limit, UserId) VALUES ('1111222233334444', 5000.00, 1);
INSERT INTO CreditCards (Number, Limit, UserId) VALUES ('5555666677778888', 8000.00, 2);
INSERT INTO CreditCards (Number, Limit, UserId) VALUES ('9999000011112222', 10000.00, 3);

-- Datos de tipos de transacción
INSERT INTO TransactionTypes (Name) VALUES ('Compra');
INSERT INTO TransactionTypes (Name) VALUES ('Pago');

-- Datos de transacciones
INSERT INTO Transactions (Date, Description, Amount, TransactionTypeId, CreditCardId) VALUES ('2023-12-15', 'Compra de alimentos', 100.00, 1, 1);
INSERT INTO Transactions (Date, Description, Amount, TransactionTypeId, CreditCardId) VALUES ('2023-12-20', 'Compra de ropa', 200.00, 1, 2);
INSERT INTO Transactions (Date, Description, Amount, TransactionTypeId, CreditCardId) VALUES ('2023-12-25', 'Pago de TC', 50.00, 2, 3);

