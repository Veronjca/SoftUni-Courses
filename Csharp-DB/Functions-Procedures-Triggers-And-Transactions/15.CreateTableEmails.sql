--CREATE TABLE [NotificationEmails]
--(
--	[Id] INT IDENTITY PRIMARY KEY,
--	[Recipient] INT NOT NULL,
--	[Subject] NVARCHAR(MAX) NOT NULL,
--	[Body] NVARCHAR(MAX) NOT NULL
--)

CREATE TRIGGER tr_OnAddedLog
ON [Logs] AFTER INSERT
AS
BEGIN
	INSERT INTO [NotificationEmails] ([Recipient], [Subject], [Body])
	VALUES
	(
		(SELECT [AccountId] FROM inserted),
		(CONCAT_WS(' ','Balance change for account:', (SELECT [AccountId] FROM inserted))),
		(CONCAT_WS(' ', 'On', GETDATE(), 'your balance was changed from', (SELECT [OldSum] FROM inserted), 'to', (SELECT [NewSum] FROM inserted)))
	)
END