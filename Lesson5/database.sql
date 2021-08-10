USE [Company]
GO

/****** Object:  Table [dbo].[EmployeeCategory]    Script Date: 10.08.2021 21:21:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeCategory](
	[Categoryid] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeeCategory] PRIMARY KEY CLUSTERED 
(
	[Categoryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Departments]    Script Date: 10.08.2021 21:22:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Departments](
	[Departmentid] [int] NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Departmentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 10.08.2021 21:24:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[ID] [int] NOT NULL,
	[LastName] [nvarchar](255) NULL,	
	[FirstName] [nvarchar](255) NULL,
	[SecondName] [nvarchar](255) NULL,
	[Position] [nvarchar](255) NULL,	
	[Categoryid] [int] NOT NULL,
	[Departmentid] [int] NOT NULL,
	[Works] [bit] NOT NULL,
	[Comment] [nvarchar](255) NULL,	
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employeess]  WITH CHECK ADD  CONSTRAINT [FK_Employees_EmployeeCategory] FOREIGN KEY([Categoryid])
REFERENCES [dbo].[EmployeeCategory] ([Categoryid])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_EmployeeCategory]
GO

ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([Departmentid])
REFERENCES [dbo].[EmployeeDepartments] ([Departmentid])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO

