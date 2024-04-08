CREATE DATABASE ClothingStoreDB
GO
USE ClothingStoreDB
GO

-- Categories Table
CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(75) NOT NULL
);
GO

-- Sizes Table
CREATE TABLE Size (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SizeDescription VARCHAR(50) NOT NULL
);
GO

-- Products Table
CREATE TABLE Product (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(150) NOT NULL,
    Description VARCHAR(250),
    Price DECIMAL(10, 2) NOT NULL,
    CategoryId INT,
    SizeId INT,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id),
    FOREIGN KEY (SizeId) REFERENCES Size(Id)
);
GO

-- Customers Table
CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerFirstName VARCHAR(75) NOT NULL,
    CustomerLastName VARCHAR(75) NOT NULL,
    Email VARCHAR(75) UNIQUE NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(200)
);
GO

-- Employees Table
CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeFirstName VARCHAR(75) NOT NULL,
    EmployeeLastName VARCHAR(75) NOT NULL,
    Email VARCHAR(75) UNIQUE NOT NULL,
    Phone VARCHAR(20),
    Address TEXT,
    Salary DECIMAL(10, 2) NOT NULL
);
GO

-- Sales Table
CREATE TABLE Sale (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT,
    EmployeeId INT,
	ProductId INT,
	Quantity INT,
	UnitPrice DECIMAL(10,2),
    SaleDate DATETIME NOT NULL,
    Total AS (Quantity * UnitPrice),
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
	FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
GO

-- procesos almaceados

-- ============= CATEGORY =============
-- Insertar una nueva categor�a
CREATE PROCEDURE spCategory_Insert
(
    @CategoryName VARCHAR(75)
)
AS
BEGIN
    INSERT INTO Category (CategoryName)
    VALUES (@CategoryName)
END;
GO

-- Obtener todas las categor�as
CREATE PROCEDURE spCategory_GetALL
AS
BEGIN
    SELECT Id,CategoryName FROM Category
END;
GO

-- Obtener todas las categor�as
CREATE PROCEDURE spCategory_GetById
(
	@Id INT
)
AS
BEGIN
    SELECT Id,CategoryName FROM Category WHERE Id=@Id
END;
GO

-- Actualizar una categor�a
CREATE PROCEDURE spCategory_Update
    @Id INT,
    @CategoryName VARCHAR(75)
AS
BEGIN
    UPDATE Category
    SET CategoryName = @CategoryName
    WHERE Id = @Id
END;
GO

-- Eliminar una categor�a
CREATE PROCEDURE spCategory_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Category
    WHERE Id = @Id
END;
GO

-- ============ SIZE ============
-- Insertar un nuevo tama�o
CREATE PROCEDURE spSize_Insert
(
    @SizeDescription VARCHAR(50)
)
AS
BEGIN
    INSERT INTO Size (SizeDescription)
    VALUES (@SizeDescription)
END;
GO

-- Obtener todos los tama�os
CREATE PROCEDURE spSize_GetAll
AS
BEGIN
    SELECT Id,SizeDescription FROM Size
END;
GO

-- obtener por id
CREATE PROCEDURE spSize_GetById
(
    @Id INT
)
AS
BEGIN
    SELECT Id,SizeDescription FROM Size
    WHERE Id = @Id
END;
GO

-- Actualizar un tama�o
CREATE PROCEDURE spSize_Update
(
    @Id INT,
    @SizeDescription VARCHAR(50)
)
AS
BEGIN
    UPDATE Size
    SET SizeDescription = @SizeDescription
    WHERE Id = @Id
END;
GO

-- Eliminar un tama�o
CREATE PROCEDURE spSize_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Size
    WHERE Id = @Id
END;
GO

-- =============== PRODUCTS ==================
-- Insertar un nuevo producto
CREATE PROCEDURE spProduct_Insert
(
    @ProductName VARCHAR(150),
    @Description VARCHAR(250),
    @Price DECIMAL(10, 2),
    @CategoryId INT,
    @SizeId INT
)
AS
BEGIN
    INSERT INTO Product (ProductName, Description, Price, CategoryId, SizeId)
    VALUES (@ProductName, @Description, @Price, @CategoryId, @SizeId)
END;
GO

CREATE PROCEDURE spProduct_GetAll
AS
BEGIN
    SELECT A.Id,ProductName,Description,Price,CategoryName,SizeDescription 
	FROM Product AS A
	INNER JOIN Category AS B ON A.CategoryId=B.Id
	INNER JOIN Size AS C ON A.SizeId=C.Id
END;
GO

-- Obtener un producto por Id
CREATE PROCEDURE spProduct_GetById
(
    @Id INT
)
AS
BEGIN
    SELECT Id,ProductName,Description,Price,CategoryId,SizeId FROM Product
    WHERE Id = @Id
END;
GO

-- Actualizar un producto
CREATE PROCEDURE spProduct_Update
(
    @Id INT,
    @ProductName VARCHAR(150),
    @Description VARCHAR(250),
    @Price DECIMAL(10, 2),
    @CategoryId INT,
    @SizeId INT
)
AS
BEGIN
    UPDATE Product
    SET ProductName = @ProductName, Description = @Description, Price = @Price, CategoryId = @CategoryId, SizeId = @SizeId
    WHERE Id = @Id
END;
GO

-- Eliminar un producto
CREATE PROCEDURE spProduct_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Product
    WHERE Id = @Id
END;
GO

-- ========= CUSTOMERS ==============
-- Insertar un nuevo cliente
CREATE PROCEDURE spCustomer_Insert
(
    @CustomerFirstName VARCHAR(75),
    @CustomerLastName VARCHAR(75),
    @Email VARCHAR(75),
    @Phone VARCHAR(20),
    @Address VARCHAR(200)
)
AS
BEGIN
    INSERT INTO Customer (CustomerFirstName, CustomerLastName, Email, Phone, Address)
    VALUES (@CustomerFirstName, @CustomerLastName, @Email, @Phone, @Address)
END;
GO

-- Obtener todos los clientes
CREATE PROCEDURE spCustomer_GetAll
AS
BEGIN
    SELECT Id,CustomerFirstName,CustomerLastName,Email,Phone,Address FROM Customer
END;
GO

-- Obtener un cliente por id
CREATE PROCEDURE spCustumer_GetById
(
    @Id INT
)
AS
BEGIN
    SELECT Id,CustomerFirstName,CustomerLastName,Email,Phone,Address FROM Customer
    WHERE Id = @Id
END;
GO

-- Actualizar un cliente
CREATE PROCEDURE spCustomer_Update
(
    @Id INT,
    @CustomerFirstName VARCHAR(75),
    @CustomerLastName VARCHAR(75),
    @Email VARCHAR(75),
    @Phone VARCHAR(20),
    @Address VARCHAR(200)
)
AS
BEGIN
    UPDATE Customer
    SET CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, Email = @Email, Phone = @Phone, Address = @Address
    WHERE Id = @Id
END;
GO

-- Eliminar un cliente
CREATE PROCEDURE spCustomer_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Customer
    WHERE Id = @Id
END;
GO

-- ============ EMPLOYEE ===========
-- Insertar un nuevo empleado
CREATE PROCEDURE spEmployee_Insert
(
    @EmployeeFirstName VARCHAR(75),
    @EmployeeLastName VARCHAR(75),
    @Email VARCHAR(75),
    @Phone VARCHAR(20),
    @Address TEXT,
    @Salary DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO Employee (EmployeeFirstName, EmployeeLastName, Email, Phone, Address, Salary)
    VALUES (@EmployeeFirstName, @EmployeeLastName, @Email, @Phone, @Address, @Salary)
END;
GO

-- Obtener todos los empleados
CREATE PROCEDURE spEmployee_GetAll
AS
BEGIN
    SELECT Id,EmployeeFirstName,EmployeeLastName,Email,Phone,Address,Salary FROM Employee
END;
GO

-- Obtener un empleado por Id
CREATE PROCEDURE spEmployee_GetById
(
    @Id INT
)
AS
BEGIN
    SELECT Id,EmployeeFirstName,EmployeeLastName,Email,Phone,Address,Salary FROM Employee
    WHERE Id = @Id
END;
GO

-- Actualizar un empleado
CREATE PROCEDURE spEmployee_Update
(
    @Id INT,
    @EmployeeFirstName VARCHAR(75),
    @EmployeeLastName VARCHAR(75),
    @Email VARCHAR(75),
    @Phone VARCHAR(20),
    @Address TEXT,
    @Salary DECIMAL(10, 2)
)
AS
BEGIN
    UPDATE Employee
    SET EmployeeFirstName = @EmployeeFirstName, EmployeeLastName = @EmployeeLastName, Email = @Email, Phone = @Phone, Address = @Address, Salary = @Salary
    WHERE Id = @Id
END;
GO

-- Eliminar un empleado
CREATE PROCEDURE spEmployee_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Employee
    WHERE Id = @Id
END;
GO

-- ========== SALES ==============
-- Insertar una nueva venta
CREATE OR ALTER PROCEDURE spSale_Insert
(
    @CustomerId INT,
    @EmployeeId INT,
	@ProductId INT,
	@Quantity INT,
    @SaleDate DATE
)
AS
BEGIN
    DECLARE @UnitPrice DECIMAL(10,2);

    -- Obtener el precio del producto de la tabla Producto
    SELECT @UnitPrice = Price
    FROM Product
    WHERE Id = @ProductId;

    -- Insertar el registro en la tabla Sale
    INSERT INTO Sale (CustomerId, EmployeeId, ProductId, Quantity, UnitPrice, SaleDate)
    VALUES (@CustomerId, @EmployeeId, @ProductId, @Quantity, @UnitPrice, @SaleDate);
END;
GO

-- Obtener todas las ventas
CREATE OR ALTER PROCEDURE spSale_GetAll
AS
BEGIN
    SELECT A.Id,A.CustomerId, A.EmployeeId, A.ProductId,Quantity, UnitPrice,SaleDate,Total ,
	B.CustomerFirstName + ' ' + B.CustomerLastName AS CustomerName, C.EmployeeFirstName + ' ' + C.EmployeeLastName AS EmployeeName, D.ProductName
	FROM Sale AS A 
	INNER JOIN Customer AS B ON A.CustomerId=B.Id 
	INNER JOIN Employee AS C ON A.EmployeeId=C.Id
	INNER JOIN Product AS D ON A.ProductId=D.Id
END;
GO


-- obtener una venta por id
CREATE PROCEDURE spSale_GetById
(
    @Id INT
)
AS
BEGIN
    SELECT Id,CustomerId,EmployeeId,ProductId,Quantity,UnitPrice,SaleDate,Total FROM Sale
    WHERE Id = @Id
END;
GO


-- Actualizar una venta
CREATE OR ALTER PROCEDURE spSale_Update
(
    @Id INT,
    @CustomerId INT,
    @EmployeeId INT,
	@ProductId INT,
	@Quantity INT,
    @SaleDate DATE
)
AS
BEGIN
	DECLARE @UnitPrice DECIMAL(10,2);

    -- Obtener el precio del producto de la tabla Producto
    SELECT @UnitPrice = Price FROM Product WHERE Id = @ProductId;

    UPDATE Sale
    SET CustomerId = @CustomerId, EmployeeId = @EmployeeId, ProductId=@ProductId,
	Quantity=@Quantity, UnitPrice=@UnitPrice, SaleDate = @SaleDate
    WHERE Id = @Id
END;
GO

-- Eliminar una venta
CREATE PROCEDURE spSale_Delete
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Sale
    WHERE Id = @Id
END;
GO
