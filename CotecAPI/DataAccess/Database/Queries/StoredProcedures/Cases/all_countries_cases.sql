USE COTEC_DB;
GO

/* Returns a table with the CoTEC case data presented by 
   each country registered in the database */
CREATE PROCEDURE GetAllCountriesCases 
AS
BEGIN
    SELECT
        C.Name AS CountryName,
        C.Code AS CountryCode,
        C.FlagUrl,
        -- Cases inf@
        (
            SELECT COUNT(*)
            FROM Events as Ev
            WHERE Ev.Type= 'INFECTED' AND Ev.CountryCode=C.Code
        ) AS Infected,
        (
            SELECT COUNT(*)
            FROM Events as Ev
            WHERE Ev.Type= 'RECOVERED' AND Ev.CountryCode=C.Code
        ) AS Recovered,
        (
            SELECT COUNT(*)
            FROM Events as Ev
            WHERE Ev.Type= 'DEAD' AND Ev.CountryCode=C.Code
        ) AS Deaths,
        dbo.ACTIVE_CASES(C.Code) AS Active,
        dbo.DAILY_INCREASE(C.Code) AS DailyIncrease  
    FROM Countries AS C
    ORDER BY Infected DESC;
END;
GO

EXEC GetAllCountriesCases;
