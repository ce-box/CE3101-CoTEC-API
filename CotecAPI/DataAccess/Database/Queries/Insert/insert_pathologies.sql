USE COTEC_DB;
GO

INSERT INTO Pathologies ([Name],Symptoms,[Description],Treatment)
VALUES
    ('Ebola','hemorragia','solo en africa','no hay'),
    ('Covid','tos','mundial','respirador'),
    ('Denge','fiebre','mosquitos','antiinflamatorios');
GO

SELECT * FROM Pathologies;