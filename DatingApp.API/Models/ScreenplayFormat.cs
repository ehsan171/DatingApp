namespace DatingApp.API.Models
{
    public class ScreenplayFormat
    {
        // public int Id { get; set; }
        public virtual Screenplay Screenplay { get; set; }
        public int ScreenplayId { get; set; }
        public virtual BasicData BasicData { get; set; }
        public int BasicDataId { get; set; }
    }
}