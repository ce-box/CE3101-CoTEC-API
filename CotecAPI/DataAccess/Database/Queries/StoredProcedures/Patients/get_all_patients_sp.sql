USE COTEC_DB;
GO

CREATE PROCEDURE [GetAllPatients]
( @Hospital_Id int)
AS
BEGIN
	SELECT  P.Dni,
			P.Name,
			P.LastName, 
			dbo.GET_AGE(P.DoB) AS [Age],
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
	WHERE P.Hospital_Id = @Hospital_Id;
END
GO