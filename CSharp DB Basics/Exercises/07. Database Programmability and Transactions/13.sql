CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS @Table TABLE(SumCash MONEY) AS
BEGIN
	INSERT INTO @Table
	SELECT SUM(Cash) 
	FROM
	(SELECT GameId, Cash,
    ROW_NUMBER() OVER (PARTITION BY GameId ORDER BY Cash DESC) AS Row
    FROM UsersGames ug
    JOIN Games g ON ug.GameId = g.Id
    WHERE g.Name = @GameName) as g
    WHERE (Row % 2 = 1)
	RETURN
END