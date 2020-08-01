USE COTEC_DB;
GO

-- Delete Pathologies
CREATE OR ALTER TRIGGER [DeletePathologies]
ON Pathologies
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @pathology varchar(50)

    SELECT @pathology = d.Name
    FROM deleted d;

    -- First delete all contacts patologies
    DELETE PersonPathologies
    WHERE PathologyName=@pathology;

    -- Second all patient pathologies
    DELETE PatientPathologies
    WHERE PathologyName=@pathology;

    -- The delete the Pathology
    DELETE Pathologies
    WHERE [Name]=@pathology;

    PRINT('SUCCES');
END;
GO