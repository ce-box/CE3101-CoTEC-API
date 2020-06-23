USE COTEC_DB;
GO

CREATE PROCEDURE [PatientSummary]
(@patientDni varchar(30))
AS
SELECT  P.Dni,
		P.Name+' '+P.LastName AS [Name], 
		DATEDIFF(hour,P.DoB,GETDATE())/8766 AS [Age],
		P.Hospitalized,
		P.ICU,
		H.Name as [Hospital],
		PS.Name as [Status], 
		P.Region,
		C.Name as [Country]	
FROM (
		Patients AS P 
		INNER JOIN 
		Hospitals AS H ON Hospital_Id=Id
		INNER JOIN 
		PatientStatus AS PS ON P.Status = PS.Id 
		INNER JOIN 
		Countries AS C ON P.Country=C.Code
	  )
WHERE P.Dni = @patientDni;
GO