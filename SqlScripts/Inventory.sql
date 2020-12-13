Use Inventory



ALTER PROCEDURE spResetProducts
AS
BEGIN

    drop table if exists products
    create table products
    (
        SKU char(10) PRIMARY KEY,
        name varchar(100) NOT NULL UNIQUE,
        collectionID SMALLINT,
        GTIN varchar(20),
        price  SMALLINT
    )

    drop table if exists productDescription
    create table productDescription
    (
        SKU char(10) ,
        ProductDesc text Default 'NA',
        ProductHighlights text DEFAULT 'NA'

    )


        drop table if exists productComments
    create table productComments
    (
        SKU char(10) ,
        UserID int,
        ProductComment varchar(500) Default 'NA',
        rating tinyint not null

    )

    Alter table products
    add constraint Price_Check  check (Price>0)

END


---

alter procedure spResetCollections
as
begin
    drop table if exists collections
    create table collections
    (
        collectionID smallint IDENTITY PRIMARY KEY,
        name varchar(100) NOT NULL,
        description text Default 'NA',


    )
end




alter procedure spResetWarehouses
as
BEGIN

    drop table if exists warehouses
    create table warehouses
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


ALTER PROC spResetInventory
as
BEGIN
    drop table if exists currentInventory
        create table currentInventory
        (warehouseID tinyint NOT NULL,
        SKU char(10) NOT NULL,
        stock smallint DEFAULT 0
        )

END



drop table if exists warehhouseClerks
    create table warehouseClerks
    (warehouseID tinyint NOT NULL,
    employeeID char(10) NOT NULL
    )

drop table if exists warehhouseManagers
    create table warehouseManagers
    (warehouseID tinyint NOT NULL,
    employeeID char(10) NOT NULL
    )




exec spResetProducts
exec spResetCollections
exec spResetInventory
exec spResetWarehouses




---Connections

Alter table currentInventory
add constraint FK_Warehouse Foreign key (warehouseID) REFERENCES warehouses(warehouseID)

Alter table currentInventory
add constraint FK_Product Foreign key (SKU) REFERENCES products(SKU)


Alter table products
add constraint FK_Product_Collection Foreign key (collectionID) REFERENCES Collections(collectionID)

Alter table productComments
add constraint FK_Product_Comment Foreign key (SKU) REFERENCES products(SKU)

Alter table productDescription
add constraint FK_Product_Description Foreign key (SKU) REFERENCES products(SKU)

Alter table warehouseClerks
add constraint FK_Warehouse_Clerk Foreign key (warehouseID) REFERENCES warehouses(warehouseID)


Alter table warehouseManagers
add constraint FK_Warehouse_Manager Foreign key (warehouseID) REFERENCES warehouses(warehouseID)

---todo HR service will send updates to Inventory service when a new clerk or manager joins a warehouse - warehouseClerks, warehouseMangagers table
---todo Order Service will send updates when requested