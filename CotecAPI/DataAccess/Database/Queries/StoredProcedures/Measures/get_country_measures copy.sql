USE COTEC_DB;
GO

CREATE PROCEDURE [GetCountryMeasures](@countryCode varchar(3))
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
END
GO

EXEC GetCountryMeasures @countryCode = 'CRI';