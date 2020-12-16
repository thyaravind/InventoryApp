using System.Threading.Tasks;
using InventoryAPI.Data.Entities;
using InventoryAPI.Data.ExternalDataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static InventoryAPI.Data.Entities.UPSRequest;
using static InventoryAPI.Data.Entities.UpsResponseObj;
using Address = InventoryAPI.Data.Entities.UPSRequest.Address;
using Address2 = InventoryAPI.Data.Entities.UPSRequest.Address2;
using Pickup = InventoryAPI.Data.Entities.UPSRequest.Pickup;
using ShipFrom = InventoryAPI.Data.Entities.UPSRequest.ShipFrom;
using ShipmentWeight = InventoryAPI.Data.Entities.UPSRequest.ShipmentWeight;
using ShipTo = InventoryAPI.Data.Entities.UPSRequest.ShipTo;
using TransactionReference = InventoryAPI.Data.Entities.UPSRequest.TransactionReference;
using UnitOfMeasurement = InventoryAPI.Data.Entities.UPSRequest.UnitOfMeasurement;

namespace InventoryAPI.Controllers

{
    [Route("api/[controller]")]
    public class DeliveryTimeController : Controller
    {
        [HttpGet]
        public async Task<UpsResponse> GetDeliveryTime()
        {
            
            var request = new UPSRequest.Root {

                TimeInTransitRequest = new TimeInTransitRequest
                {
                    Request = new Request
                    {
                        RequestOption = "TNT",
                        TransactionReference = new TransactionReference
                        {

                        }


                    },

                    ShipFrom = new ShipFrom
                    {
                        Address = new Address
                        {
                            StateProvinceCode = "MA",
                            CountryCode = "US",
                            PostalCode = "02740"
                        }

                    },
                    ShipTo = new ShipTo
                    {
                        Address = new Address2
                        {
                            StateProvinceCode = "AZ",
                            CountryCode = "US",
                            PostalCode = "85281"
                        }


                    },
                    Pickup = new Pickup
                    {
                        Date = "20201222"
                    },

                    ShipmentWeight = new ShipmentWeight
                    {
                        UnitOfMeasurement = new UnitOfMeasurement
                        {
                            Code = "KGS",
                            Description = ""
                        },
                        Weight = "20"

                    },
                    MaximumListSize = "2"

                },
                Security = new Security
                {
                    UsernameToken = new UsernameToken
                    {
                        Username = "AravindSamala",
                        Password = "hakunaMATATA02@"
                    },
                    UPSServiceAccessToken = new UPSServiceAccessToken
                    {
                        AccessLicenseNumber = "2D8F460B702D02D5"
                    }
                }




            };

            var RequestSerialized = JsonConvert.SerializeObject(request);

            UpsResponse resp = await UPS.GetUPS(RequestSerialized);

            
            
            return resp;
        }





    }
}