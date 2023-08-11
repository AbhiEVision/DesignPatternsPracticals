CREATE DATABASE DesignPatterns
GO

USE DesignPatterns
GO

CREATE TABLE tblDepartement(
	DepartmentId INT IDENTITY PRIMARY KEY,
	DepartmentName VARCHAR(50) NOT NULL UNIQUE
)
GO

INSERT INTO tblDepartement VALUES ('IT'),('Admin'),('HR'),('Sales'),('On-Site')
GO

CREATE TABLE tblStatus(
	StatusId INT IDENTITY PRIMARY KEY,
	StatusName VARCHAR(50) NOT NULL UNIQUE
)
GO

INSERT INTO tblStatus VALUES ('Register'),('Interview'),('Employee')
GO

CREATE TABLE tblEmployee(
	EmployeeId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(100) NOT NULL,
	Salary MONEY NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES tblDepartement ( DepartmentId ) ON DELETE SET NULL,
	EmailAddress VARCHAR(256) NOT NULL UNIQUE,
	JoiningDate DATE DEFAULT GETDATE() NOT NULL,
	StatusId INT DEFAULT 1 FOREIGN KEY REFERENCES tblStatus ( StatusId ) ON DELETE SET NULL,
	isActive BIT NOT NULL DEFAULT 1
)
GO

INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) VALUES ( 'Abhi', 123.12, 1, 'abhi@gmail.com')
INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) VALUES ( 'Jil', 123.12, 2, 'jil@gmail.com')
INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) VALUES ( 'Jay', 123.12, 3, 'jay@gmail.com')
INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) VALUES ( 'Bhavin', 123.12, 4, 'bhavin@gmail.com')
INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) VALUES ( 'Parthiv', 123.12, 5, 'parthiv@gmail.com')
GO