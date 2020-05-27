using System;

namespace DatingApp.API.Dtos
{
    public class ProcessDataForRegisterDto
    {
      

         public string Activity { get; set; }
         public int UserId { get; set; }
         public string Type { get; set; }
         
         public int ScreenplayId { get; set; }
         
         public DateTime Time { get; set; }

         
         
    }
}