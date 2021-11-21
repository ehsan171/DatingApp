namespace DatingApp.API.Models
{
    public class ScreenplayGenre
    {
    //    public int Id { get; set; }
        public virtual Screenplay Screenplay { get; set; }
        public int ScreenplayId { get; set; }
        public virtual PMDSPSItem PMDSPSItem { get; set; }
        public int PMDSPSItemItemID { get; set; } 
    }
}