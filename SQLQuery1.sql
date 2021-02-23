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
    [DailyPrice]   MONEY NULL,
    [Description] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId])
);

CREATE TABLE [dbo].[Users] (
    [UserId]   INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
	[LastName] NVARCHAR (50) NULL,
	[Email] NVARCHAR (50) NULL,
	[Password] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [CustomerId]   INT           IDENTITY (1, 1) NOT NULL,
	[UserId]      INT           NULL,
    [CompanyName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT           IDENTITY (1, 1) NOT NULL,
	[Id]      INT           NULL,
	[CustomerId]      INT           NULL,
    [RentDate] DATETIME NULL,
	[ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
	FOREIGN KEY ([Id]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
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

INSERT INTO Users(FirstName,LastName,Email,Password) VALUES
	('Esra','Şahinler','esrasahinler@gmail.com','123456'),
	('Ceren','Esirgenci','cerenesirgenci@gmail.com','465789'),
	('Onur','Erikçi','onurerikci@gmail.com','987654');

INSERT INTO Customers(UserId,CompanyName) VALUES
	('1','Kara cuma'),
	('2','Büyük fırsat');

INSERT INTO Rentals(Id,CustomerId,RentDate,ReturnDate) VALUES
	(1,'1',2013-02-13,2013-02-15),
	(2,'2',2017-03-12,2017-03-18);

    Select * From Cars
    Select * From Colors
    Select * From Brands
	Select * From Users
	Select * From Customers
	Select * From Rentals