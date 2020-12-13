use Inventory


alter procedure spResetProducts
as
BEGIN

drop table if exists products_2
create table products_2
(ProductID int NOT NULL IDENTITY PRIMARY KEY,
ProductName varchar(50) NOT NULL,
CollectionID int,
ProductDesc text Default 'NA',
SKU varchar(10) UNIQUE,
Price int,
)
end

--Adding a new column
Alter table products
add Pages int not null
constraint Pages_Default  Default 100


--Adding Foreign key
Alter table products
add constraint FK_Product_Collection Foreign key (CollectionID) REFERENCES Collections(CollectionID)

--Adding Unique key
Alter table products
add constraint UK_ProductName Unique(ProductName)



--Adding default constraint, check constraint
Alter table products
add constraint SKU_Default  Default 'NA' for SKU

Alter table products
add constraint Price_Check  check (Price>0)



--dropping constraints
Alter table products
drop CONSTRAINT SKU_Default

---renaming sp
exec sp_rename spResetCollection,spResetCollections


Alter table collections
add constraint UK_CollectionName Unique(CollectionName)


---

select distinct CollectionName from collections




select top 1 * from collections order by CollectionID ASC
select top 2 * from collections order by CollectionID DESC
select top 50 percent * from collections order by CollectionID DESC


select * from collections




Use Customers
select * from customers

SELECT * FROM customers WHERE age > 25 AND (CustomerAddress like 'New Jersey')


SELECT * FROM customers WHERE age in (20,25,30)

SELECT * FROM customers
Where age BETWEEN 20 AND 25


select * from customers

SELECT * FROM customers
WHERE CUstomerAddress LIKE 'N%' 

SELECT * FROM customers
WHERE CUstomerAddress LIKE 'Mas_' 

SELECT * FROM customers
WHERE CUstomerAddress LIKE '[ABC]%'



select * from customers
select * from customers order by age desc, customername asc



select * from customers

select count(*) from customers 
select max(age) from customers
select sum(numberoforders) from customers


select * from customers


SELECT Max(Age) as maxAge,CustomerState, sum(numberoforders) as totalOrders
from customers
WHERE Email is not null
group BY CustomerState
order BY maxAge


select * from customers


SELECT CustomerCountry, CustomerState, Max(Age) as maxAge, sum(numberoforders) as totalOrders
from customers
group BY CustomerCountry,CustomerState
order BY maxAge
---HAVING CustomerCountry in ('US','India')



---JOINS

Use Inventory

select * from collections
select * from products

SELECT P.ProductName, P.SKU as ProductSKU, C.CollectionName
from Products P
join Collections C
on P.CollectionID = C.CollectionID


select * from collections
select * from products

SELECT P.ProductName, P.SKU as ProductSKU, C.CollectionName
from Products P
left join Collections C
on P.CollectionID = C.CollectionID



select * from collections
select * from products

SELECT C.CollectionName, C.CollectionDesc, P.ProductName, P.SKU as ProductSKU
from Products P
right join Collections C
on P.CollectionID = C.CollectionID


select * from collections
select * from products

SELECT P.ProductName, P.SKU as ProductSKU, C.CollectionName, C.CollectionDesc
from Products P
full outer join Collections C
on P.CollectionID = C.CollectionID


select * from products

SELECT P.ProductName, P.SKU as ProductSKU, C.ProductName as CollectionName
from Products P
join Products C
on P.CollectionID = C.ProductID


---Getting only the records without correspondence
select * from collections
select * from products

SELECT P.ProductName, P.SKU as ProductSKU, C.CollectionName
from Products P
left outer join Collections C
on P.CollectionID = C.CollectionID
where P.CollectionID is null



---NULLS

select * from products
select ISNULL(CollectionID,0) as Modified_Collection_ID from products
select COALESCE(CollectionID,ProductID,0) as Modified_Collection_ID from products







---Unions
select ProductID,ProductName from products
select ProductID,ProductName from products_2

select ProductID,ProductName from products
union
select ProductID,ProductName from products_2



