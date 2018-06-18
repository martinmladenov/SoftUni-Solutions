CREATE PROC usp_GetTownsStartingWith(@startsWith NVARCHAR(30)) AS
BEGIN
	SELECT Name
	FROM Towns
	WHERE Name LIKE @startsWith + '%'
END