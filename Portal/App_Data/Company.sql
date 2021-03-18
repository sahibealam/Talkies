USE [Talkis]
GO

/****** Object:  Table [dbo].[tbl_Company]    Script Date: 3/13/2021 5:41:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Company](
	[tbl_Company_id] [int] IDENTITY(1,1) NOT NULL,
	[tbl_Company_Name] [nvarchar](50) NULL,
	[Ato_sell] [nvarchar](50) NULL,
	[Ato_By] [int] NULL,
	[Totl_sell] [nvarchar](50) NULL,
	[Totl_Qty] [int] NULL,
	[tbl_Final_Qty] [int] NULL,
	[tbl_Self_result] [nvarchar](50) NULL,
	[tbl_NSE_result] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[tbl_Company_Status] [int] NULL,
 CONSTRAINT [PK_tbl_Company] PRIMARY KEY CLUSTERED 
(
	[tbl_Company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

