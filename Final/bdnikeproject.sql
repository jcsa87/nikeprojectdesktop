CREATE DATABASE DBnikeproject;
USE DBnikeproject;
GO

-------------------------------------------------------
-- TABLA: USUARIO
-------------------------------------------------------
CREATE TABLE USUARIO (
    IdUsuario INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Documento VARCHAR(50) NOT NULL UNIQUE,
    Clave VARCHAR(100) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Supervisor', 'Vendedor', 'Administrador')),
    Estado BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_USUARIO PRIMARY KEY CLUSTERED (IdUsuario ASC)
);
GO

-------------------------------------------------------
-- TABLA: CLIENTE
-------------------------------------------------------
CREATE TABLE CLIENTE (
    IdCliente INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Documento VARCHAR(20) NOT NULL UNIQUE,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL,
    Estado BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_CLIENTE PRIMARY KEY CLUSTERED (IdCliente ASC)
);
GO

-------------------------------------------------------
-- TABLA: CATEGORIA
-------------------------------------------------------
CREATE TABLE CATEGORIA (
    IdCategoria INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    CONSTRAINT PK_CATEGORIA PRIMARY KEY CLUSTERED (IdCategoria ASC)
);
GO

-------------------------------------------------------
-- TABLA: PRODUCTO
-------------------------------------------------------
CREATE TABLE PRODUCTO (
    IdProducto INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(20) NOT NULL UNIQUE,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(200) NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    ImagenRuta VARCHAR(255) NULL,
    IdCategoria INT NULL,
    Stock INT NOT NULL DEFAULT 0,
    PrecioCompra DECIMAL(10,2) NOT NULL DEFAULT 0,
    CONSTRAINT PK_PRODUCTO PRIMARY KEY CLUSTERED (IdProducto ASC),
    CONSTRAINT FK_PRODUCTO_CATEGORIA FOREIGN KEY (IdCategoria) REFERENCES CATEGORIA(IdCategoria)
);
GO

-------------------------------------------------------
-- TABLA: VENTA
-------------------------------------------------------
CREATE TABLE VENTA (
    IdVenta INT IDENTITY(1,1) NOT NULL,
    IdCliente INT NOT NULL,
    IdUsuario INT NOT NULL,
    NumeroDocumento VARCHAR(20) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    MontoTotal DECIMAL(10,2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_VENTA PRIMARY KEY CLUSTERED (IdVenta ASC),
    CONSTRAINT FK_VENTA_CLIENTE FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente),
    CONSTRAINT FK_VENTA_USUARIO FOREIGN KEY (IdUsuario) REFERENCES USUARIO(IdUsuario)
);
GO

-------------------------------------------------------
-- TABLA: DETALLE_VENTA
-------------------------------------------------------
CREATE TABLE DETALLE_VENTA (
    IdDetalle INT IDENTITY(1,1) NOT NULL,
    IdVenta INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(10,2) NOT NULL CHECK (PrecioUnitario >= 0),
    SubTotal DECIMAL(10,2) NOT NULL,
    CONSTRAINT PK_DETALLEVENTA PRIMARY KEY CLUSTERED (IdDetalle ASC),
    CONSTRAINT FK_DETALLEVENTA_VENTA FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta),
    CONSTRAINT FK_DETALLEVENTA_PRODUCTO FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto)
);
GO

-------------------------------------------------------
-- CHECKS ADICIONALES
-------------------------------------------------------
ALTER TABLE DETALLE_VENTA WITH CHECK ADD CHECK ((Cantidad > 0));
ALTER TABLE DETALLE_VENTA WITH CHECK ADD CHECK ((PrecioUnitario >= 0));
GO


/* ============================================================
   INSERCIONES DE DATOS INICIALES
   ============================================================ */

