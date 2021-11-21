using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class ScreenplayForUpdateDto
    {
        public ScreenplayForUpdateDto(string title, int id, DateTime regDate)
        {
            this.Title = title;
            this.Id = id;
            this.RegDate = regDate;

        }
      
#nullable enable
        public string Title { get;  set; } = null!;

        // [Required]
        // [StringLength(8, MinimumLength = 4, ErrorMessage = "You must speci...")]
#nullable enable
        public List<int> OrgStructure { get; set; } = null!;

        public int Id { get; set; }

#nullable enable
        public List<int>? Genre { get; set; }
#nullable enable
        public List<int>? Producer { get; set; }
#nullable enable
        public string? BaravordNo { get; set; }
#nullable enable
        public int? TotalNumberEpisodes { get; set; }
#nullable enable
        public int? Format { get; set; }
#nullable enable
        public int? StatusId { get; set; }
#nullable enable
        public string? Description { get; set; }
#nullable enable
        public DateTime RegDate { get; set; }
#nullable enable
        public DateTime Created { get; set; }

        public ScreenplayForUpdateDto()
        {
            Created = DateTime.Now;
        }
    }
}