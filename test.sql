use CMCUni2

DROP TABLE __EFMigrationsHistory;

SELECT TOP (1000) [Id]
	,[Name]
	,[Age]
	,[Class]
	,[Photo]
FROM [CMCUni2].[dbo].[Students]