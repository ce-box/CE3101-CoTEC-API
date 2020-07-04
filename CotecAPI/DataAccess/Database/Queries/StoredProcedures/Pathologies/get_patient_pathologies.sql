USE COTEC_DB;
GO

-- Returns a List of all Pathologies that a Patient has
ALTER PROCEDURE [PatientPathology]
(@patientDni varchar(30))
AS
BEGIN
    SELECT 
        P.Name,
        P.Description,
        P.Symptoms,
        P.Treatment
    FROM
        PatientPathologies AS PP 
        JOIN
        Pathologies AS P
        ON PP.PathologyName = P.Name
    WHERE
        PP.PatientDni = @patientDni;
END;
GO

EXEC dbo.PatientPathology @patientDni = 117561922;