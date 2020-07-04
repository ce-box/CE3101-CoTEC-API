USE COTEC_DB;
GO

CREATE TRIGGER [NotifyContact]
ON PersonsContactedByPatient
AFTER INSERT
AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @contactDni varchar(30),
            @patientDni varchar(30);

    SELECT
        @ContactDni=I.ContactDni, 
        @PatientDni=I.PatientDni
    FROM 
        INSERTED AS I 

    -- Notify Contact By Email
    EXEC ContactRelation @ContactDni=@contactDni, @PatientDni=@patientDni;
END
GO
