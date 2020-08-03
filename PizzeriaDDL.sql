CREATE DATABASE PizzeriaService;
GO

use PizzeriaService;

GO

DROP TABLE IF EXISTS tblPizza;
DROP TABLE IF EXISTS tblOrder;
DROP TABLE IF EXISTS tblPizzaOrder;


 CREATE TABLE tblPizza (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PizzaName varchar(50),
	Price decimal,
	 
);

 
 CREATE TABLE tblOrder (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    OrderDateTime date,
	CustomerJMBG varchar(50),
    OrderStatus varchar(50)   

);


 CREATE TABLE tblPizzaOrder (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Amount int,
    OrderID int FOREIGN KEY REFERENCES tblOrder(ID) ON DELETE CASCADE,
	PizzaID int FOREIGN KEY REFERENCES tblPizza(ID) ON DELETE CASCADE

);


INSERT INTO tblPizza values('Capricciosa',15);
INSERT INTO tblPizza values('Napolitana',12);
INSERT INTO tblPizza values('Quatro stagioni',14);