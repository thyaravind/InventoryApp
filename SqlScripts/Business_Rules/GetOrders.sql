create procedure accounts.spGetOrders
@id int
as
BEGIN
select orderID,number_of_products,street,address_1ine_2,address_line_3,state,country,zip from accounts.orders where paymentID = @id
end

exec spGetOrders 1