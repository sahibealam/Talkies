
USE [Talkis]
GO

/****** Object:  Table [dbo].[save_account]    Script Date: 06-03-2021 04:23:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[save_account](
	[save_id] [int] IDENTITY(1,1) NOT NULL,
	[save_name] [nvarchar](50) NULL,
	[save_Username] [nvarchar](50) NULL,
	[save_mobile] [nvarchar](50) NULL,
	[save_email] [varchar](50) NULL,
	[save_password] [nvarchar](50) NULL,
	[save_confirmpassword] [nvarchar](50) NULL,
	[save_gender] [nvarchar](50) NULL,
	[save_age] [varchar](50) NULL,
	[save_AddedOn] [datetime] NULL,
	[save_AddedBy] [nvarchar](50) NULL,
	[save_ModifiedOn] [datetime] NULL,
	[save_ModifiedBy] [nvarchar](50) NULL,
	[save_status] [int] NULL,
 CONSTRAINT [PK_save_account] PRIMARY KEY CLUSTERED 
(
	[save_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


