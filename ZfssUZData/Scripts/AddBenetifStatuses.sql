SET IDENTITY_INSERT [dbo].[BenefitStatus] ON
INSERT INTO [dbo].[BenefitStatus] (Id, Value)
VALUES (1, 'Przekazany'),
	   (2, 'W trakcie weryfikacji'),
	   (3, 'Zaakceptowany'),
	   (4, 'Odrzucony');
SET IDENTITY_INSERT [dbo].[BenefitStatus] OFF