namespace CardManagement.Domain.Entities
{
	public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; } = "Savings";
        public string UserId { get; set; }
        
    }
}