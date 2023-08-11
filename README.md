# Design Pattern Practical	

## Explanation

Here I am Implemented 6 Design Pattern which are listed below

* Factory Design Pattern
* Abstract Factory Design Pattern
* Repository Design Pattern
* Mediator Desing Pattern
* CQRS Design Pattern
* Singleton Desing Pattern

How to Run Application

* Here i Used the ADO .net so you have to run the script file which are porvided inside a API Project  

![image](https://github.com/AbhiSimform/DesignPatternsPracticals/assets/125336138/cc8e1fb6-a556-481f-b798-e643b32042f1)

* here you can see the DatabaseQueryFile.sql  which you have to run in SSMS or any other editor

* After creating database you need to update the connection string acccoding to your PC.

![image](https://github.com/AbhiSimform/DesignPatternsPracticals/assets/125336138/631e6cbc-0d2c-489e-8426-cec0f87849cd)

* Here you have to replace the connection string.

* now you are good to go.

## Project Explanation

Basically we have to do the CRUD operation with every single design pattern which are mention below.

### Singleton Design Pattern

Inside that i have the one class which are required for database operation.

for this practical we also have to make the logger which are made inside a API project in which you can find it!

as said in Practical we have to register database management class as Deffered loading so that i register as Scoped and Logger Register as a Singleton.

### Factory and Abstract Factory Design Pattern

here we have to made functionality like we have to find the Hourly based payment according to Depatment. and we can find department by employee Id.

Here for that we have to take the two values one is employeeId and one is Hours. based on hours we have to send the total pay.

### Mediator Design Pattern

Here i made 5 class which are shows the type of request and five Request handler class which are handle request and update the database using the employee Repository..

For implementing this I Used the MediatR Library which are using the Mediator and CQRS design pattern in backend.

### Repository Design Pattern

This is nothing but one abstraction layer on database class so any one can not access directly the database related class.

### CQRS Design Pattern 

In this design pattern we separate the read and write operations like we use the command ( Create, Update and Delete ) and Query ( Read ).

