using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Title { get; set; }
        
        public int Capacity { get; set; }
        
        public virtual BasicData BasicData { get; set; }
        public int BasicDataId { get; set; }
        
    }
}