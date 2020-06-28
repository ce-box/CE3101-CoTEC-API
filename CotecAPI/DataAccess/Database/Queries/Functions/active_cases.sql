USE COTEC_DB;
GO

-- Returns the number of active cases
CREATE FUNCTION ACTIVE_CASES ( @Country varchar(3) )
RETURNS INT
AS
BEGIN

    -- Declare Variables
    DECLARE @Infected INT;
    DECLARE @Recovered INT;
    DECLARE @Deaths INT;

    -- World Cases
    IF @Country = 'ALL'
        BEGIN
            SET @Infected = (SELECT COUNT(*) FROM Events WHERE Type='INFECTED');
            SET @Recovered = (SELECT COUNT(*) FROM Events WHERE Type='RECOVERED');
            SET @Deaths = (SELECT COUNT(*) FROM Events WHERE Type='DEAD');
        END

    -- Country Cases
    ELSE
        BEGIN
            SET @Infected = (SELECT COUNT(*) FROM Events WHERE Type='INFECTED' AND CountryCode=@Country);
            SET @Recovered = (SELECT COUNT(*) FROM Events WHERE Type='RECOVERED' AND CountryCode=@Country);
            SET @Deaths = (SELECT COUNT(*) FROM Events WHERE Type='DEAD' AND CountryCode=@Country);
        END
    -- Returns the active Cases
    RETURN @Infected - (@Recovered + @Deaths);
END
GO

SELECT Date FROM Events WHERE Date = CONVERT(varchar,GETDATE(),111);
INSERT INTO Events (Type,Date,CountryCode)
VALUES ('INFECTED','2020-06-27','CRI');

PRINT dbo.ACTIVE_CASES('ALL');