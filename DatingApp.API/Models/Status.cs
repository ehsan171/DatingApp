using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Namw { get; set; }
        public virtual ICollection<Screenplay> Screenplays  { get; set; }
    }
}