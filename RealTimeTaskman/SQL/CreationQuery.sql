﻿CREATE TABLE Tasks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Description NVARCHAR(200) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);