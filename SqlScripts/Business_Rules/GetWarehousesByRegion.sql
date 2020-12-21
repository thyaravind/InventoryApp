alter procedure inventory.spGetNearestWarehouses
@zip varchar(15)
as
BEGIN

select zip,cI.stock from inventory.warehouses
join inventory.currentInventory cI
on warehouses.warehouseID = cI.warehouseID
where  regionID = (select regionID from inventory.regionZipcodes
 where zip = @zip)
end

exec inventory.spGetNearestWarehouses '85281'