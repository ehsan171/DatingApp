using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Dtos
{
    public class EpisodeForCreationDto
    {
        public int ScreenplayId { get; set; }
        public string Url { get; set; }
        // public IFormFile File { get; set; }
        public int episodeNumber { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public List<string> Concept { get; set; }
         public List<int> Writer { get; set; }

        public EpisodeForCreationDto(){
            DateAdded =DateTime.Now;
        }
    }
}