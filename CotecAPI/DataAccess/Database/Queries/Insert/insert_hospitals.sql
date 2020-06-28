USE COTEC_DB;
GO

INSERT INTO Hospitals (Name, ManagerName, Phone, Capacity, ICU_Capacity, Region, Country)
VALUES ('Hospital Nacional de Niños', 'Rodolfo Hernández','(+506)2523-3600',1400,100,'San Jose','CRI');

SELECT * FROM PatientStatus;




INSERT INTO Patients(Dni,Name,LastName,DoB,Hospitalized,ICU,Status,Hospital_Id,Region,Country)
VALUES ('1-1756-1922','Esteban','Alvarado','1999-10-08',0,0,2,1,'San Jose','CRI');

SELECT  P.Dni,
		P.Name+' '+P.LastName AS [Name], 
		DATEDIFF(hour,P.DoB,GETDATE())/8766 AS [Age],
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
WHERE Dni='1-1756-1922';

SELECT * 
FROM (Patients AS P INNER JOIN Hospitals AS H ON Hospital_Id=Id) INNER JOIN PatientStatus AS PS ON P.Status = PS.Id
WHERE Dni='1-1756-1922';

