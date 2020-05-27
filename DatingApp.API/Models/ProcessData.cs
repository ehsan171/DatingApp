using System;

namespace DatingApp.API.Models
{
    public class ProcessData
    {
        public int Id { get; set; }
        public string Activity { get; set; }
        public string Type { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int? ScreenplayId { get; set; }
        public DateTime Time { get; set; }
    }
}