CREATE TABLE [dbo].[Orders] (
    [IdOrder]    INT        NOT NULL,
    [IdCustomer] INT        NULL,
    [Date]       NCHAR (10) NULL,
    [Time]       NCHAR (10) NULL,
    [Price]      NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([IdOrder] ASC)
);

