USE COTEC_DB;
GO

CREATE OR ALTER PROCEDURE [CrcPatients]
AS 
BEGIN
    SELECT 
        p.Dni as dni,
        p.Name as name,
        p.LastName as lastname,
        p.DoB as dob,
        p.Region as province,
        'no asignado' as canton,
        'no asignado' as district,
        'other' as sex
    FROM Patients AS p
    WHERE p.Country = 'CRI';
END;

EXEC CrcPatients;