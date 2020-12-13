using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    public class DeliveryTimeController : Controller
    {
        [HttpGet]
        public int GetDeliveryTime()
        {
        var deliverytime = 1;
            return deliverytime;
        }
        
        
        
        
    }
}