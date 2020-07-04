USE COTEC_DB;
GO

CREATE PROCEDURE [ContactSummary]
(@contactDni varchar(30))
AS
SELECT  P.Dni,
		P.Name,
		P.LastName,
		dbo.GET_AGE(P.DoB) AS [Age],
        P.Email,
        P.Address,
		P.Region,
		C.Name as [Country]	
FROM (
		ContactedPersons AS P 
		INNER JOIN 
		Countries AS C ON P.Country=C.Code
	  )
WHERE P.Dni = @contactDni;
GO

--EXEC ContactSummary @contactDni = '754123669';