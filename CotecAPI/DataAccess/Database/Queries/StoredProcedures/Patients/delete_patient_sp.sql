USE COTEC_DB;
GO

CREATE OR ALTER PROCEDURE [deletePatient]
(
    @PatientDni VARCHAR(30)
)
AS
BEGIN
    SET NOCOUNT ON;

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
END
GO