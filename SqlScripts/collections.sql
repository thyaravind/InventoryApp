use Inventory


alter proc spResetCollections
as 
begin
drop table if exists collections
create table collections
(
    CollectionID int NOT NULL IDENTITY PRIMARY KEY,
    CollectionName varchar(250) NOT NULL,
    CollectionDesc text

)
end


exec sp_rename spResetCollection,spResetCollections

Alter table collections 
add constraint UK_CollectionName Unique(CollectionName)