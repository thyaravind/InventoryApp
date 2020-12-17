alter procedure accounts.spGetOrders
@id int
as
BEGIN
select a.orderID,a.number_of_products as NumberOfProducts,a.street,a.address_1ine_2 as AddressLine2,a.address_line_3 as AddressLine3,a.state,a.country,a.zip_code as ZipCode,
       it.name as DeliveryType, ip.name as DeliveryPartner, CONCAT(cu.first_name,cu.last_name) as CustomerName, cu.email as CustomerEmail
from accounts.orders as a
join inventory.deliveryTypes as it
on a.delivery_typeID = it.delivery_typeID
join inventory.deliveryPartners as ip
on a.delivery_partnerID = ip.delivery_partnerID
join crm.customers as cu
on a.customerID = cu.customerID
where paymentID = @id
end

exec accounts.spGetOrders 1



create procedure accounts.spGetCurrentOrder
@id int
as
BEGIN
select a.orderID,a.number_of_products as NumberOfProducts,a.street,a.address_1ine_2 as AddressLine2,a.address_line_3 as AddressLine3,a.state,a.country,a.zip_code as ZipCode,
       it.name as DeliveryType, ip.name as DeliveryPartner, CONCAT(cu.first_name,cu.last_name) as CustomerName, cu.email as CustomerEmail
from accounts.orders as a
join inventory.deliveryTypes as it
on a.delivery_typeID = it.delivery_typeID
join inventory.deliveryPartners as ip
on a.delivery_partnerID = ip.delivery_partnerID
join crm.customers as cu
on a.customerID = cu.customerID
where orderID = @id
end

exec accounts.spGetCurrentOrder 1009