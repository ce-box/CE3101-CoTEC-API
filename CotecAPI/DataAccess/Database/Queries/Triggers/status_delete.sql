USE COTEC_DB;
GO

-- Avoids to delete default status
CREATE TRIGGER [DeleteStatus]
ON PatientStatus
AFTER DELETE
AS
BEGIN
    IF EXISTS(SELECT * FROM deleted d WHERE d.Id < 5)
    BEGIN    
        ROLLBACK    
        RAISERROR('ERROR: That Status May Not Be Deleted',16,1)
    END
END;
GO