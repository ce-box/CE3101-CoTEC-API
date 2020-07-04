USE COTEC_DB;
GO

-- Delete Contacts
CREATE TRIGGER [DeletePatients]
ON Patients
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @PatientDni INT

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