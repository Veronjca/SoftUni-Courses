--CREATE TABLE [Logs]
--(
--	[LogId] INT PRIMARY KEY IDENTITY,
--	[AccountId] INT NOT NULL,
--	[OldSum] MONEY NOT NULL,
--	[NewSum] MONEY NOT NULL
--)

CREATE TRIGGER tr_OnAccountSumChange
ON [Accounts] AFTER UPDATE
AS
BEGIN
	INSERT INTO [Logs] ([AccountId], [OldSum], [NewSum])
	VALUES 
	(
		(SELECT [Id] FROM inserted),
		(SELECT [Balance] FROM deleted),
		(SELECT [Balance] FROM inserted)
	)
END
