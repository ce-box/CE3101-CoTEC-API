USE COTEC_DB;
GO

-- Insert Admins
INSERT INTO Admins
(
    Username,
    [Password],
    [Name],
    LastName,
    CountryCode )
VALUES
    ('estalvgs','admin','Esteban','Alvarado','CRI'),
    ('bbrenes','admin','Bertha','Brenes','CRI'),
    ('kstro','admin','Olman','Castro','CRI'),
    ('mendezamuel','admin','Randall','Mendez','CRI');


-- Insert Employees
INSERT INTO HospitalEmployees
(
    Username,
    [Password],
    [Name],
    LastName,
    Hospital_Id )
VALUES
    ('jaime.altozano','passme','Jaime','Altozano','1'),
    ('ester.rojas','passme','Ester','Rojas','1'),
    ('juan.ilama','passme','Juan','Ilama','1'),
    ('roy.urena','passme','Roy','Ureña','1');

