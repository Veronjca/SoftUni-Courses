CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN 
		DECLARE @Position INT = 1;
		WHILE @Position <= LEN(@word)
			BEGIN 
				IF @setOfLetters LIKE ('%' + SUBSTRING(@word, @Position, 1) + '%')
					SET @Position += 1;
				ELSE
					RETURN 0;		
			END
		RETURN 1;
END


DECLARE @Result BIT = dbo.ufn_IsWordComprised('bobr', 'Rob');
SELECT @Result
	