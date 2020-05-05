using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Screenplay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalNumberEpisodes { get; set; }
        public string BaravordNo { get; set; }
        public virtual OrgStructure OrgStructure { get; set; }
        public int OrgStructureId { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
         public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<ScreenplayFormat> ScreenplayFormats { get; set; }
        public virtual ICollection<ScreenplayGenre> ScreenplayGenres { get; set; }
        public virtual ICollection<ScreenplayProducer> ScreenplayProducers { get; set; }
        
    }
}