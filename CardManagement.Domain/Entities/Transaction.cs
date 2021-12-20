using System;

namespace CardManagement.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string CardNumber { get; set; }
        public string UserId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
