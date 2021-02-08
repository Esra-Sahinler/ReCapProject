/*CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY, 
    [BrandName] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Colors]
(
	[ColorId] INT NOT NULL PRIMARY KEY, 
    [ColorName] NVARCHAR(50) NULL
)

CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NULL,
	[ColorId] INT NULL,
	[ModelYear] INT,
	[DailyPrice] DECIMAL,
	[Description] NVARCHAR(50)
	CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
	CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
)*/

INSERT INTO Cars(Id,BrandId,ColorId,ModelYear,DailyPrice,Description)
VALUES 
	(1,1,1,'2010','150','Manuel'),
	(2,2,2,'2015','185','Manuel'),
	(3,3,3,'2018','200','Otomatik'),
	(4,3,2,'2019','350','Otomatik');

INSERT INTO Colors(ColorId,ColorName) 
VALUES
	(1,'Beyaz'),
	(2,'Siyah'),
	(3,'Kırmızı');
INSERT INTO Brands(BrandId,BrandName) 
VALUES
	(1,'Mercedes'),
	(2,'BMW'),
	(3,'Renault');

SELECT * FROM Cars
SELECT * FROM Colors
SELECT * FROM Brands
