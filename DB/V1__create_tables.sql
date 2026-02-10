/* =========================================================
   CRIAÇÃO DO BANCO
========================================================= */
IF DB_ID('FuelLocalDb') IS NULL
BEGIN
    CREATE DATABASE FuelLocalDb;
END
GO

USE FuelLocalDb;
GO

/* =========================================================
   TABELA: Bombas
========================================================= */
IF OBJECT_ID('Bombas', 'U') IS NOT NULL
    DROP TABLE Bombas;
GO

CREATE TABLE Bombas (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Numero INT NOT NULL UNIQUE,
    EstoqueLitros DECIMAL(10,2) NOT NULL CHECK (EstoqueLitros >= 0)
);
GO

/* =========================================================
   TABELA: Consumos
========================================================= */
IF OBJECT_ID('Consumos', 'U') IS NOT NULL
    DROP TABLE Consumos;
GO

CREATE TABLE Consumos (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    BombaId UNIQUEIDENTIFIER NOT NULL,
    Litros DECIMAL(10,2) NOT NULL CHECK (Litros > 0),
    DataConsumo DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    Sincronizado BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Consumos_Bombas
        FOREIGN KEY (BombaId) REFERENCES Bombas(Id)
);
GO

CREATE INDEX IDX_Consumos_Sincronizado
    ON Consumos (Sincronizado);
GO

/* =========================================================
   TABELA: DeadLetter (falhas de sincronização)
========================================================= */
IF OBJECT_ID('DeadLetter', 'U') IS NOT NULL
    DROP TABLE DeadLetter;
GO

CREATE TABLE DeadLetter (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    ConsumoId UNIQUEIDENTIFIER NOT NULL,
    Erro NVARCHAR(1000) NOT NULL,
    DataErro DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

CREATE INDEX IDX_DeadLetter_DataErro
    ON DeadLetter (DataErro);
GO

/* =========================================================
   SEED INICIAL
========================================================= */
INSERT INTO Bombas (Id, Numero, EstoqueLitros)
VALUES
 (NEWID(), 1, 1000.00),
 (NEWID(), 2, 850.00),
 (NEWID(), 3, 1200.00);
GO
