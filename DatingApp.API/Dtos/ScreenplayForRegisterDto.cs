using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class ScreenplayForRegisterDto
    {
        [Required]
        public string Title { get; set; }

        // [Required]
        // [StringLength(8, MinimumLength = 4, ErrorMessage = "You must speci...")]
         public List<int> OrgStructure { get; set; }    
        
              
         public List<int> Genre { get; set; }
         public List<int> Producer { get; set; }
         public string BaravordNo { get; set; }
         public int? TotalNumberEpisodes { get; set; }
         public int Format { get; set; }
         public int? StatusId { get; set; }
         public string Description { get; set; }
         public DateTime RegDate { get; set; }
         public DateTime Created { get; set; }

        public ScreenplayForRegisterDto(){
            Created =DateTime.Now;
        }
         
        //   public string Username { get; set; }

        // [Required]
        // [StringLength(8, MinimumLength = 4, ErrorMessage = "You must speci...")]
        // public string Password { get; set; }
        //  public string photoUrl { get; set; }
        //  public string name { get; set; }

         

    }
}