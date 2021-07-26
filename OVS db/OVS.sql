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