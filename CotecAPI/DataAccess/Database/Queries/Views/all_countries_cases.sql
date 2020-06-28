USE COTEC_DB;
GO

/* Returns a table with the CoTEC case data presented by 
   each country registered in the database */
CREATE VIEW GetAllCountriesCases 
AS
SELECT
    C.Name,
    C.Code,
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
    dbo.DAILY_INCREASE(C.Code) AS Daily_Increase  
FROM Countries AS C;
GO
