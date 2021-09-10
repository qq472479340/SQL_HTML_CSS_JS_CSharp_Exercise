--1
Select ProductID, Name, Color, ListPrice
From Production.Product

--2
Select ProductID, Name, Color, ListPrice
From Production.Product
Where ListPrice = 0

--3
Select ProductID, Name, Color, ListPrice
From Production.Product
Where Color is null

--4
Select ProductID, Name, Color, ListPrice
From Production.Product
Where Color is not null

--5
Select ProductID, Name, Color, ListPrice
From Production.Product
Where Color is not null and ListPrice>0

--6
Select Name+' '+Color
From Production.Product
Where Color is not null

--7
Select 'NAME: '+ Name + ' -- COLOR: ' + Color as 'Name And Color'
From Production.Product
Where Color is not null

--8
Select ProductID, Name
From Production.Product
Where ProductID between 400 and 500

--9
Select ProductID, Name, Color
From Production.Product
Where Color in ('Black', 'Blue')

--10
Select Name
From Production.Product
Where Name like 'S%'

--11
Select Name, ListPrice
From Production.Product
Order by Name

--12
Select Name, ListPrice
From Production.Product
Where Name like '[A, S]%'
Order by Name

--13
Select Name
From Production.Product
Where Name like 'SPO[^K]%'
Order by Name

--14
Select distinct Color
From Production.Product
Order by Color DESC

--15
Select distinct ProductSubcategoryID, Color
From Production.Product
Where ProductSubcategoryID is not null and Color is not null
Order by ProductSubcategoryID, Color

--16
Select ProductSubcategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
From Production.Product
Where Color in ('Red','Black') and ProductSubcategoryID = 1 or ListPrice between 1000 and 2000
Order by ProductID
