namespace CardManagement.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StreetNumber { get; set; }
        public int VendorId { get; set; }
    }
}