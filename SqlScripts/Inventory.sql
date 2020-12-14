
alter PROCEDURE inventory.spResetProducts
AS
BEGIN

    drop table if exists inventory.products
    create table inventory.products
    (
        SKU char(10) PRIMARY KEY,
        name varchar(100) NOT NULL UNIQUE,
        collectionID SMALLINT,
        GTIN varchar(20),
        price  SMALLINT
    )

    drop table if exists inventory.productDescription
    create table inventory.productDescription
    (
        SKU char(10) ,
        ProductDesc text Default 'NA',
        ProductHighlights text DEFAULT 'NA'

    )


        drop table if exists inventory.productComments
    create table inventory.productComments
    (
        SKU char(10) ,
        UserID int,
        ProductComment varchar(500) Default 'NA',
        rating tinyint not null

    )

    Alter table inventory.products
    add constraint Price_Check  check (Price>0)

END


---

alter procedure inventory.spResetCollections
as
begin
    drop table if exists inventory.collections
    create table inventory.collections
    (
        collectionID smallint IDENTITY PRIMARY KEY,
        name varchar(100) NOT NULL,
        description text Default 'NA',


    )
end




alter procedure inventory.spResetWarehouses
as
BEGIN

    drop table if exists inventory.warehouses
    create table inventory.warehouses
    (
        warehouseID    tinyint      NOT NULL IDENTITY PRIMARY KEY,
        name  varchar(100) NOT NULL UNIQUE,
        regionID       tinyint,
        street         varchar(100) NOT NULL,
        address_1ine_2 varchar(250),
        address_line_3 varchar(250),
        state          varchar(25)  NOT NULL,
        country        CHAR(2)      NOT NULL,
        zip            varchar(15)  NOT NULL,
    )

END


alter PROC inventory.spResetInventory
as
BEGIN
    drop table if exists inventory.currentInventory
        create table inventory.currentInventory
        (warehouseID tinyint NOT NULL,
        SKU char(10) NOT NULL,
        stock smallint DEFAULT 0
        )

END



drop table if exists inventory.warehhouseClerks
    create table inventory.warehouseClerks
    (warehouseID tinyint NOT NULL,
    employeeID char(10) NOT NULL
    )

drop table if exists inventory.warehhouseManagers
    create table inventory.warehouseManagers
    (warehouseID tinyint NOT NULL,
    employeeID char(10) NOT NULL
    )



drop table if exists inventory.deliveryPartners
    create table inventory.deliveryPartners
    (delivery_partnerID tinyint NOT NULL PRIMARY KEY,
    name varchar(100)
    )


drop table if exists inventory.deliveryTypes
    create table inventory.deliveryTypes
    (delivery_typeID tinyint NOT NULL PRIMARY KEY,
    name varchar(100)
    )



exec spResetProducts
exec spResetCollections
exec spResetInventory
exec spResetWarehouses




---Connections

Alter table inventory.currentInventory
add constraint FK_Warehouse Foreign key (warehouseID) REFERENCES inventory.warehouses(warehouseID)

Alter table inventory.currentInventory
add constraint FK_Product Foreign key (SKU) REFERENCES inventory.products(SKU)


Alter table inventory.products
add constraint FK_Product_Collection Foreign key (collectionID) REFERENCES inventory.collections(collectionID)

Alter table inventory.productComments
add constraint FK_Product_Comment Foreign key (SKU) REFERENCES inventory.products(SKU)

Alter table inventory.productDescription
add constraint FK_Product_Description Foreign key (SKU) REFERENCES inventory.products(SKU)


Alter table inventory.warehouseClerks
add constraint FK_WarehouseClerk_Warehouse Foreign key (warehouseID) REFERENCES inventory.warehouses(warehouseID)

Alter table inventory.warehouseManagers
add constraint FK_WarehouseManager_Warehouse Foreign key (warehouseID) REFERENCES inventory.warehouses(warehouseID)


Alter table inventory.warehouseManagers
add constraint FK_Warehouse_Manager Foreign key (employeeID) REFERENCES hr.employees(employeeID)

Alter table inventory.warehouseClerks
add constraint FK_Warehouse_Clerk Foreign key (employeeID) REFERENCES hr.employees(employeeID)

---todo HR service will send updates to Inventory service when a new clerk or manager joins a warehouse - warehouseClerks, warehouseMangagers table
---todo Order Service will send updates when requested