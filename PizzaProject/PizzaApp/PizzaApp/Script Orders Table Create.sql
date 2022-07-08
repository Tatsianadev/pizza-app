USE [PizzaDB]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 7/8/2022 7:50:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PizzaId] [int] NOT NULL,
	[PizzaImage] [nvarchar](100) NULL,
	[PizzaName] [nvarchar](50) NOT NULL,
	[PizzaPrice] [int] NULL,
	[Size] [nvarchar](10) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.AspNetUsers_ApplicationUser_Id]
GO


