USE COTEC_DB;
GO

-- Returns the CoTEC case data presented by a specific country
CREATE PROCEDURE GetCasesByCountry ( @Country varchar(3))
AS
BEGIN

    DECLARE @CountryEvents TABLE(Type varchar(20),Date DATE);

    INSERT INTO @CountryEvents  
    SELECT E.Type, E.Date 
    FROM Events as E 
    WHERE E.CountryCode = @Country;

    SELECT
        -- CountryMetadata
        C.Name as CountryName,
        C.Code as CountryCode,
        C.FlagUrl,
        -- Cases inf@
        (
            SELECT COUNT(*)
            FROM @CountryEvents
            WHERE Type= 'INFECTED'
        ) AS Infected,
        (
            SELECT COUNT(*)
            FROM @CountryEvents
            WHERE Type= 'RECOVERED'
        ) AS Recovered,
        (
            SELECT COUNT(*)
            FROM @CountryEvents
            WHERE Type= 'DEAD'
        ) AS Deaths,
        dbo.ACTIVE_CASES(@Country) AS Active,
        dbo.DAILY_INCREASE(@Country) AS DailyIncrease
    FROM Countries as C
    WHERE C.Code = @Country;

END;
GO
