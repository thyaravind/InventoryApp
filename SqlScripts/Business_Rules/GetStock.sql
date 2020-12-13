alter procedure spGetStock
@id int
as
BEGIN
select Sum(stock) from stock where ProductID = @id
end

exec spGetStock 1