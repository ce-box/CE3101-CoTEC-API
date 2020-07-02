USE COTEC_DB;
GO

-- Returns CoTEC all pathologies
CREATE VIEW [GetPathologies]
AS

SELECT
    P.Name AS [Pathology],
    P.[Description]
FROM
    Pathologies AS P 
GO