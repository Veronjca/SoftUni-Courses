CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount SMALLMONEY)
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @senderBalance MONEY = (SELECT [Balance] FROM [Accounts] WHERE [Id] = @SenderId);
		DECLARE @moneyToTransfer SMALLMONEY = ABS(@Amount);

		IF @senderBalance > @moneyToTransfer
			BEGIN
				EXEC dbo.usp_DepositMoney @ReceiverId, @moneyToTransfer;
				EXEC dbo.usp_WithdrawMoney @SenderId, @moneyToTransfer;
			END
	COMMIT;
END