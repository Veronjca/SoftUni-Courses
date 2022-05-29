CREATE PROC  usp_WithdrawMoney (@AccountId INT, @MoneyAmount SMALLMONEY)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @moneyToWithdraw SMALLMONEY = ABS(@MoneyAmount);
		UPDATE [Accounts] 
			SET [Balance] -= @moneyToWithdraw
			WHERE [Id] = @AccountId
	COMMIT;
END