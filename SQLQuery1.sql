/*CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [BrandName] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Colors]
(
	[ColorId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ColorName] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [BrandId] INT NULL,
	[ColorId] INT NULL,
	[ModelYear] INT,
	[DailyPrice] DECIMAL,
	[Description] NVARCHAR(50)
	CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
	CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
)*/

INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Description)
VALUES 
	(1,1,'2010','150','Manuel'),
	(2,2,'2015','185','Manuel'),
	(3,3,'2018','200','Otomatik'),
	(4,4,'2019','350','Otomatik');

INSERT INTO Colors(ColorName) 
VALUES
	('Beyaz'),
	('Siyah'),
	('Kırmızı');
INSERT INTO Brands(BrandName) 
VALUES
	('Mercedes'),
	('BMW'),
	('Renault');

SELECT * FROM Cars
SELECT * FROM Colors
SELECT * FROM Brands
