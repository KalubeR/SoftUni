/*
   02 февруари 2019 г.13:43:24
   User: 
   Server: KALUBER\SQLEXPRESS
   Database: SoftUni
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.ItemTypes
	(
	ItemTypeID int NOT NULL,
	Name varchar(50) NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.ItemTypes ADD CONSTRAINT
	PK_ItemTypes PRIMARY KEY CLUSTERED 
	(
	ItemTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.ItemTypes SET (LOCK_ESCALATION = TABLE)

COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.Items
	(
	ItemID int NOT NULL,
	Name varchar(50) NOT NULL,
	ItemTypeID int NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Items ADD CONSTRAINT
	PK_Items PRIMARY KEY CLUSTERED 
	(
	ItemID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.Items ADD CONSTRAINT
	FK_Items_ItemTypes FOREIGN KEY
	(
	ItemTypeID
	) REFERENCES dbo.ItemTypes
	(
	ItemTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.Items SET (LOCK_ESCALATION = TABLE)

COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.Cities
	(
	CityID int NOT NULL,
	Name varchar(50) NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Cities ADD CONSTRAINT
	PK_Cities PRIMARY KEY CLUSTERED 
	(
	CityID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.Cities SET (LOCK_ESCALATION = TABLE)

COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.Customers
	(
	CustomerID int NOT NULL,
	Name varchar(50) NOT NULL,
	Birthday date NOT NULL,
	CityID int NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Customers ADD CONSTRAINT
	PK_Customers PRIMARY KEY CLUSTERED 
	(
	CustomerID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.Customers ADD CONSTRAINT
	FK_Customers_Cities FOREIGN KEY
	(
	CityId
	) REFERENCES dbo.Cities
	(
	CityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.Customers SET (LOCK_ESCALATION = TABLE)

COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.Orders
	(
	OrderID int NOT NULL,
	CustomerID int NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.Orders ADD CONSTRAINT
	PK_Orders PRIMARY KEY CLUSTERED 
	(
	OrderID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.Orders ADD CONSTRAINT
	FK_Orders_Customers FOREIGN KEY
	(
	CustomerID
	) REFERENCES dbo.Customers
	(
	CustomerID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.Orders SET (LOCK_ESCALATION = TABLE)

COMMIT
BEGIN TRANSACTION

CREATE TABLE dbo.OrderItems
	(
	OrderID int NOT NULL,
	ItemID int NOT NULL
	)  ON [PRIMARY]

ALTER TABLE dbo.OrderItems ADD CONSTRAINT
	PK_OrderItems PRIMARY KEY CLUSTERED 
	(
	OrderID,
	ItemID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


ALTER TABLE dbo.OrderItems ADD CONSTRAINT
	FK_OrderItems_Orders FOREIGN KEY
	(
	OrderID
	) REFERENCES dbo.Orders
	(
	OrderID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.OrderItems ADD CONSTRAINT
	FK_OrderItems_Items FOREIGN KEY
	(
	ItemID
	) REFERENCES dbo.Items
	(
	ItemID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	

ALTER TABLE dbo.OrderItems SET (LOCK_ESCALATION = TABLE)

COMMIT
