namespace DatingApp.API.Models
{
    public class EpisodeConcept
    {
        public int Id { get; set; }
        public virtual Episode Episode { get; set; }
        public int EpisodeId { get; set; }
        public virtual BasicData BasicData { get; set; }
        public int BasicDataId { get; set; }




    }
}