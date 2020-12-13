using System;

namespace EnterpriseESB.Contracts
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public dynamic Data { get; set; }
    }
}
