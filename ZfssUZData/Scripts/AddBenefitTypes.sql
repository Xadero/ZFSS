SET IDENTITY_INSERT [dbo].[BenefitType] ON
INSERT INTO [dbo].[BenefitType](Id, Value)
VALUES (1, 'Wniosek o pożyczkę mieszkaniową'),
	   (2, 'Wniosek o świadczenie socjalne');
SET IDENTITY_INSERT [dbo].[BenefitType] OFF