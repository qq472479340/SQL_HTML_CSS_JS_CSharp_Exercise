--1. An object in sql could be table, view, stored procedure, functions, index etc.

--2. An index is an on-disk structure associated with a table or view that speeds retrieval of rows from the table or view
--   Advantages: 
--   a. searches become faster
--   b. it could maintain a sorting result
--   c. we could have an unique column to identify the data.
--   Disadvantages:
--   a. need additional disk space
--   b. the operations of insert, update and delete become slower.

--3. Clustered Index, Non-Clustered Index

--4. Yes.
--   When you create a PRIMARY KEY constraint, a unique clustered index on the column or columns is automatically created if a clustered index on the table does not already exist and you do not specify a unique nonclustered index.
--   When you create a UNIQUE constraint, a unique nonclustered index is created to enforce a UNIQUE constraint by default. You can specify a unique clustered index if a clustered index on the table does not already exist.

--5. No. Because the data will be sorted based on their index values, and they can only be stored in one order.

--6. Yes. The order is matter.

--7. Yes.

--8. Database Normalization is a process of organizing data to minimize redundancy (data duplication), which in turn ensures data consistency. 
--   1NF-2NF-3NF-BCNF

--9. Denormalization is a strategy that database managers use to increase the performance of a database infrastructure. 
--   It involves adding redundant data to a normalized database to reduce certain types of problems with database queries that combine data from various tables into a single table.

--10. We can use constrains on the data such as Primary Key, Unique Key, Not Null and add Foreign Key between tables.

--11. Not Null, Unique, Primary Key, Foreign Key, Check

--12. a. Only one Primary Key in a table but could have multiple Unique Keys.
--    b. Primary Key does not accept null value, but Unique Key accept one null value per column.
--    c. Primary Key will automatically add clustered index but Unique Key will add non-clustered index.

--13. A foreign key (FK) is a column or combination of columns that is used to establish and enforce a link between the data in two tables.

--14. Yes.

--15. It doesn't have to be unique and it could be null.

--16. We can create indexes on temporary tables. For table variables, indexes can only be created implicitly when add Primary Key or Unique Key constrains.

--17. Transactions by definition are a logical unit of work. Transaction is a single recoverable unit of work that executes either Completely or Not at all.
--    Read Uncommitted, Read Committed, Repeatable Read, Serializable

--1.
Create table customer(cust_id int,  iname varchar (50))
create table order(order_id int,cust_id int,amount money,order_date smalldatetime)

select c.iname, count(o.orderid)
from customer c join order o
on c.cust_id = o.cust_id
where DATEPART(yy, o.order_date) = 2002
Group by c.cust_id, c.iname

--2.
Create table person (id int, firstname varchar(100), lastname varchar(100))

select firstname, lastname
from person
where lastname like 'A%'

--3.
Create table person(person_id int primary key, manager_id int null, name varchar(100)not null)

select p.name, dt.totalNum
from person p join
(select manager_id, count(person_id) as totalNum
from person
where manager_id in
(select person_id
from person
where manager_id is null)
group by manager_id) dt
on p.person_id = dt.manager_id

--4. Insert, Update, Delete

--5. company(id int PK, name char(20))
--   division(id int PK, co_id int FK references company(id) , name char(20), loc_id int FK references location(id))
--   location(id int PK, detail char(100))
--   contact(suit/mail drop PK, div_id int FK references division(id), name char(20))