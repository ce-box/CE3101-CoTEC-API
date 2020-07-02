USE COTEC_DB;
GO

CREATE PROCEDURE [GetContacts](@patientDni varchar(20))
AS
BEGIN
    SELECT
        CP.Dni,
        CP.Name,
        CP.LastName,
        dbo.GET_AGE(CP.DoB) AS [Age],
        CP.Email,
        CP.Address,
        CP.Region,
        C.Name AS [Country]
    FROM
        PersonsContactedByPatient AS PC
        JOIN
        ContactedPersons AS CP 
        ON PC.ContactDni = CP.Dni
        JOIN 
        Countries AS C
        ON CP.Country = C.Code
    WHERE 
        PC.PatientDni = @patientDni
END;
GO