USE COTEC_DB;
GO

CREATE OR ALTER PROCEDURE [deleteContact]
(
    @ContactDni VARCHAR(30)
)
AS
BEGIN
    SET NOCOUNT ON;

    -- First delete all contacts relationships
    DELETE PersonsContactedByPatient
    WHERE ContactDni=@ContactDni;

    -- Second all pathologies
    DELETE PersonPathologies
    WHERE PersonDni=@ContactDni;

    -- Then delete the Contact
    DELETE ContactedPersons
    WHERE Dni = @ContactDni;
END
GO