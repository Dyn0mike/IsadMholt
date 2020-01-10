CREATE TABLE [dbo].[Items] (
    [IdItem]   INT             NOT NULL,
    [Catagory] NCHAR (10)      NULL,
    [Name]     NCHAR (10)      NULL,
    [URL]      NCHAR (2083)    NULL,
    [Price]    DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([IdItem] ASC)
);

