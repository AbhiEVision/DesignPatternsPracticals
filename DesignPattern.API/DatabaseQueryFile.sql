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

-- -- Get All EmployeeDetail Query
-- SELECT emp.Name, emp.Salary, dep.DepartmentName, emp.EmailAddress, emp.JoiningDate, sta.StatusName  FROM tblEmployee emp INNER JOIN tblDepartement dep ON dep.DepartmentId = emp.DepartmentId INNER JOIN tblStatus sta ON sta.StatusId = emp.StatusId 

-- -- Get EmployeeDetail Query
-- SELECT emp.Name, emp.Salary, dep.DepartmentName, emp.EmailAddress, emp.JoiningDate, sta.StatusName  FROM tblEmployee emp INNER JOIN tblDepartement dep ON dep.DepartmentId = emp.DepartmentId INNER JOIN tblStatus sta ON sta.StatusId = emp.StatusId where emp.EmployeeId = 1

-- -- Update Employee Data
-- UPDATE tblEmployee SET Name = 'Test', Salary = 132.23, DepartmentId = 1, EmailAddress = '' WHERE EmployeeId = 5

-- select * from tblEmployee

-- -- Soft Delete Employee
-- UPDATE tblEmployee SET isActive = 1 WHERE EmployeeId = 7