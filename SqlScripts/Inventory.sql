
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
        price  SMALLINT,
        weight REAL
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
        street         varchar(100),
        address_1ine_2 varchar(250),
        address_line_3 varchar(250),
        state          varchar(25),
        country        CHAR(2),
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
    (delivery_partnerID tinyint IDENTITY PRIMARY KEY,
    name varchar(100)
    )


drop table if exists inventory.deliveryTypes
    create table inventory.deliveryTypes
    (delivery_typeID tinyint IDENTITY PRIMARY KEY,
    name varchar(100)
    )


drop table if exists inventory.regions
    create table inventory.regions
    (regionID tinyint IDENTITY PRIMARY KEY,
    name varchar(100)
    )


drop table if exists inventory.regionZipcodes
    create table inventory.regionZipcodes
    (regionID tinyint NOT NULL,
    zip            varchar(15)  NOT NULL

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

Alter table inventory.warehouses
add constraint FK_Warehouse_Region Foreign key (regionID) REFERENCES inventory.regions(regionID)

---todo HR service will send updates to Inventory service when a new clerk or manager joins a warehouse - warehouseClerks, warehouseMangagers table
---todo Order Service will send updates when requested


Alter table inventory.regionZipcodes
add constraint FK_RegionZipCodes_Region Foreign key (regionID) REFERENCES inventory.regions(regionID)



---Insertions

BEGIN

    insert into inventory.deliveryPartners
    values ('UPS'),('Fedex')

    insert into inventory.deliveryTypes
    values ('Expedited'),('Same Day Delivery')

    insert into inventory.regions
    values ('South West'),('North West'),('South East'),('North East'),('Mid North'),('Mid South')

    insert into inventory.warehouses
    (name,regionID,zip)values ('Arizona',1,85281)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Seattle',2,98104)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Jacksonville',3,32207)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Dartmouth',4,02740)

    insert into inventory.warehouses
    (name,regionID,zip)values ('South Dakota',5,57501)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Austin',6,78758)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Los Angeles',1,90401)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Sawtooth',2,83278)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Atlanta',3,30313)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Pennsylvania',4,16801)

    insert into inventory.warehouses
    (name,regionID,zip)values ('Pennsylvania second',4,16801)

END

BEGIN


    insert into inventory.collections
    values ('Travel','Travel diaries collection')


    insert into inventory.regionZipcodes
    values (5,'02740'),(2,'85281'),(4,'16801')

    insert into inventory.currentInventory
    values (1,'TJWTE001',20), (2,'TJWTE001',10)


        insert into inventory.currentInventory
    values (1,'MJEND001',20), (2,'CJCOL001',100)

        insert into inventory.productDescription
    values ('TJWTE001','The description of product - travel diaries','highlight 1, highlight 2')

insert into inventory.productDescription
    values ('MJEND001','The description of product - milestone diaries','another highlight 1, another highlight 2')



insert into inventory.collections
values ('Fitness','Fitness product collection')

insert into inventory.collections
values ('Home','Home product collection')

END


select * from inventory.products
select * from inventory.productDescription

select * from inventory.collections

select * from inventory.regions

select * from inventory.regionZipcodes

select * from inventory.currentInventory

select * from inventory.warehouses
