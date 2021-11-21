using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class RRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public virtual Barname Barname { get; set; }
        public int? BarnameId { get; set; }
        
        public virtual RecordType RecordType { get; set; }
        public int? RecordTypeId { get; set; }
        
        public virtual Occasion Occasion { get; set; }
        public int? OccasionId { get; set; }
       
        public DateTime RegDate { get; set; }
        
 
        public string Description { get; set; }
        
        public virtual ICollection<RRequestResource> RRequestResources { get; set; }
    }
}