USE COTEC_DB;
GO

-- Returns a List of Medications that a Patient has
CREATE PROCEDURE [PatientMedication]
(@patientDni varchar(30))
AS
BEGIN
    SELECT 
        PM.MedicationId AS [MedicationId],
        M.Name AS [MedicationName],
        PC.Name AS [PharmaCo],
        PM.Prescription
    FROM
        PatientMedications AS PM 
        JOIN
        Medications AS M
        ON PM.MedicationId = M.Id
        JOIN
        PharmaceuticalCompanies AS PC
        ON M.PharmaceuticCo = PC.Id
    WHERE
        PM.PatientDni = @patientDni;
END;
GO