CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(50))
RETURNS BIT AS
BEGIN
	IF @word LIKE '%[^' + @setOfLetters + ']%'
		RETURN 0
	RETURN 1
END