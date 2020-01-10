CREATE TABLE [dbo].[ItemsOrdered] (
    [IdOrder]  INT NOT NULL,
    [IdItem]   INT NOT NULL,
    [Quantity] INT NULL,
    PRIMARY KEY CLUSTERED ([IdOrder] ASC, [IdItem] ASC)
);