-------------------------------------------------------
-- USUARIOS
-- Nota: El usuario de tipo Administrador, Supervisor, Vendedor tienen contraseña y documento 1,2,3 respectivamente.
-------------------------------------------------------
INSERT INTO USUARIO (Nombre, Apellido, Documento, Clave, Rol, Estado, FechaCreacion)
VALUES
('Admin', 'Principal', '1', '6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 'Administrador', 1, GETDATE()),
('Sofia', 'Lopez', '2', 'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35', 'Supervisor', 1, GETDATE()),
('Carlos', 'Ramirez', '3', '4e07408562bedb8b60ce05c1decfe3ad16b72230967de01f640b7e4729b49fce', 'Vendedor', 1, GETDATE());
GO

-------------------------------------------------------
-- CATEGORÍAS
-------------------------------------------------------
INSERT INTO CATEGORIA (Descripcion)
VALUES
('Running'),
('Training'),
('Urbanas'),
('Deportivas');
GO

DECLARE @catRunning INT = (SELECT IdCategoria FROM CATEGORIA WHERE Descripcion='Running');
DECLARE @catTraining INT = (SELECT IdCategoria FROM CATEGORIA WHERE Descripcion='Training');
DECLARE @catUrbanas INT = (SELECT IdCategoria FROM CATEGORIA WHERE Descripcion='Urbanas');
DECLARE @catDeportivas INT = (SELECT IdCategoria FROM CATEGORIA WHERE Descripcion='Deportivas');

-------------------------------------------------------
-- PRODUCTOS (solo zapatillas)
-------------------------------------------------------
INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado, ImagenRuta)
VALUES
('Z001', N'Nike Air Zoom Pegasus 40', N'Zapatilla para running con amortiguación reactiva.', @catRunning, 25, 90000.00, 135000.00, 1, NULL),
('Z002', N'Nike Metcon 9', N'Zapatilla de entrenamiento con suela estable.', @catTraining, 20, 85000.00, 120000.00, 1, NULL),
('Z003', N'Nike Air Force 1', N'Zapatilla urbana clásica de cuero.', @catUrbanas, 30, 70000.00, 110000.00, 1, NULL),
('Z004', N'Nike Zoom Freak 5', N'Zapatilla de básquet de alto rendimiento.', @catDeportivas, 18, 95000.00, 140000.00, 1, NULL),
('Z005', N'Nike Revolution 7', N'Zapatilla liviana para correr todos los días.', @catRunning, 40, 65000.00, 98000.00, 1, NULL);
GO

DECLARE @pZ001 INT = (SELECT IdProducto FROM PRODUCTO WHERE Codigo='Z001');
DECLARE @pZ002 INT = (SELECT IdProducto FROM PRODUCTO WHERE Codigo='Z002');
DECLARE @pZ003 INT = (SELECT IdProducto FROM PRODUCTO WHERE Codigo='Z003');
DECLARE @pZ004 INT = (SELECT IdProducto FROM PRODUCTO WHERE Codigo='Z004');
DECLARE @pZ005 INT = (SELECT IdProducto FROM PRODUCTO WHERE Codigo='Z005');

-------------------------------------------------------
-- CLIENTES
-------------------------------------------------------
INSERT INTO CLIENTE (Nombre, Apellido, Documento, Correo, Telefono, Estado, FechaCreacion)
VALUES
(N'María', N'Gómez', '40000111', 'maria.gomez@example.com', '3794111111', 1, GETDATE()),
(N'Juan', N'Pérez', '40000222', 'juan.perez@example.com', '3794222222', 1, GETDATE()),
(N'Lucía', N'Fernández', '40000333', 'lucia.fernandez@example.com', '3794333333', 1, GETDATE());
GO

DECLARE @idAdmin INT = (SELECT IdUsuario FROM USUARIO WHERE Documento='1');
DECLARE @idSup INT = (SELECT IdUsuario FROM USUARIO WHERE Documento='2');
DECLARE @idVend INT = (SELECT IdUsuario FROM USUARIO WHERE Documento='3');

DECLARE @cliMaria INT = (SELECT IdCliente FROM CLIENTE WHERE Documento='40000111');
DECLARE @cliJuan INT = (SELECT IdCliente FROM CLIENTE WHERE Documento='40000222');
DECLARE @cliLucia INT = (SELECT IdCliente FROM CLIENTE WHERE Documento='40000333');

-------------------------------------------------------
-- VENTAS
-------------------------------------------------------
INSERT INTO VENTA (IdCliente, IdUsuario, NumeroDocumento, FechaRegistro, MontoTotal, Estado)
VALUES
(@cliMaria, @idVend, 'A0001', GETDATE(), 245000.00, 1),
(@cliJuan, @idVend, 'A0002', GETDATE(), 110000.00, 1),
(@cliLucia, @idSup,  'A0003', GETDATE(), 218000.00, 1);
GO

DECLARE @v1 INT = (SELECT IdVenta FROM VENTA WHERE NumeroDocumento='A0001');
DECLARE @v2 INT = (SELECT IdVenta FROM VENTA WHERE NumeroDocumento='A0002');
DECLARE @v3 INT = (SELECT IdVenta FROM VENTA WHERE NumeroDocumento='A0003');

-------------------------------------------------------
-- DETALLE_VENTA
-------------------------------------------------------
INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, Cantidad, PrecioUnitario, SubTotal)
VALUES
(@v1, @pZ001, 1, 135000.00, 135000.00),
(@v1, @pZ003, 1, 110000.00, 110000.00),
(@v2, @pZ003, 1, 110000.00, 110000.00),
(@v3, @pZ002, 1, 120000.00, 120000.00),
(@v3, @pZ005, 1,  98000.00,  98000.00);
GO
