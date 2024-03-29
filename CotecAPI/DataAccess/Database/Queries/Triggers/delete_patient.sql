USE COTEC_DB;
GO

-- Delete Contacts
CREATE OR ALTER TRIGGER [DeletePatients]
ON Patients
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PatientDni VARCHAR(30);

    SELECT @PatientDni = d.Dni
    FROM deleted d;

    -- First delete all contacts relationships
    DELETE PersonsContactedByPatient
    WHERE PatientDni=@PatientDni;

    -- Second all pathologies
    DELETE PatientPathologies
    WHERE PatientDni=@PatientDni;

    -- Thrid all medications
    DELETE PatientMedications
    WHERE PatientDni=@PatientDni;

    -- The delete the Contact
    DELETE Patients
    WHERE Dni = @PatientDni;

    PRINT('SUCCES');
END;
GO