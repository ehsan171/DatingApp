using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Artist
    {
        public int Id { get; set; }

    // every Artist belongs to one Museum using foreign key:
    public int MuseumId { get; set; }
    public virtual Museum Museum { get; set; }

    // every Artist creates work in zero or more Genres (many-to-many)

    public string Name { get; set; }
    }
}