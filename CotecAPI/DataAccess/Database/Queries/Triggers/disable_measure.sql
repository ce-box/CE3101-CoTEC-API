USE COTEC_DB;
GO

-- Disable Sanitary Measure
CREATE TRIGGER [DisableMeasure]
ON SanitaryMeasures
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MeasureId INT

    SELECT @MeasureId = d.Id
    FROM deleted d;

    UPDATE CountrySanitaryMeasures
    SET [Status] = 'INACTIVE'
    WHERE MeasureId = @MeasureId;
END;
GO