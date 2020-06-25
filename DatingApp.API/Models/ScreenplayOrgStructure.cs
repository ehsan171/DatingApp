namespace DatingApp.API.Models
{
    public class ScreenplayOrgStructure
    {
         public virtual Screenplay Screenplay { get; set; }
        public int ScreenplayId { get; set; }
        public virtual OrgStructure OrgStructure { get; set; }
        public int OrgStructureId { get; set; }
    }
}