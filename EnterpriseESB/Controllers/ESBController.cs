using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EnterpriseESB.Contracts;
using EnterpriseESB.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnterpriseESB.Controllers
{

    [Route("[controller]")]
    public class ESBController : ControllerBase
    {


        [HttpPost]
        [Route("{*url}")]
        public Message Post(string url, Message message)
        {
            var dataText = ((JsonElement)message.Data).GetRawText();
            
            switch (url)
            {
                case "orders":
                    {
                        var client = new RestClient(
                            "https://localhost:6001/");
                        var request = new RestRequest(
                            "orders",
                            DataFormat.Json);
                        var response = client.Get<dynamic>(request);
                        return new Message
                        {
                            Data = response.Data["data"]
                        };
                    }
                case "order":
                    {
                        var client = new RestClient("https://localhost:6001/");
                        var data = JsonSerializer.Deserialize<OrderRequest>(dataText);
                        var orderID = data.orderID;
                        var request = new RestRequest($"orders/{orderID}", DataFormat.Json);
                        var response = client.Get<dynamic>(request);
                        return new Message
                        {
                            Data = response.Data
                        };
                    }
                case "create_order":
                    {
                        var order = JsonSerializer.Deserialize<CreateOrderRequest>(dataText);
                        SendRequest("https://localhost:6001/", "orders", order);
                        return new Message();
                    }
            }

            return new Message
            {
                Data = "Unknown Route!"
            };
        }


        private IRestResponse SendRequest(string baseUrl, string path, object body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(path, DataFormat.Json).AddJsonBody(body);
            var response = client.Post(request);
            return response;
        }


    }
}
