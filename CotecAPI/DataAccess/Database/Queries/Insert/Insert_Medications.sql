USE COTEC_DB;
GO

-- Insert Phar.Co
INSERT INTO PharmaceuticalCompanies (Name)
VALUES ('Pfizer'),
	   ('GlaxoSmithKline'),
	   ('Sanofi-Aventis'),
	   ('Johnson & Johnson'),
	   ('Merck & Co'),
	   ('AstraZeneca'),
	   ('Novartis'),
	   ('Bristol-Myers Squibb'),
	   ('Wyeth'),
	   ('Abbott Labs'),
	   ('Bayern Co'),
	   ('Roche'),
	   ('Lilly'),
	   ('Roche'),
	   ('COFASA'),
	   ('Laboratorios Lisan'),
	   ('CALOX Costa Rica S.A'),
	   ('GSK'),
	   ('Amgen');
GO

-- Insert some medications 
INSERT INTO Medications (Name, PharmaceuticCo)
VALUES ('ALECENSA',12),
	   ('AVASTIN',12),
	   ('BONDRONAT 25 mg',12),
	   ('BONDRONAT 6 mg',12),
	   ('CELLCEPT 250 mg',12),
	   ('CELLCEPT 500 mg',12);

SELECT M.Name AS Medication, PC.Name AS PharmCo FROM Medications as M JOIN PharmaceuticalCompanies as PC ON M.PharmaceuticCo = PC.Id;
GO