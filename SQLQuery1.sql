CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ColorId] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
	[ModelYear]    INT NULL,
    [DailyPrice]   MONEY (18)  NULL,
    [Description] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);


INSERT INTO Colors(ColorName) VALUES
	('Kırmızı'),
	('Mavi'),
	('Siyah');

INSERT INTO Brands(BrandName) VALUES
	('Fiat'),
	('Hyundai'),
	('Nissan');
	
	
INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Description) VALUES
	('1','1','2013','130','Benzin'),
	('1','2','2015','250','Dizel'),
	('2','1','2017','400','Benzin'),
	('2','2','2019','625','Dizel');

    Select*From Cars
    Select*From Colors
    Select*From Brands