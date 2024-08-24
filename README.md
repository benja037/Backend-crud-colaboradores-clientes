# RRHH API Backend

## Descripción

Este proyecto es un backend para una aplicación de gestión de recursos humanos, desarrollado con ASP.NET Core y Entity Framework Core. Proporciona operaciones CRUD para gestionar las entidades `Cliente` y `Colaborador` utilizando SQL Server como base de datos.

## Requisitos Previos

Antes de ejecutar este proyecto, asegúrate de tener instalados los siguientes componentes:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) (necesario para ejecutar aplicaciones ASP.NET Core)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

## Configuración del Proyecto

### 1. Clonar el Repositorio

Clona este repositorio en tu máquina local.


### 2. Configurar Bases de Datos
- Crear la Base de Datos:
CREATE DATABASE RRHHDB;
GO

USE RRHHDB;
GO

CREATE TABLE Colaborador (
    ColaboradorId INT PRIMARY KEY IDENTITY(1,1),
    Rut NVARCHAR(12) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Cargo NVARCHAR(100),
    
);

CREATE TABLE Cliente (
    ClienteId INT PRIMARY KEY IDENTITY(1,1),
    Rut NVARCHAR(12) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Fono NVARCHAR(20),
    Direccion NVARCHAR(200),
    Email NVARCHAR(100),
    FechaIngreso DATE,
    ColaboradorId INT,
    FOREIGN KEY (ColaboradorId) REFERENCES Colaborador(ColaboradorId)
);


- Configurar la Cadena de Conexión:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=RRHHDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

### 3. Comandos para configurar proyecto

- Agregar Entity Framework Core para SQL Server:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

- Agregar Entity Framework Core Tools:
dotnet add package Microsoft.EntityFrameworkCore.Tools

- Agregar Swagger para la documentación de la API:
dotnet add package Swashbuckle.AspNetCore

- Configurar el certificado HTTPS de desarrollo:
dotnet dev-certs https --trust



