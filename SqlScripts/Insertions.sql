
use Inventory
exec spResetCollections

insert into collections 
values ('Travel','Travel diaries'), ('Cooking','cooking diaries'), ('Cooking','cook diaries')

insert into collections 
values ('Milestone','fitness and sports diaries')

insert into collections 
("CollectionName") values ('Milestone')


---
Use Inventory

exec spResetProducts

insert into products_2
(ProductName,CollectionID,SKU) values ('Eiffel',1,'TJ001'), ('Rider',1,'TJ002'), ('Green',2,'CJ001'),('Sprint',4,'MJ001')

insert into products_2
(ProductName,SKU) values ('New','NE001'), ('New2','NE002')
---

insert into orders
(CustomerID, ProductID) values (2,1)



---
Use Customers

exec spResetCustomers

insert into customers
(CustomerName,CustomerState,EMail,Age) values ('Aravind','New Jersey','aravind@gmail.com',25), ('Ram','Carolina','ram@gmail.com',30)

insert into customers
(CustomerName,CustomerState,EMail,Age) values ('Aravind','New Jersey','a@gmail.com',27), ('Ram','Carolina','r@gmail.com',31)

insert into customers
values ('Alekya','623 County St','Mass','US','alekya@gmail.com','9849673245',10,25)

insert into customers
values ('Chinnu','1023 E University St','Mass','India','chinnua@gmail.com','9849673245',10,10)

insert into customers
values ('Chinna','Nowhere','AP','India','chinna@gmail.com','9849344231',10,22)
---

delete from warehouses

insert into warehouses
(WarehouseName,RegionID) values ('newhampshire',1),('arizona',7),('nevada',7),('nyc',2),('texas',4)

insert into stock
values (12,1,25),(15,2,40),(13,4,44),(13,1,10),(13,2,4)

select * from warehouses
select * from stock


