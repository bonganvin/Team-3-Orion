Use Master
Go

If Exists (Select * from sys.databases where name = 'OVS')
ALTER DATABASE OVS
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE OVS
Go
Create Database OVS
Go

create table Employee_Type(
Employee_Type_ID int identity(1,1) primary key not null,
Employee_Type_Description varchar(100) not null 
)

CREATE TABLE Employee (
Employee_ID int identity(1,1) primary key not null,
Employee_Name varchar(30) not null,
Employee_Surname varchar(30) not null,
Employee_Contact varchar(13) not null,
Employee_Email_Address varchar(50) not null,
Employee_Type_ID int foreign key references Employee_Type(Employee_Type_ID),
User_ID int foreign key references User(User_ID),
User_Access_Permisson_ID int foreign key references User_Access_Permisson(User_Access_Permisson_ID), 
)

create table Shift_Type(
Shift_Type_ID int identity(1,1) primary key not null,
Shift_Type_Description varchar(100) not null 
)

CREATE TABLE Shift (
Shift_ID int identity(1,1) primary key not null,
Shift_Type_ID int foreign key references Shift_Type(Shift_Type_ID)
)

create table Date(
Date_ID Date primary key not null,
Date_Description datetime not null 
)

create table Time_Slot(
Time_Slot_ID int identity(1,1) primary key not null,
Starting_time time not null, 
Ending_time time not null, 
)

CREATE TABLE Branch (
Branch_ID int identity(1,1) primary key not null,
Branch_Name varchar(50) not null,
Branch_Location_Storage_Capacity int not null,
Branch_Address varchar(50) not null, 
)

Create table Date_Time_Slot (
Shift_ID int references Shift(Shift_ID),
Time_Slot_ID int references Time_Slot(Time_Slot_ID),
Date_ID int references Date (Date_ID)
)

CREATE TABLE Cash_Register  (
Register_ID int identity(1,1) primary key not null,
Cash_Register_Name varchar(250) not null,
Branch_ID int foreign key references Branch(Branch_ID)
)

CREATE TABLE Shift_Branch ( 
Shift_ID int references Shift(Shift_ID),
Branch_ID int references Branch(Branch_ID)
)

CREATE TABLE Shift_Branch_Employee ( 
Shift_ID int references Shift(Shift_ID),
Branch_ID int references Branch(Branch_ID),
Employee_ID int references Employee(Employee_ID)
)

Create table Quote_Status
(
Quote_Status_ID int primary key ,
Quote_Status_Description varchar(50)
)

Create table Request_Quote
(
Request_Quote_ID int primary key ,
Date varchar(20),
Quote_Status int references Quote_Status(Quote_Status_ID)
)

Create table Quote_Line
(
Quote_Line_ID int primary key ,
Quantity varchar(50),
Product int references Product(Product_ID),
Request_Quote_ID int references Request_Quote(Request_Quote_ID)
)

Create table Sale_Line
(
Sale_Line_ID int primary key,
Sale int references Sale(Sale_ID),
Product int references Product(Product_ID)
)

Create table Sale
(
Sale_ID int primary key ,
Sale_Date varchar(20),
Request_Quote int references Request_Quote(Request_Quote_ID)
)

Create table Return_Sale_Request
(
Return_Sale_Request_ID int primary key,
Return_Request_Date varchar(20),
Customer int references Customer(Customer_ID)
)


Create table Return_Sale_Request_SaleLine
(
Quantity varchar(5),
Return_Sale_Reason varchar(50),
Return_Sale_Request int references Return_Sale_Request(Return_Sale_Request_ID),
Product int references Product(Product_ID),
Customer int references Customer(Customer_ID),
Sale int references Sale(Sale_ID)
)

Create table Sale_Payment_Status
(
Sale_Payment_Status_ID int primary key,
Sale_Payment_Status_Desc varchar(50)
)

Create table Payment_Type
(
Payment_Type_ID int primary key,
Payment_Type_Description varchar(50),
Payment_Type_Name varchar(20)
)

Create table Sale_Payment
(
Sale_Payment_ID int primary key,
Sale_Payment_Amount varchar(10),
Sale_Payment_Date varchar(20),
Sale_Payment_Name varchar(50),
Sale_Payment_Status int references Sale_Payment_Status(Sale_Payment_Status_ID),
Sale_ID int references Sale(Sale_ID),
Payment_Type_ID int references Payment_Type(Payment_Type_ID))

Create table Order_Payment_Status
(
Order_Payment_Status_ID int primary key,
Order_Payment_Status_Description varchar(50)
)

Create table Order_Payment
(
Order_Payment_ID int primary key,
Order_Payment_Amount varchar(10),
Order_Payment_Date varchar(20),
Customer int references Customer(Customer_ID),
Payment_Type_ID int references Payment_Type(Payment_Type_ID),
Order_Payment_Status int references Order_Payment_Status(Order_Payment_Status_ID),
Order_ID int references Order(Order_ID)
)
