USE COTEC_DB;
GO

-- Delete Contacts
CREATE TRIGGER [DeleteContacts]
ON ContactedPersons
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ContactDni INT

    SELECT @ContactDni = d.Dni
    FROM deleted d;

    -- First delete all contacts relationships
    DELETE PersonsContactedByPatient
    WHERE ContactDni=@ContactDni;

    -- Second all pathologies
    DELETE PersonPathologies
    WHERE PersonDni=@ContactDni;

    -- The delete the Contact
    DELETE ContactedPersons
    WHERE Dni = @ContactDni;

    PRINT('SUCCES');
END;
GO