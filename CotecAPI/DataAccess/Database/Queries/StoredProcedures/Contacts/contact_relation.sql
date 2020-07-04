USE COTEC_DB;
GO

-- Notifies about a new contact relationship
CREATE PROCEDURE [ContactRelation]
(
    @ContactDni varchar(30),
    @PatientDni varchar(30)
)
AS
BEGIN

    DECLARE @PatientName varchar(40),
            @ContactName varchar(40),
            @ContactEmail varchar(60),
            @Mail varchar(500)   ;

    SET @PatientName = (
        SELECT P.Name+' '+P.LastName  
        FROM Patients AS P 
        WHERE P.Dni = @PatientDni
    );

    SET @ContactName = (
        SELECT P.Name+' '+P.LastName  
        FROM ContactedPersons AS P 
        WHERE P.Dni = @ContactDni
    );

    SET @ContactEmail = (
        SELECT P.Email
        FROM ContactedPersons AS P 
        WHERE P.Dni = @ContactDni
    );

    SET @Mail = @ContactName+'!'+CHAR(13)+CHAR(10)+'CotecMap informs you that you have had contact with '+@PatientName+' who has been diagnosed with CoTEC-20 disease and identified you as a recent contact'+ CHAR(13)+CHAR(10) +'We ask you to go to your nearest medical center!';

    EXEC msdb.dbo.sp_send_dbmail
        @profile_name = 'COTEC',
        @recipients = @ContactEmail,
        @body = @Mail,
        @subject = 'Urgent notice';
    
END
GO

EXEC ContactRelation @ContactDni='117560922', @PatientDni='125691459';