using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class OrgStructure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public bool IsInner { get; set; }
        public virtual ICollection<Screenplay> Screenplays { get; set; }
    }
}