USE AdventureWorks2014
GO

--Query 1 Select a person's full name
SELECT FirstName, MiddleName, LastName 
FROM Person.Person


--Query 2 Select vendors who are not preferred
SELECT name, AccountNumber
FROM Purchasing.Vendor
WHERE PreferredVendorStatus = 0


--Query 3 Select product names of products with a list price greater than 1000 and a size of 48
SELECT Name
FROM Production.Product
WHERE ListPrice>1000 AND Size=48

--Query 4 Select product names and numbers for all red products that are of class M
select name, ProductNumber
FROM Production.Product
WHERE Color='Red' AND Class ='M'

--Query 5 Select all customer names, surnames and account numbers
SELECT FirstName,LastName,AccountNumber
FROM Person.Person inner join Sales.Customer
on Person.Person.BusinessEntityID = Sales.Customer.CustomerID

--Query 6 Select all person phone numbers that start with 999
SELECT PhoneNumber 
FROM Person.PersonPhone 
WHERE PhoneNumber like '999%'

--Query 7 Show the average list price of bike sub categories
SELECT Production.ProductSubcategory.Name, AVG(Production.Product.ListPrice) AS [Average List Price]
FROM Production.Product INNER JOIN Production.ProductSubcategory
ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID
GROUP BY Production.ProductSubcategory.Name
HAVING Production.ProductSubcategory.Name like '%bike%'
ORDER BY [Average List Price]

create index idxFullName
on person.person (FirstName,MiddleName,LastName);
go


create index idxPurchasingVendor
on purchasing.Vendor ( accountNumber, name, preferredVendorStatus);
go 

create index idxProduct
on production.product (name, productnumber, ListPrice, size, color, class, productsubcategoryid );
go

create index idxCustomer
on sales.customer ( customerId, personId, accountnumber);
go 

CREATE INDEX idxSubCategory
on production.productSubcategory (name, ProductsubcategoryId);
go 