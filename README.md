# EventsSample

Create db for this demo with following script:

```sql
USE master;
GO

IF DB_ID (N'EventsSample') IS NULL
CREATE DATABASE EventsSample;
GO

Use EventsSample;
Go

CREATE TABLE [dbo].Events(
	[Id] [uniqueidentifier] NOT NULL,
	[Division] [int] NOT NULL,
	[Payload] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```
