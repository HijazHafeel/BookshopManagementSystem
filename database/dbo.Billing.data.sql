SET IDENTITY_INSERT [dbo].[Billing] ON
INSERT INTO [dbo].[Billing] ([Bill_ID], [U_ID], [Qty], [Total_Amount], [Billing_Date]) VALUES (1, N'u001      ', 5, CAST(74.95 AS Decimal(18, 2)), N'2026-06-09 19:46:37')
SET IDENTITY_INSERT [dbo].[Billing] OFF
