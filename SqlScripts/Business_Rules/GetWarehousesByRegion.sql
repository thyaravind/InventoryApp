alter procedure inventory.spGetWarehouseByRegion
@id int
as
BEGIN
select zip from inventory.warehouses where regionID = @id
end

exec inventory.spGetWarehouseByRegion 1