CREATE DATABASE BankDB
GO

USE BankDB
GO

CREATE TABLE Customer
(
	AccountNo	int	PRIMARY KEY	IDENTITY(10000, 1)
	,FirstName	varchar(50)		NOT NULL
	,LastName	varchar(50)		NULL
	,Address	varchar(150)	NOT NULL
	,Email		varchar(300)	NOT NULL
)