USE COTEC_DB;
GO

-- Creates a new Event when a patient is created
CREATE TRIGGER [NewEvent]
ON Patients
AFTER INSERT
AS
BEGIN

    SET NOCOUNT ON

    DECLARE
        @Type varchar(20),
        @Date DATE,
        @Country varchar(3);

    SET @Type = 'INFECTED';
    SET @Date = GETDATE();
    SET @Country = (SELECT Country FROM inserted);


    INSERT INTO dbo.Events (Type, Date, CountryCode)
    VALUES (@Type, @Date, @Country);
END;
GO