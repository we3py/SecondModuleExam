USE [UsersDB]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (1, N'admin', N'admin', N'admin')
INSERT [dbo].[Users] ([Id], [Username], [Password], [Role]) VALUES (2, N'user', N'user', N'user')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
