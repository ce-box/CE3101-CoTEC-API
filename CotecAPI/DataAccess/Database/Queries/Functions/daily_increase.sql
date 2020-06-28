USE COTEC_DB;
GO

-- Returns the daily increase in cases
CREATE FUNCTION DAILY_INCREASE ( @Country varchar(3) )
RETURNS INT
AS
BEGIN

    DECLARE @Increase INT;
    DECLARE @Date DATE;

    SET @Date = CONVERT(varchar,GETDATE(),111);

    -- World Cases
    IF @Country = 'ALL'
        BEGIN
            SET @Increase = (
                SELECT COUNT(*) 
                FROM Events 
                WHERE Type = 'INFECTED' AND Date = @Date);
        END
    ELSE
        BEGIN
            SET @Increase = (
                SELECT COUNT(*) 
                FROM Events 
                WHERE Type = 'INFECTED' AND Date = @Date AND CountryCode=@Country);
        END

    RETURN @Increase;
END
GO

PRINT dbo.DAILY_INCREASE('CRI');