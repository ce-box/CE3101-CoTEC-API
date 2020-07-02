USE COTEC_DB;
GO

-- Returns the daily increase in cases
CREATE FUNCTION GET_AGE ( @DoB DATE )
RETURNS INT
AS
BEGIN

    DECLARE @Age INT;

    SET @Age = DATEDIFF(hour,@DoB,GETDATE())/8766

    RETURN @Age;
END
GO