USE [master]
GO
/****** Object:  Database [SalesDB]    Script Date: 9/11/2016 9:25:56 PM ******/
CREATE DATABASE [SalesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SalesDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SalesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SalesDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SalesDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SalesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SalesDB] SET  MULTI_USER 
GO
ALTER DATABASE [SalesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SalesDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SalesDB', N'ON'
GO
USE [SalesDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9/11/2016 9:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [nchar](5) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Phone] [nchar](10) NOT NULL,
	[Fax] [nchar](10) NULL,
	[EmailAddress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 9/11/2016 9:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](20) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SalesTransactionId] [int] NOT NULL,
	[EnteredBy] [nvarchar](50) NULL,
	[EnteredDate] [datetime] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/11/2016 9:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Type] [int] NOT NULL,
	[BasePrice] [money] NOT NULL,
	[ListPrice] [money] NOT NULL,
	[TotalInStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesTransaction]    Script Date: 9/11/2016 9:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[EnterdBy] [varchar](50) NULL,
	[EnteredDate] [datetime] NULL,
 CONSTRAINT [PK_SalesTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_SalesTransaction] FOREIGN KEY([SalesTransactionId])
REFERENCES [dbo].[SalesTransaction] ([Id])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_SalesTransaction]
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD  CONSTRAINT [FK_SalesTransaction_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[SalesTransaction] CHECK CONSTRAINT [FK_SalesTransaction_Customer]
GO
ALTER TABLE [dbo].[SalesTransaction]  WITH CHECK ADD  CONSTRAINT [FK_SalesTransaction_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[SalesTransaction] CHECK CONSTRAINT [FK_SalesTransaction_Product]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesTransactions]    Script Date: 9/11/2016 9:26:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSalesTransactions] 
	-- Add the parameters for the stored procedure here
	
AS
DECLARE @sql varchar(100)
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	 SET @sql='<html>
 <head>
  <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
  <script type="text/javascript">
    google.charts.load("current", {"packages":["table"]});
    google.charts.setOnLoadCallback(drawTable);
	function drawTable() {
  var data = new google.visualization.DataTable();
  data.addColumn("string", "Name");
  data.addColumn("number", "Salary");
  data.addColumn("boolean", "Full Time");
  data.addRows(5);
  data.setCell(0, 0, "John");
  data.setCell(0, 1, 10000, "$10,000");
  data.setCell(0, 2, true);
  data.setCell(1, 0, "Mary");
  data.setCell(1, 1, 25000, "$25,000");
  data.setCell(1, 2, true);
  data.setCell(2, 0, "Steve");
  data.setCell(2, 1, 8000, "$8,000");
  data.setCell(2, 2, false);
  data.setCell(3, 0, "Ellen");
  data.setCell(3, 1, 20000, "$20,000");
  data.setCell(3, 2, true);
  data.setCell(4, 0, "Mike");
  data.setCell(4, 1, 12000, "$12,000");
  data.setCell(4, 2, false);

  var table = new google.visualization.Table(document.getElementById("table_div"));
  table.draw(data, {showRowNumber: true, width: "100%", height: "100%"});

  google.visualization.events.addListener(table, "select", function() {
    var row = table.getSelection()[0].row;
    alert("You selected " + data.getValue(row, 0));
  });
}
</script>
 </head>
 <body>
  <div id="table_div"></div>
 </body>
</html>'

SELECT  @sql;
	
    -- Insert statements for procedure here
	
END

GO
USE [master]
GO
ALTER DATABASE [SalesDB] SET  READ_WRITE 
GO
