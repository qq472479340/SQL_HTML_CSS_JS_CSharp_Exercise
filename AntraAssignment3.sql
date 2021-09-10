--1. I prefer to use joins rather than subqueries, since join have the faster execute time than subqueries.

--2. CTE is Common Table Expression. We use it when we need to write recursive queries.

--3. A table variable is a data type that canbe used within a Transact-SQL batch, stored procedure, or function. Their scope is within the batch. They are created in tempdb.

--4. Truncate reseeds identity values, whereas delete doesn't.
--   Truncate removes all records and doesn't fire triggers.
--   Truncate is faster compared to delete as it makes less use of the transaction log.
--   Truncate is not possible when a table is referenced by a Foreign Key or tables are used in replication or with indexed views.

--5. An identity column is a column in a database table that is made up of values generated by the database. Truncate reseeds identity values, whereas delete doesn't.

--6. The Delete statement removes rows one at a time and records an entry in the transaction log for each deleted row.
--   Truncate table removes the data by deallocating the data pages used to store the table data and records only the page deallocations in the transaction log.
--   The Delete statement could use Where clause to choose the delete rows, while the Truncate will remove all rows from the table.


--1
Select City
From dbo.Employees
Union
Select City
From dbo.Customers

--2
--a
Select distinct City
From dbo.Customers
Where City not in (Select City From dbo.Employees)

--b
Select City
From dbo.Customers
Except
Select City
From dbo.Employees

--3
Select p.ProductName, sum(od.Quantity)
From dbo.[Order Details] od right join dbo.Products p
On od.ProductID = p.ProductID
Group by od.ProductID, p.ProductName

--4
Select c.City, sum(od.Quantity)
From dbo.Customers c inner join dbo.Orders o
On c.CustomerID = o.CustomerID
Inner join dbo.[Order Details] od
On o.OrderID = od.OrderID
Group by c.City

--5???
--a
Select City
From dbo.Customers
Group by City
Having count(CustomerID) > 1

--b
Select City
From dbo.Customers
Group by City
Having count(CustomerID) > 1

--6
Select c.City
From dbo.[Order Details] od inner join dbo.Orders o
On od.OrderID = o.OrderID
inner join dbo.Customers c
On o.CustomerID = c.CustomerID
Group by c.City
Having count(distinct od.ProductID) > 1

--7
Select distinct c.ContactName
From dbo.Customers c inner join dbo.Orders o
On c.CustomerID = o.CustomerID
Where c.City != o.ShipCity

--8
with tmpPN
as
(Select top 5 p.ProductName, p.ProductID
From dbo.[Order Details] od inner join dbo.Products p
On od.ProductID = p.ProductID
Group by p.ProductID, p.ProductName
Order by sum(od.Quantity) desc),
tmpCTE
as
(Select dt.ProductID, dt.ProductName, c.City, sum(od.Quantity) as CitySum
From dbo.[Order Details] od inner join tmpPN dt
On od.ProductID = dt.ProductID
Inner join dbo.Orders o
On o.OrderID = od.OrderID
Inner join dbo.Customers c
On c.CustomerID = o.CustomerID
Group by dt.ProductID, dt.ProductName, c.City),
tmpRST
as
(Select t.ProductID, t.ProductName, t.City, DENSE_RANK() over(partition by t.ProductName order by t.CitySum desc) rnk
From tmpCTE t)

Select r.ProductName, dt.AvgPrice, r.City
From tmpRST r inner join
(Select r.ProductID, avg(od.UnitPrice) as AvgPrice
From tmpRST r inner join dbo.[Order Details] od
On r.ProductID = od.ProductID
Group by r.ProductID) dt
on r.ProductID = dt.ProductID
Where r.rnk = 1

--9
--a
Select City
From dbo.Employees
Where City not in
(Select c.City
From dbo.Orders o inner join dbo.Customers c
On o.CustomerID = c.CustomerID)

--b
Select City
From dbo.Employees
Except
Select c.City
From dbo.Orders o inner join dbo.Customers c
On o.CustomerID = c.CustomerID

--10
Select t1.SoldCity, t2.OrderCity
From
(Select top 1 e.City as SoldCity
From dbo.Orders o inner join dbo.Employees e
On o.EmployeeID = e.EmployeeID
Group by e.City
Order by count(o.OrderID) desc) t1
cross join
(Select top 1 c.City as OrderCity
From dbo.Orders o inner join dbo.Customers c
On o.CustomerID = c.CustomerID
Inner join dbo.[Order Details] od
On o.OrderID = od.OrderID
Group by c.City
Order by sum(od.Quantity) desc) t2

--11. By using Distinct.

--    Select Distinct col
--    From t

--12
Select empid
From Employee
Except
Select mgrid
From Employee

--13
with tmpCTE
as
(Select d.deptname, count(e.empid) as EmpNum
From Employee e inner join Dept d
On e.deptid = d.deptid
Group by d.deptid, d.deptname),
tmpRNK
as
(Select c.deptname, c.EmpNum, DENSE_RANK() over(order by c.EmpNum desc) rnk
From tmpCTE c)

Select r.deptname, r.EmpNum
From tmpRNK r
Where r.rnk = 1
Order by r.deptname

--14
Select dt.deptname, dt.empid, dt.salary
From
(Select d.deptname, e.empid, e.salary, DENSE_RANK() over(partition by d.deptid order by e.salary desc) rnk
From Employee e inner join Dept d
On e.deptid = d.deptid) dt
Where dt.rnk <= 3
Order by dt.deptname, dt.salary desc