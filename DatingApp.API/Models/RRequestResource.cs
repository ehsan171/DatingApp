using System;

namespace DatingApp.API.Models
{
    public class RRequestResource
    {
        // public int Id { get; set; }
      
        
        public virtual RRequest RRequest { get; set; }
        public int RRequestId { get; set; }
        
        public virtual Resource Resource { get; set; }
        public int ResourceId { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Qty { get; set; }
    }
}