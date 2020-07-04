USE COTEC_DB;
GO

-- Returns a List of all Pathologies that a Patient has
CREATE PROCEDURE [ContactPathology]
(@contactDni varchar(30))
AS
BEGIN
    SELECT 
        P.Name,
        P.Description,
        P.Symptoms,
        P.Treatment
    FROM
        PersonPathologies AS PP 
        JOIN
        Pathologies AS P
        ON PP.PathologyName = P.Name
    WHERE
        PP.PersonDni = @contactDni;
END;
GO

--EXEC dbo.ContactPathology @contactDni = '117561922';