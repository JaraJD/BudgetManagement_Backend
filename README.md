# Budget Management

Gestor de presupuesto personal implementando Microservices, Clean Architecture y patrones de diseño con MediatR y CQRS

# Estructura del proyecto, Distribución de capas y Patrones de diseño (Clean Architecture, CQRS, DDD)

Proyecto Basado en:

![Captura de pantalla 2023-04-09 131159](https://user-images.githubusercontent.com/93845990/232625377-59b51fd3-3518-4c9e-85b4-1e0bc6e03191.png)

![Captura de pantalla 2023-04-16 103812](https://user-images.githubusercontent.com/93845990/232625389-c467d1c6-1b61-4c28-ae7f-253a8ee2aa72.png)


# Diagrama UML

![Diagram personal budget management](https://user-images.githubusercontent.com/93845990/232625905-3ff0be43-4e65-4d59-8bc5-5951b9b43bfa.jpg)


# Script SQL

Microservicio Activity Log:

```
CREATE DATABASE Activity_Log;
GO

-- Seleccionar la base de datos
USE Activity_Log;
GO

-- Crear tabla Budget
CREATE TABLE Budget (
    id INT PRIMARY KEY IDENTITY(1,1),
    isDeleted BIT NOT NULL DEFAULT 0,
    idUser NVARCHAR(MAX),
    name NVARCHAR(MAX),
    targetMonth DATETIME,
    balance DECIMAL,
    monthlyTotal DECIMAL,
    State NVARCHAR(MAX)
);
GO

-- Crear tabla Category
CREATE TABLE Category (
    id INT PRIMARY KEY IDENTITY(1,1),
    isDeleted BIT NOT NULL DEFAULT 0,
    name NVARCHAR(MAX),
    priority NVARCHAR(MAX)
);
GO

-- Crear tabla BudgetExpense
CREATE TABLE Budget_Expense (
    id INT PRIMARY KEY IDENTITY(1,1),
    isDeleted BIT NOT NULL DEFAULT 0,
    amount DECIMAL,
    description NVARCHAR(MAX),
    budgetId INT,
    categoryId INT,
    FOREIGN KEY (budgetId) REFERENCES Budget(id),
    FOREIGN KEY (categoryId) REFERENCES Category(id)
);
GO

-- Crear tabla Transaction
CREATE TABLE [Transaction] (
    id INT PRIMARY KEY IDENTITY(1,1),
    isDeleted BIT NOT NULL DEFAULT 0,
    date DATETIME,
    type NVARCHAR(MAX),
    amount DECIMAL,
    description NVARCHAR(MAX),
    userId NVARCHAR(MAX),
    categoryId INT,
    budgetId INT,
    FOREIGN KEY (categoryId) REFERENCES Category(id),
    FOREIGN KEY (budgetId) REFERENCES Budget(id)
);
GO
```

Microservicio Financial Goal:

```
CREATE DATABASE Financial_Goal;
GO

-- Seleccionar la base de datos
USE Financial_Goal;
GO

CREATE TABLE Target_Saving (
  id INT PRIMARY KEY IDENTITY(1,1),
  idUser VARCHAR(50),
  startDate DATE,
  endDate DATE,
  targetAmount DECIMAL(12,2),
  stateSaving VARCHAR(50),
  IsDeleted BIT
);
GO
```

# Colecciones MongoDB

User Collection:

```
{
  "userId": "string",
  "name": "string",
  "email": "string",
  "fireBaseId": "string",
  "isDeleted": true
}
```
Balance Collection:

```
{
    "balanceId": "string",
    "userId": "string",
    "name": "string",
    "amount": 0,
    "isDeleted": true
  }
```
