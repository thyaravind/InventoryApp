create procedure inventory.spGetAllCollections
as
BEGIN
select collectionID,name,description from inventory.collections

end

exec inventory.spGetAllCollections