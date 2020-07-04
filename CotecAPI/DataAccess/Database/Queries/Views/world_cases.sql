USE COTEC_DB;
GO

-- Returns CoTEC case data globally
CREATE VIEW [World Cases]
AS

SELECT
    'World'  AS CountryName,
    'ALL' AS CountryCode,
    NULL AS FlagUrl,
    (
        SELECT COUNT(*)
        FROM Events
        WHERE Type= 'INFECTED'
    ) AS Infected,
    (
        SELECT COUNT(*)
        FROM Events
        WHERE Type= 'RECOVERED'
    ) AS Recovered,
    (
        SELECT COUNT(*)
        FROM Events
        WHERE Type= 'DEAD'
    ) AS Deaths,
    dbo.ACTIVE_CASES('ALL') AS Active,
    dbo.DAILY_INCREASE('ALL') AS DailyIncrease;
GO

SELECT * FROM dbo.[World Cases];


