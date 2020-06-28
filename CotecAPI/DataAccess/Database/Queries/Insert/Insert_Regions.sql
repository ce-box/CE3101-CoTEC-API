USE COTEC_DB;
GO

-- Insert Patient Status
INSERT INTO PatientStatus (Name)
VALUES ('ACTIVE'),
	   ('INFECTED'),
	   ('RECOVERED'),
	   ('DEAD');

SELECT * FROM PatientStatus;

-- Insert CR Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('San Jose','CRI'),
	   ('Alajuela','CRI'),
	   ('Heredia','CRI'),
	   ('Cartago','CRI'),
	   ('Puntarenas','CRI'),
	   ('Guanacaste','CRI'),
	   ('Limon','CRI');

SELECT * FROM Regions WHERE CountryCode='CRI';