Use Master
Go

If Exists (Select * from sys.databases where name = 'OVS')
ALTER DATABASE OVS
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE OVS
Go
Create Database OVS
Go


Use OVS 
go

Create table User_Access_Permission /****** Access_Permission******/
(User_Access_Permission_ID int primary key identity(1,1) not null,
Role_Name varchar(50),
Role_Description varchar(50)
)

Create table [User]
([User_ID] int primary key identity(1,1),
[User_Password] varchar(12),
[User_Name] varchar(20),
 User_Access_Permission_ID int references User_Access_Permission (User_Access_Permission_ID))


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
User_ID int foreign key references [User](User_ID),
User_Access_Permission_ID int foreign key references User_Access_Permission(User_Access_Permission_ID), 
)

create table Shift_Type(
Shift_Type_ID int identity(1,1) primary key not null,
Shift_Type_Description varchar(100) not null 
)

CREATE TABLE Shift (
Shift_ID int identity(1,1) primary key not null,
Shift_Type_ID int foreign key references Shift_Type(Shift_Type_ID)
)

create table [Date](
Date_ID int primary key not null,
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
Date_ID int references [Date] (Date_ID)
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


Create table Discount 
(Discount_ID int primary key identity(1,1) NOT NULL,
Discount_Description varchar(100))

Create table Customer_Type
(
Customer_Type_ID int primary key identity(1,1),
Customer_Type_Description varchar(50),
 Discount_ID int references Discount(Discount_ID),
)

CREATE TABLE [dbo].[Customer](
	[Customer_ID] int primary key identity(1,1) NOT NULL,
	[Customer_Name] varchar(40) NOT NULL,
	[Customer_Surname] varchar(30) NULL,
	[Customer_Cellphone_Number] varchar(15) NULL,
	[Customer_Date_Of_Birth] Date NULL,
	[Customer_Email_Address] varchar(60) NULL,
	[Customer_Address] varchar(100) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	 Customer_Type_ID int references Customer_Type(Customer_Type_ID),
	  User_ID int references [User](User_ID),
 User_Access_Permission_ID int references User_Access_Permission (User_Access_Permission_ID)
 )

 Create table Cart 
 (
 Cart_ID int primary key identity(1,1),
 User_ID int references [User](User_ID),
 Customer_ID int references Customer(Customer_ID),
 User_Access_Permission_ID int references User_Access_Permission (User_Access_Permission_ID)
 
 )

  Create table Cart_Line 
 (
 Cart_ID int references Cart (Cart_ID),
 --Product_ID int references Product (Product_ID),
 Quantity varchar(15) NULL
 )


  Create Table Order_Status
 (
 Order_Status_ID int primary key identity(1,1),
Order_Status_Description varchar(50) 
 )

 Create table [Order]
 (
 Order_ID int primary key identity(1,1),
 Order_Date Datetime not null,
 Order_Finalizastion_Date Datetime not null,
 Require_Delivery bit not null DEFAULT (0),
 Customer_ID int references Customer(Customer_ID),
 Order_Status_ID int references Order_Status(Order_Status_ID)
 ) 

 Create table Order_Line 
 (
  Customer_ID int references Customer(Customer_ID),
 Order_ID int references [Order](Order_ID),
 --Product_ID int references Product (Product_ID),
  Quantity varchar (50) not null,
 )

 
 Create table Return_Order_Request
 (
 Return_Order_Request_ID int primary key identity(1,1),
 Customer_ID int references Customer(Customer_ID),
 Order_ID int references [Order](Order_ID),
 Request_Order_Date Datetime
 )

 Create table Return_Order_Request_Order_Line
 (
  Customer_ID int references Customer(Customer_ID),
 Order_ID int references [Order](Order_ID),
 --Product_ID int references Product (Product_ID),
 Return_Reason varchar(100) not null ,
 Quantity varchar (50) not null,
 )

 Create Table Credit_Note
 (
  Credit_Note_ID int primary key identity(1,1),
  Customer_ID int references Customer(Customer_ID),
  Return_Order_Request_ID int references Return_Order_Request(Return_Order_Request_ID),

 )


 

