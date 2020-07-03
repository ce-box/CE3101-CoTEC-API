USE COTEC_DB;
GO

-- Disable Implemented Sanitary Measure
CREATE TRIGGER [DisableCountryMeasure]
ON CountrySanitaryMeasures
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MeasureId INT,
            @CountryCode varchar(3);

    SELECT 
        @MeasureId = d.MeasureId, 
        @CountryCode = d.CountryCode
    FROM deleted d;

    UPDATE CountrySanitaryMeasures
    SET [Status] = 'INACTIVE'
    WHERE 
        MeasureId = @MeasureId
        AND 
        CountryCode = @CountryCode;
END;
GO