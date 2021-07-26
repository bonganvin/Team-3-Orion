Use Master -- Using the master database management system to "manage" our database
Go -- The "Go" command basically means "run" or "execute" the instructions provided
If Exists (Select * from sys.databases where name = 'Example') -- Checking if the database exists. If it exists in the system databases, then the database is "dropped"
DROP DATABASE Example --  Dropping means "remove from memory" so that is not available. The SQL Engine and Worker can't use the database anymore.
Go 
Create Database Example -- Now we are "creating" the database. In other words we are dedicating memory, storage and processing to the instance of the database.
Go

Use Example
Go

/* Create Table 1 */
CREATE TABLE ExampleTable1 -- Parent Entity
(
ExampleTable1_ID int Identity (1,1) Primary Key Not Null,	--  Here we are creating our first key. The key starts at 1, and each time a new record is added you add another 1. 
ExampleTable1_Attribute1 varchar (255) not null,			-- Attribute name, datatype of the attribute, and the number of characters that can be stored in the attribute. 
ExampleTable1_Attribute2 varchar (255) not null,			-- Not Null means that the value should have data. It cannot be instantiated without data
ExampleTable1_Attribute3 varchar (255) not null,			-- A PK should always be "not null" as it is mandatory
ExampleTable1_Attribute4 varchar (255)	 
)
GO


/* Create Table 2 */
CREATE TABLE ExampleTable2  -- Parent Entity
(
ExampleTable2_ID int Identity (1,1) Primary Key Not Null,
ExampleTable2_Attribute1 varchar (255) not null,
ExampleTable2_Attribute2 varchar (255) not null,
ExampleTable2_Attribute3 varchar (255) not null,
ExampleTable2_Attribute4 varchar (255) not null
)
GO

/* Create Table 3 */
CREATE TABLE ExampleTable3 -- Associative entity. In this case the "child" entity.
(
/* ExampleTable3_ID int Identity (1,1) Primary Key Not Null, -- May or may not have it's own PK */
ExampleTable1_ID int references ExampleTable1(ExampleTable1_ID), -- PKFK1 from Table1 (part of composite key)
ExampleTable2_ID int references ExampleTable2(ExampleTable2_ID), -- PKFK2 from Table2 (part of composite key)
ExampleTable3_Attribute1 varchar (255) not null,
ExampleTable3_Attribute2 varchar (255) not null,
ExampleTable3_Attribute3 varchar (255) not null,
ExampleTable3_Attribute4 varchar (255) not null
)
GO

/* It is very important to note that data is inserted in the sequence of the attributes of the table into which data is inserted */
/*Insert into ExampleTable1*/
insert into ExampleTable1 values ('Table1 Attribute1 Row1','Table1 Attribute2 Row1','Table1 Attribute3 Row1','Table1 Attribute3 Row1')
insert into ExampleTable1 values ('Table1 Attribute1 Row2','Table1 Attribute2 Row2','Table1 Attribute3 Row2','Table1 Attribute3 Row2')
insert into ExampleTable1 values ('Table1 Attribute1 Row3','Table1 Attribute2 Row3','Table1 Attribute3 Row3','Table1 Attribute3 Row3')
insert into ExampleTable1 values ('Table1 Attribute1 Row4','Table1 Attribute2 Row4','Table1 Attribute3 Row4','Table1 Attribute3 Row4')

/*Insert into ExampleTable2*/
insert into ExampleTable2 values ('Table2 Attribute1 Row1','Table2 Attribute2 Row1','Table2 Attribute3 Row1','Table2 Attribute3 Row1')
insert into ExampleTable2 values ('Table2 Attribute1 Row2','Table2 Attribute2 Row2','Table2 Attribute3 Row2','Table2 Attribute3 Row2')
insert into ExampleTable2 values ('Table2 Attribute1 Row3','Table2 Attribute2 Row3','Table2 Attribute3 Row3','Table2 Attribute3 Row3')
insert into ExampleTable2 values ('Table2 Attribute1 Row4','Table2 Attribute2 Row4','Table2 Attribute3 Row4','Table2 Attribute3 Row4')

/*Insert into ExampleTable3*/
insert into ExampleTable3 values ('1','1','Table3 Attribute1 Row1','Table3 Attribute2 Row1','Table3 Attribute3 Row1','Table3 Attribute3 Row1')
insert into ExampleTable3 values ('1','2','Table3 Attribute1 Row2','Table3 Attribute2 Row2','Table3 Attribute3 Row2','Table3 Attribute3 Row2')
insert into ExampleTable3 values ('1','3','Table3 Attribute1 Row3','Table3 Attribute2 Row3','Table3 Attribute3 Row3','Table3 Attribute3 Row3')
insert into ExampleTable3 values ('2','3','Table3 Attribute1 Row4','Table3 Attribute2 Row4','Table3 Attribute3 Row4','Table3 Attribute3 Row4')