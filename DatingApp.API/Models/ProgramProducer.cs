namespace DatingApp.API.Models
{
    public class ResourceProducer
    {
        // public int Id { get; set; } 
        public virtual Resource Resource { get; set; }
        public int ResourceId { get; set; }
        public virtual Person Producer { get; set; }
        public int PersonId { get; set; } 
    }
}