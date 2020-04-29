using System;

namespace DatingApp.API.Models
{
    public class ScreenplayInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoEpisodes { get; set; }
        public string Author { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatingRecordDate { get; set; }
        
    }
}