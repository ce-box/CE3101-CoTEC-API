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

-- Insert Employees
INSERT INTO HospitalEmployees
(
    Username,
    [Password],
    [Name],
    LastName,
    Hospital_Id )
VALUES
    ('onu.hospital','passme','Frodo','Bolsón',8),
    ('usa.hospital','passme','Jaime','Altozano',9),
    ('mex.hospital','passme','Ester','Rojas',10),
    ('esp.hospital','passme','Juan','Ilama',11),
    ('fra.hospital','passme','Juan','Ilama',12),
    ('uk.hospital','passme','Juan','Ilama',13),
    ('ptr.hospital','passme','Juan','Ilama',14),
    ('ita.hospital','passme','Juan','Ilama',15),
    ('chn.hospital','passme','Juan','Ilama',16),
    ('rus.hospital','passme','Juan','Ilama',17);
UPDATE Countries 
SET Name = 'United States'
WHERE Code = 'USA';

DELETE Patients
WHERE Name IN (
    'Gary Welch',
    'Maxwell T. Stanton',
    'Kenyon Acevedo',
    'Howard Valentine',
    'Prince, Kadeem Y.',
    'Velasquez, Craig V.',
    'Isabelle Turner',
    'Hale, Cally Z.',
    'Seth Barr',
    'Rafael Lynch',
    'Upton Z. Dominguez',
    'Randall Vazquez',
    'Sebastian Mclaughlin',
    'Bradley Hernandez',
    'Kirsten Burch',
    'Clayton J. Stafford'
)

SELECT * FROM Patients WHERE Hospital_Id=8;