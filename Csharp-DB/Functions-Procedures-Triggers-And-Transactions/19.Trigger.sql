UPDATE [UsersGames]
	SET [Cash] += 50000
	WHERE [UserId] IN (SELECT [Id] FROM [Users] WHERE [Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
	AND [GameId] IN (SELECT [Id] FROM [Games] WHERE [Name] = 'Bali')

	CREATE PROC usp_BuyItem (@UserId INT, @ItemId INT)
	AS
	BEGIN
		BEGIN TRANSACTION
		COMMIT
	END

	CREATE TRIGGER tr_OnUpdateUsersGames
	