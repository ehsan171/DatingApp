namespace DatingApp.API.Models
{
    public class ResourceOccasion
    {
        // public int Id { get; set; }
        public virtual Resource Resource { get; set; }
        public int ResourceId { get; set; }
        public virtual Occasion Occasion { get; set; }
        public int OccasionId { get; set; }
    }
}