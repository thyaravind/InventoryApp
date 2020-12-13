use Inventory


create procedure spResetWarehouses
as
BEGIN

drop table if exists warehouses
create table warehouses 
(WarehouseID int NOT NULL IDENTITY PRIMARY KEY,
WarehouseName varchar(50) NOT NULL,
RegionID int,
WarehouseAddress text Default 'NA',
)
end



create table stock
(WarehouseID int NOT NULL,
ProductID int NOT NULL,
stock int
)

Alter table stock
add constraint FK_Warehouse Foreign key (WarehouseID) REFERENCES warehouses(WarehouseID)

Alter table stock
add constraint FK_Product Foreign key (ProductID) REFERENCES products(ProductID)
