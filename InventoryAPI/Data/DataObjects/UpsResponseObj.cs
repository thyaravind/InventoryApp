using System.Collections.Generic;

namespace InventoryAPI.Data.Entities
{
    public class UpsResponseObj
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class ResponseStatus
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class TransactionReference
        {
            public string CustomerContext { get; set; }
            public string TransactionIdentifier { get; set; }
        }

        public class Response
        {
            public ResponseStatus ResponseStatus { get; set; }
            public TransactionReference TransactionReference { get; set; }
        }

        public class Address
        {
            public string City { get; set; }
            public string StateProvinceCode { get; set; }
            public string CountryCode { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
        }

        public class ShipFrom
        {
            public Address Address { get; set; }
        }

        public class Address2
        {
            public string City { get; set; }
            public string StateProvinceCode { get; set; }
            public string CountryCode { get; set; }
            public string Country { get; set; }
            public string PostalCode { get; set; }
        }

        public class ShipTo
        {
            public Address2 Address { get; set; }
        }

        public class UnitOfMeasurement
        {
            public string Code { get; set; }
        }

        public class ShipmentWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class Service
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Arrival
        {
            public string Date { get; set; }
            public string Time { get; set; }
        }

        public class Pickup
        {
            public string Date { get; set; }
            public string Time { get; set; }
        }

        public class EstimatedArrival
        {
            public Arrival Arrival { get; set; }
            public string BusinessDaysInTransit { get; set; }
            public Pickup Pickup { get; set; }
            public string DayOfWeek { get; set; }
            public string CustomerCenterCutoff { get; set; }
        }

        public class ServiceSummary
        {
            public Service Service { get; set; }
            public string GuaranteedIndicator { get; set; }
            public EstimatedArrival EstimatedArrival { get; set; }
        }

        public class TransitResponse
        {
            public ShipFrom ShipFrom { get; set; }
            public ShipTo ShipTo { get; set; }
            public string PickupDate { get; set; }
            public ShipmentWeight ShipmentWeight { get; set; }
            public string MaximumListSize { get; set; }
            public List<ServiceSummary> ServiceSummary { get; set; }
            public string Disclaimer { get; set; }
        }

        public class TimeInTransitResponse
        {
            public Response Response { get; set; }
            public TransitResponse TransitResponse { get; set; }
        }

        public class UpsResponse
        {
            public TimeInTransitResponse TimeInTransitResponse { get; set; }
        }

    }
}