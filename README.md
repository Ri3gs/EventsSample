# EventsSample

Create db for this demo with following script:

```sql
USE master;
GO

IF DB_ID (N'EventsSample1') IS NULL
CREATE DATABASE EventsSample1;
GO

Use EventsSample1;
Go

CREATE TABLE [dbo].Events(
	[Id] [uniqueidentifier] NOT NULL,
	[Division] [int] NOT NULL,
	[Payload] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```
