using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Dtos
{
    public class EpisodeForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeTitle { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }

        public EpisodeForCreationDto(){
            DateAdded =DateTime.Now;
        }
    }
}