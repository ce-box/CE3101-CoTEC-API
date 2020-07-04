USE COTEC_DB;
GO

-- Returns CoTEC all medications
CREATE VIEW [GetMedications]
AS

SELECT
    M.Id AS [Id],
    M.Name AS [MedicationName],
    PC.Name AS [PharmaCo]
FROM
    Medications AS M 
    INNER JOIN 
    PharmaceuticalCompanies AS PC
    ON M.PharmaceuticCo = PC.Id
GO