--1. top 3 products from every city with maximum sale
select dt1.ProductName, dt1.City, dt1.MaxSale, dt1.rnk
from
(select dt.ProductName, dt.City, dt.MaxSale, DENSE_RANK() over(partition by dt.city order by dt.MaxSale desc) as rnk
from
(select p.ProductID, p.ProductName, c.City, count(o.OrderID) as MaxSale
from [Order Details] od
inner join Orders o
on od.OrderID = o.OrderID
inner join Products p
on od.ProductID = p.ProductID
inner join Customers c
on c.CustomerID = o.CustomerID
group by c.City, p.ProductID, p.ProductName) dt) dt1
where dt1.rnk <= 3


--2.
Declare @tmp table
( destination nvarchar(max),
  distance int)

Insert @tmp
(destination, distance)
values ('A', 0),('B', 20),('C', 50),('D', 70),('E', 85)
;


with tmpCTE
as
(select destination, distance, DENSE_RANK() over(order by distance) rnk
from @tmp),
tmpCTE1
as
(select destination, destination as FtoD, distance, distance as distance1, rnk
from tmpCTE
where distance = 0
union all
select ct.destination, ct.destination+'-'+ct1.destination, ct.distance, ct.distance-ct1.distance, ct.rnk
from tmpCTE ct inner join tmpCTE1 ct1
on ct.rnk - ct1.rnk = 1)

select FtoD as Destination, distance1 as Distance from tmpCTE1 where distance != 0