-- 1. A result set is the result table that be shown after executing the SQL statement.

-- 2. Union will remove all the duplicate result from the result set, but Union All will keep all the duplicate data in the result set.

--3. Union, Union All, Intersect, Except

--4. Union combines two result tables which are from two queries to one result set. Join allows the user to retrieve the data from multiple tables based on their relationships. And Union can only combine the tables with same schema.

--5. Inner Join will only show the results which have a match in both left table and right table. But Full Join will show all rows in both left and right table. If there is no match for a row, it will be shown as null values in the select columns of the other table.

--6. The result set of Left Join includes all rows in left table but not the right table. If there is no match for a row in right table, the select columns of right table will be shown as null values.
--   But Full Outer Join will show all rows in both left and right table. If there is no match for a row, it will be shown as null values in the select columns of the other table.

--7. Cross Join returns the Cartesin product of the left and right table. It equates to the Inner Join with the condition always be true.

--8. The Having clause is used after the Group By clause and it will qualify the aggregated data after the data has been grouped or aggregated.
--   The Where clause is used before the Group By clause and it will filter the rows before the data is grouped or aggregated.

--9. Yes, there can be multiple group by columns.


use AdventureWorks2019
go

--1
Select count(ProductID)
From Production.Product

--2
Select count(ProductSubcategoryID)
From Production.Product

--3
Select ProductSubcategoryID, count(ProductID) as CountedProducts
From Production.Product
Group by ProductSubcategoryID

--4
Select count(1)
From Production.Product
Where ProductSubcategoryID is null

--5
Select sum(Quantity)
From Production.ProductInventory

--6
Select ProductID, sum(Quantity) as TheSum
From Production.ProductInventory
Where LocationID = 40
Group by ProductID
Having sum(Quantity) < 100

--7
Select Shelf, ProductID, sum(Quantity) as TheSum
From Production.ProductInventory
Where LocationID = 40
Group by ProductID, Shelf
Having sum(Quantity) < 100

--8
Select avg(Quantity)
From Production.ProductInventory
Where LocationID = 10

--9
Select ProductID, Shelf, avg(Quantity) as TheAvg
From Production.ProductInventory
Group by Shelf, ProductID

--10
Select ProductID, Shelf, avg(Quantity) as TheAvg
From Production.ProductInventory
Where Shelf != 'N/A'
Group by Shelf, ProductID

--11
Select Color, Class, count(1) as TheCount, avg(ListPrice) as AvgPrice
From Production.Product
Where Color is not null and Class is not null
Group by color, Class

--12
Select c.Name as Country, s.Name as Province
From Person.CountryRegion c full join Person.StateProvince s
On c.CountryRegionCode = s.CountryRegionCode

--13
Select c.Name as Country, s.Name as Province
From Person.CountryRegion c full join Person.StateProvince s
On c.CountryRegionCode = s.CountryRegionCode
Where c.Name in ('Germany', 'Canada')

Use Northwind
go

--14
Select distinct p.ProductName
From dbo.Products p inner join dbo.[Order Details] od
On p.ProductID = od.ProductID
Inner join dbo.Orders o
On od.OrderID = o.OrderID
Where o.OrderDate > '1996-07-14'

--15
Select top 5 ShipPostalCode
From dbo.Orders
Group by ShipPostalCode
Order by count(OrderID) desc

--16
Select top 5 ShipPostalCode
From dbo.Orders
Where OrderDate > '2001-07-14'
Group by ShipPostalCode
Order by count(OrderID) desc

--17
Select City, count(CustomerID)
From dbo.Customers
Group by City

--18
Select City, count(CustomerID)
From dbo.Customers
Group by City
Having count(CustomerID) > 10

--19
Select c.ContactName, o.OrderDate
From dbo.Orders o inner join dbo.Customers c
On o.CustomerID = c.CustomerID
Where o.OrderDate > '1998-01-01'

--20
Select c.ContactName, max(o.OrderDate) as MostRecentDate
From dbo.Orders o left join dbo.Customers c
On o.CustomerID = c.CustomerID
Group by c.ContactName

--21
Select c.ContactName, count(o.OrderDate) as CountProduct
From dbo.Orders o left join dbo.Customers c
On o.CustomerID = c.CustomerID
Group by c.ContactName

--22
Select c.ContactName, count(o.OrderDate) as CountProduct
From dbo.Orders o left join dbo.Customers c
On o.CustomerID = c.CustomerID
Group by c.ContactName
Having count(o.OrderDate) > 100

--23
Select su.CompanyName as [Supplier Company Name], sh.CompanyName as [Shipping Company Name]
From dbo.Suppliers su cross join dbo.Shippers sh

--24
Select p.ProductName, o.OrderDate
From dbo.Orders o
Inner join dbo.[Order Details] od
On o.OrderID = od.OrderID
Inner join dbo.Products p
On od.ProductID = p.ProductID
Order by o.OrderDate

--25
Select e1.FirstName + ' ' + e1.LastName as Name1, e2.FirstName + ' ' + e2.LastName as Name2
From dbo.Employees e1 inner join dbo.Employees e2
On e1.Title = e2.Title
Where e1.FirstName + ' ' + e1.LastName != e2.FirstName + ' ' + e2.LastName

--26
Select e.FirstName + ' ' + e.LastName as ManagerName
From (Select e1.ReportsTo
	  From dbo.Employees e1
	  Group by e1.ReportsTo
	  Having count(e1.EmployeeID) > 2) e2
Inner join dbo.Employees e
On e2.ReportsTo = e.EmployeeID

--27
Select a.City, a.Name, a.ContactName, a.Type
From (Select City, CompanyName as Name, ContactName, 'Customer' as Type
      From dbo.Customers
      Union
      Select City, CompanyName as Name, ContactName, 'Suppllier' as Type
      From dbo.Suppliers) a
Order by a.City

--28
Select a.c1, b.c2
From F1.T1 a inner join F2.T2 b
On a.c1 = b.c2

-- The result set will be:
--c1 c2
---- --
--2  2
--3  3

--29
Select a.c1, b.c2
From F1.T1 a left join F2.T2 b
On a.c1 = b.c2

-- The result set will be
--c1 c2
---- --
--1  null
--2  2
--3  3
