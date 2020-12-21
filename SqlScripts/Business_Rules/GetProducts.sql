alter procedure inventory.spGetAllProducts
as
BEGIN
select p.SKU, p.name,price,c.name as CollectionName,pD.ProductDesc as Description, cI.stock as CurrentStock from inventory.products p
join collections c on p.collectionID = c.collectionID
join (select SKU,SUM(stock) as stock from inventory.currentInventory GROUP BY SKU) cI on p.SKU = cI.SKU
join productDescription pD on p.SKU = pD.SKU
end

exec inventory.spGetAllProducts