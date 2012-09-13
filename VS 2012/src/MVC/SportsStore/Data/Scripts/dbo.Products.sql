CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100)  NOT NULL,
    [Description] NVARCHAR (500)  NOT NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    [Category]    NVARCHAR (50)   NOT NULL,
    [ImageData] VARBINARY(MAX) NULL, 
    [ImageMIMEType] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

