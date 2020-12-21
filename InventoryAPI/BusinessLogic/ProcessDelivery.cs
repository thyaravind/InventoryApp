using System;
using System.Threading.Tasks;
using InventoryAPI.Data.Entities;
using InventoryAPI.Data.ExternalDataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static InventoryAPI.Data.DataObjects.FastestDeliveryRequestObj;
using static InventoryAPI.Data.Entities.UPSRequestObj;
using static InventoryAPI.Data.Entities.UpsResponseObj;
using Address = InventoryAPI.Data.Entities.UPSRequestObj.Address;
using Address2 = InventoryAPI.Data.Entities.UPSRequestObj.Address2;
using Pickup = InventoryAPI.Data.Entities.UPSRequestObj.Pickup;
using ShipFrom = InventoryAPI.Data.Entities.UPSRequestObj.ShipFrom;
using ShipmentWeight = InventoryAPI.Data.Entities.UPSRequestObj.ShipmentWeight;
using ShipTo = InventoryAPI.Data.Entities.UPSRequestObj.ShipTo;
using TransactionReference = InventoryAPI.Data.Entities.UPSRequestObj.TransactionReference;
using UnitOfMeasurement = InventoryAPI.Data.Entities.UPSRequestObj.UnitOfMeasurement;
using InventoryAPI.Data.DataAccess;
using System.Collections.Generic;
using InventoryAPI.Data.DataObjects;

namespace InventoryAPI.BusinessLogic
{
    public static class ProcessDelivery
    {


        public static async Task<List<string>> GetFastestdeliveryAsync(FastestDeliveryRequestObj deliveryRequest)
        {

            List<string> warehouse_zips = new List<string>();   

        List<ZipObj> ZipObjs = DeliveryTime.GetNearestWarehouses(deliveryRequest.Zip);

            foreach(ZipObj zipp in ZipObjs){
                warehouse_zips.Add(zipp.Zip);
            }

        DateTime localDate = DateTime.Now;
        var PickupDate = localDate.AddDays(1);
        string pickup = PickupDate.ToString("yyyyMMdd");

        var ProbableArrivalDates = new List<string>();

            //todo weights

            foreach (string warehouse in warehouse_zips)
            {
                var request = new UPSRequestObj.UpsRequest
                {

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
                                StateProvinceCode = "",
                                CountryCode = "US",
                                PostalCode = warehouse
                            }

                        },
                        ShipTo = new ShipTo
                        {
                            Address = new Address2
                            {
                                StateProvinceCode = "",
                                CountryCode = "US",
                                PostalCode = deliveryRequest.Zip
                            }


                        },
                        Pickup = new Pickup
                        {
                            Date = pickup
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

                UpsResponse resp = await UPS.GetUPSTimeInTransit(RequestSerialized);

                foreach(ServiceSummary service in resp.TimeInTransitResponse.TransitResponse.ServiceSummary)
                {
                    string ArrivalDate = "";
                    ArrivalDate = service.EstimatedArrival.Arrival.Date;
                    ProbableArrivalDates.Add(ArrivalDate);
                }

            }

            return ProbableArrivalDates;


        }




    }
}
