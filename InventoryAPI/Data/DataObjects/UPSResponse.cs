using System.Collections.Generic;

namespace InventoryAPI.Data.Entities
{
    public class UPSResponse
    {
        public TimeInTransitResponse TimeInTransitResponse { get; set; }
    }

    
    
    public class TimeInTransitResponse
    {
        public Response Response { get; set; }
        public TransitResponse TransitResponse { get; set; }
    }
    
    public class Response
    {
        
    }
    
    public class TransitResponse
    {
        public ServiceSummary ServiceSummary { get; set; }
    }

    public class ServiceSummary
    {
        public List<Service> Services { get; set; }
        
    }

    public class Service
    {
        public EstimatedArrival EstimatedArrival { get; set; }
    }

    public class EstimatedArrival
    {
        public Arrival Arrival { get; set; }
        public BusinessDaysInTransit BusinessDaysInTransit { get; set; }
    }

    public class BusinessDaysInTransit
    {
        private string days;
    }

    public class Arrival
    {
        private string Date;
        private string Time;
    }
}