USE COTEC_DB;
GO

CREATE PROCEDURE [GetActiveCountryMeasures](@countryCode varchar(3))
AS
BEGIN

    -- Update Status
    UPDATE CountrySanitaryMeasures
    SET [Status] = 'INACTIVE'
    WHERE DATEDIFF(day,GETDATE(),EndDate) <= 0 -- Yesterday is not in 

    DECLARE @CountryMeasures TABLE(MeasureId INT, StartDate DATE, EndDate DATE, [Status] varchar(15));
    
    INSERT INTO @CountryMeasures
    SELECT CM.MeasureId, CM.StartDate, CM.EndDate, CM.[Status]
    FROM CountrySanitaryMeasures AS CM
    WHERE CM.CountryCode = @countryCode

    SELECT
        SM.Id,
        SM.Name,
        SM.[Description],
        CM.StartDate,
        CM.EndDate,
        CM.[Status]
    FROM
        @CountryMeasures AS CM
        INNER JOIN
        SanitaryMeasures AS SM
        ON CM.MeasureId = SM.Id
    WHERE CM.[Status] = 'ACTIVE' 
    AND (DATEDIFF(week,StartDate,GETDATE()) = 0 -- Comienzan esa semana
    OR DATEDIFF(week,EndDate,GETDATE()) <= 0); -- Continúan más allá de esa semana
      -- Las medidas activas que aplican una semana después (empiezan/terminan)
END
GO

EXEC GetActiveCountryMeasures @countryCode = 'CRI';