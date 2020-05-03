namespace DatingApp.API.Models
{
    public class ScreenplayProducer
    {
        public int Id { get; set; } 
        public virtual Screenplay Screenplay { get; set; }
        public int ScreenplayId { get; set; }
        public virtual Person Producer { get; set; }
        public int PersonId { get; set; } 
    }
}