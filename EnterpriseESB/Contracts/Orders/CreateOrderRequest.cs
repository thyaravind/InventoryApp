namespace EnterpriseESB.Contracts.Orders
{
    public class CreateOrderRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int OrderID { get; set; }
    }
}