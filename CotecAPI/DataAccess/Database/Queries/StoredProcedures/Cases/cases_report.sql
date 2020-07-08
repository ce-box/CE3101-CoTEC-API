USE COTEC_DB;
GO

CREATE OR ALTER PROCEDURE [LastWeekCasesReport](@Country varchar(3))
AS
BEGIN
    -- Declare tmp Tables
    DECLARE @CountryEvents TABLE(Type varchar(20),[Date] DATE);
    DECLARE @CountryReport TABLE(Infected int,  Deaths int, [Date] DATE);

    -- Declare day variables
    DECLARE @Today DATE,
            @DayIndex DATE;
    
    -- Set Current Date
    SET @Today = CONVERT(varchar, GETDATE(), 111);
    -- 7 days ago
    SET @DayIndex = CONVERT(varchar, DATEADD(DD,-7,GETDATE()), 111);  
    
    -- Filter Events By Country and Type
    INSERT INTO @CountryEvents  
    SELECT E.Type, E.Date 
    FROM Events as E 
    WHERE E.CountryCode = @Country AND 
          Type IN ('INFECTED','DEAD');
    
    -- For each day in the week, insert the count of infected and deaths.
    WHILE DATEDIFF(day,@DayIndex,@Today) >=  0
    BEGIN
        INSERT INTO @CountryReport (Infected,Deaths, [Date])
        VALUES  (
            (
                SELECT COUNT(*)
                FROM @CountryEvents
                WHERE Type= 'INFECTED' AND [Date]= @DayIndex
            ),
            (
                SELECT COUNT(*)
                FROM @CountryEvents
                WHERE Type= 'DEAD' AND [Date]= @DayIndex
            ),
            @DayIndex
        );
        SET @DayIndex = DATEADD(DD,+1,@DayIndex);
    END;

    -- Get the results
    SELECT
        Infected, Deaths, [Date]
    FROM @CountryReport;

END
GO

-- How to call
-- EXEC LastWeekCasesReport @Country= 'CRI';