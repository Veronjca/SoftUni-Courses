CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount SMALLMONEY)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @moneyToAdd SMALLMONEY = ABS(@MoneyAmount);
		UPDATE [Accounts] 
			SET [Balance] += @moneyToAdd
			WHERE [Id] = @AccountId
	COMMIT;
END