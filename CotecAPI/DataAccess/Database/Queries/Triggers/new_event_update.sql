USE COTEC_DB;
GO

-- Creates a new event when a patient status is updated
CREATE TRIGGER [NewEventUpdate]
ON Patients 
AFTER UPDATE
AS
BEGIN
    -- Status has changes?
    IF UPDATE([Status])
    BEGIN
        SET NOCOUNT ON

        DECLARE
            @Type varchar(20),
            @Date DATE,
            @Country varchar(3);

        -- Get new Status
        SET @Type = (
            SELECT PS.Name 
            FROM 
                inserted
                JOIN PatientStatus AS PS
                ON [Status] = PS.Id
            );
        PRINT(@Type);

        SET @Date = GETDATE();
        SET @Country = (SELECT Country FROM inserted);

        -- Check if is a valid event
        IF @Type IN ('INFECTED','RECOVERED','DEAD')
        BEGIN
            INSERT INTO dbo.Events ([Type], [Date], CountryCode)
            VALUES (@Type, @Date, @Country);
        END;
    END;
    
END;
GO