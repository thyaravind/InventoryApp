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

