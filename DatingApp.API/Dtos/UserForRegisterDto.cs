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
         public int? OrgId { get; set; }
#nullable enable
         public string? Firstname { get; set; }
#nullable enable
         public string? Lastname { get; set; }

    }
}