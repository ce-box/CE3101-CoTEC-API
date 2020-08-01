USE COTEC_DB;
GO

-- Delete Pathologies
CREATE OR ALTER TRIGGER [DeleteMedications]
ON Medications
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @medication varchar(50)

    SELECT @medication = d.Id
    FROM deleted d;

    -- First delete all patients medication
    DELETE PatientMedications
    WHERE MedicationId=@medication;

    -- The delete the Pathology
    DELETE Medications
    WHERE [Name]=@medication;

    PRINT('SUCCES');
END;
GO