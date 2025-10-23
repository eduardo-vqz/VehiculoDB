-- =============================================
-- CREACIÓN DE BASE DE DATOS
-- =============================================
CREATE DATABASE VehiculosDB;
GO

USE VehiculosDB;
GO

-- =============================================
-- TABLA: Marcas
-- =============================================
CREATE TABLE Marcas (
    IdMarca INT PRIMARY KEY IDENTITY(1,1),
    NombreMarca NVARCHAR(100) NOT NULL
);

-- =============================================
-- TABLA: Propietarios
-- =============================================
CREATE TABLE Propietarios (
    IdPropietario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    DUI VARCHAR(10) UNIQUE NOT NULL,
    Telefono VARCHAR(15),
    Direccion NVARCHAR(200)
);

-- =============================================
-- TABLA: TiposCarro
-- =============================================
CREATE TABLE TiposCarro (
    IdTipoCarro INT PRIMARY KEY IDENTITY(1,1),
    NombreTipo NVARCHAR(50) NOT NULL UNIQUE
);

-- =============================================
-- TABLA: Vehiculos
-- =============================================
CREATE TABLE Vehiculos (
    IdVehiculo INT PRIMARY KEY IDENTITY(1,1),
    Placa VARCHAR(10) UNIQUE NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    Anio INT CHECK (Anio >= 1900 AND Anio <= YEAR(GETDATE())),
    Color NVARCHAR(50),
    IdMarca INT NOT NULL,
    IdPropietario INT NOT NULL,
    IdTipoCarro INT NOT NULL,
    FOREIGN KEY (IdMarca) REFERENCES Marcas(IdMarca),
    FOREIGN KEY (IdPropietario) REFERENCES Propietarios(IdPropietario),
    FOREIGN KEY (IdTipoCarro) REFERENCES TiposCarro(IdTipoCarro)
);

-- =============================================
-- TABLA: TiposMantenimiento
-- =============================================
CREATE TABLE TiposMantenimiento (
    IdTipoMantenimiento INT PRIMARY KEY IDENTITY(1,1),
    NombreTipo NVARCHAR(100) NOT NULL UNIQUE
);

-- =============================================
-- TABLA: Mantenimientos
-- =============================================
CREATE TABLE Mantenimientos (
    IdMantenimiento INT PRIMARY KEY IDENTITY(1,1),
    IdVehiculo INT NOT NULL,
    Fecha DATE NOT NULL,
    Costo DECIMAL(10,2) NOT NULL CHECK (Costo >= 0),
    Observaciones NVARCHAR(200),
    IdTipoMantenimiento INT NOT NULL,
    FOREIGN KEY (IdVehiculo) REFERENCES Vehiculos(IdVehiculo),
    FOREIGN KEY (IdTipoMantenimiento) REFERENCES TiposMantenimiento(IdTipoMantenimiento)
);

-- Marcas
INSERT INTO Marcas (NombreMarca) VALUES 
('Toyota'), 
('Honda'), 
('Nissan'), 
('Ford');

-- Tipos de carro
INSERT INTO TiposCarro (NombreTipo) VALUES 
('Sedán'), 
('Pick Up'), 
('Camioneta');

-- Tipos de mantenimiento
INSERT INTO TiposMantenimiento (NombreTipo) VALUES 
('Cambio de aceite'), 
('Revisión de frenos'), 
('Cambio de llantas'), 
('Alineación y balanceo');

-- Propietarios
INSERT INTO Propietarios (Nombre, Apellido, DUI, Telefono, Direccion)
VALUES 
('Carlos', 'Ramírez', '01234567-8', '7777-8888', 'San Salvador'),
('Ana', 'López', '12345678-9', '6666-7777', 'Santa Ana');

-- Vehículos
INSERT INTO Vehiculos (Placa, Modelo, Anio, Color, IdMarca, IdPropietario, IdTipoCarro)
VALUES 
('P123-456', 'Corolla', 2020, 'Blanco', 1, 1, 1), -- Sedán
('P789-101', 'Civic', 2019, 'Negro', 2, 2, 1),   -- Sedán
('P456-222', 'Hilux', 2022, 'Gris', 1, 1, 2);   -- Pick Up

-- Mantenimientos
INSERT INTO Mantenimientos (IdVehiculo, Fecha, Costo, Observaciones, IdTipoMantenimiento)
VALUES 
(1, '2025-01-15', 45.50, 'Se cambió aceite sintético', 1), -- Cambio de aceite
(2, '2025-02-10', 320.00, 'Se cambiaron las 4 llantas', 3), -- Cambio de llantas
(3, '2025-03-05', 60.00, 'Revisión preventiva de frenos', 2); -- Revisión de frenos

