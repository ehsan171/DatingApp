namespace DatingApp.API.Models
{
    public class EpisodeWriter
    {
        // public int Id { get; set; } 
        public virtual Episode Episode { get; set; }
        public int EpisodeId { get; set; }
        public virtual Person Writer { get; set; }
        public int PersonId { get; set; }
    }
}