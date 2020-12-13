﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        // GET api/values/5
        [HttpGet("{id}")]
        public int Get(int id)
        {
            int stock = StockData.GetStock(id);
            return stock;
        }

        // POST api/valuesintGetDeliveryTImeimereturn deliverytime;var deliverytime - = 1;
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
