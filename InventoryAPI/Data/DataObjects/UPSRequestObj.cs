using System;
using System.Net.Http;

namespace InventoryAPI.Data.Entities
{
    public class UPSRequestObj

    {
        public static implicit operator HttpContent(UPSRequestObj v)
        {
            throw new NotImplementedException();
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class UsernameToken
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class UPSServiceAccessToken
        {
            public string AccessLicenseNumber { get; set; }
        }

        public class Security
        {
            public UsernameToken UsernameToken { get; set; }
            public UPSServiceAccessToken UPSServiceAccessToken { get; set; }
        }

        public class TransactionReference
        {
            public string CustomerContext { get; set; }
            public string TransactionIdentifier { get; set; }
        }

        public class Request
        {
            public string RequestOption { get; set; }
            public TransactionReference TransactionReference { get; set; }
        }

        public class Address
        {
            public string StateProvinceCode { get; set; }
            public string CountryCode { get; set; }
            public string PostalCode { get; set; }
        }

        public class ShipFrom
        {
            public Address Address { get; set; }
        }

        public class Address2
        {
            public string StateProvinceCode { get; set; }
            public string CountryCode { get; set; }
            public string PostalCode { get; set; }
        }

        public class ShipTo
        {
            public Address2 Address { get; set; }
        }

        public class Pickup
        {
            public string Date { get; set; }
        }

        public class UnitOfMeasurement
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class ShipmentWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class TimeInTransitRequest
        {
            public Request Request { get; set; }
            public ShipFrom ShipFrom { get; set; }
            public ShipTo ShipTo { get; set; }
            public Pickup Pickup { get; set; }
            public ShipmentWeight ShipmentWeight { get; set; }
            public string MaximumListSize { get; set; }
        }

        public class UpsRequest
        {
            public Security Security { get; set; }
            public TimeInTransitRequest TimeInTransitRequest { get; set; }
        }


    }
}