using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;



namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        


        [HttpGet("{id}")]
        public int Get(int id)
        {
            int stock = StockData.GetStock(id);
            return stock;
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
