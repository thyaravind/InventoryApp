create procedure inventory.spCreateProduct
@SKU char(10),
@name varchar(100),
@collectionID SMALLINT,
@GTIN varchar(20),
@price  SMALLINT,
@ProductDesc text,
@ProductHighlights text,
@stock smallint

as
BEGIN



insert into inventory.products
values (@SKU,@name,@collectionID,@GTIN,@price)

insert into inventory.productDescription
values(@SKU,@ProductDesc,@ProductHighlights)

insert into inventory.currentInventory
values(1,@SKU,@stock)

end


exec inventory.spCreateProduct 'NEW0011', ''