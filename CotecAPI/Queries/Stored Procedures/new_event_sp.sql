CREATE PROCEDURE [New Case]
(
	@CountryCode varchar(3),
	@Type varchar(20)
)
AS
INSERT INTO Events 
(Type,Date,CountryCode)
VALUES (@Type,GETDATE(),@CountryCode);
GO