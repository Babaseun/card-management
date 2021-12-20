using CardManagement.Domain.Enumerations;

namespace CardManagement.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        
        public bool Valid { get; set; }
        public State State { get; set; } 
        
        public string Type { get; set; }
    }
}