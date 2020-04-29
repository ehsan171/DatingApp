using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must speci...")]
        public string Password { get; set; }
         public string photoUrl { get; set; }
         public string name { get; set; }

    }
}