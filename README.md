# ManagementTask
PruebaTecnica

Para ejecutar este proyecto tienen que crear o ejecutar el siguiente script

create database Task
use Task

CREATE TABLE TblUser (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    FullName NVARCHAR(MAX) NOT NULL,
    Document NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL,
    IsActive BIT NOT NULL
);

CREATE TABLE TblTasks (
    TaskId UNIQUEIDENTIFIER PRIMARY KEY,
    TaskName NVARCHAR(MAX) NOT NULL,
    TaskDescription NVARCHAR(MAX) NOT NULL,
    TaskDate DATETIME NOT NULL,
    IsComplete BIT NOT NULL
);

CREATE TABLE UserTasks (
    UserTaskId INT PRIMARY KEY IDENTITY,
    UserId UNIQUEIDENTIFIER,
    TaskId UNIQUEIDENTIFIER,
    FOREIGN KEY (UserId) REFERENCES TblUser(UserId),
    FOREIGN KEY (TaskId) REFERENCES TblTasks(TaskId)
);

Despues de esto hay que cambiar la cadena de conexion en los program para que se ajuste con el servidor SQL configurado
