USE [MaterialsDB]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [AuthorName], [Description]) VALUES (1, N'Krzysztof Jarzyna', N'Boss of the bosses')
INSERT [dbo].[Authors] ([Id], [AuthorName], [Description]) VALUES (2, N'Ryszard Ochódzki', N'Tradition is a sacred thing')
INSERT [dbo].[Authors] ([Id], [AuthorName], [Description]) VALUES (3, N'Wacław Jarząbek', N'A faithful subordinate')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialTypes] ON 

INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (1, N'Book', N'A book that describes the issue in detail')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (2, N'Video Tutorial', N'Video tutorial is a video material that focuses mostly on guiding step-by-step in dedicated topic')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (3, N'Presentation', N'A presentation describing each issue')
INSERT [dbo].[MaterialTypes] ([Id], [Name], [Definition]) VALUES (4, N'Exercise', N'Exercise to help understand the problem')
SET IDENTITY_INSERT [dbo].[MaterialTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Materials] ON 

INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (1, 1, N'How to be the boss', N'Book describing in general how to become a boss', N'Library at Szczecińska', 1, CAST(N'2015-05-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (3, 1, N'How to manage people', N'A video showing how to manage a large number of people', N'Library at Szczecińska 9', 2, CAST(N'2013-02-14T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (4, 2, N'What is tradition', N'A short presentation explaining the definitions of tradition ji
', N'Library in Warsaw', 3, CAST(N'2008-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (5, 2, N'Being bald', N'A book describing the struggle with the world', N'Library in Warsaw', 1, CAST(N'2003-04-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (7, 3, N'Good employee', N'Film about the relationship with the boss', N'Warsaw television archive', 2, CAST(N'2005-08-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Materials] ([Id], [AuthorId], [Title], [Description], [Location], [MaterialTypeId], [PublicationDate]) VALUES (8, 3, N'How to sing', N'Presentation describing the basics of singing at work', N'Computer of Wiesław', 3, CAST(N'2020-11-05T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Materials] OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialReviews] ON 

INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (1, 1, N'Very good material', 7)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (2, 1, N'Not so bad', 6)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (3, 3, N'I am suprised how good it is', 8)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (4, 3, N'Dissapoinment', 4)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (5, 4, N'I am shocked', 9)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (6, 4, N'Thumbs up!', 8)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (7, 5, N'It is good', 7)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (8, 5, N'Really nice', 8)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (11, 7, N'Wow', 7)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (12, 7, N'Classic', 9)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (13, 8, N'I find it well', 8)
INSERT [dbo].[MaterialReviews] ([Id], [MaterialId], [Review], [Rating]) VALUES (14, 8, N'It is shocking', 7)
SET IDENTITY_INSERT [dbo].[MaterialReviews] OFF
GO
