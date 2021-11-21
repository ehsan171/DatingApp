using System;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Barname
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string? BaravordNo { get; set; }
        
        public virtual Status Status { get; set; }
        public int? StatusId { get; set; }
        
        public DateTime RegDate { get; set; }
        public DateTime Created { get; set; }
        
        public virtual ICollection<ScreenplayFormat> ScreenplayFormats { get; set; }

        public virtual ICollection<BarnameGroup> BarnameGroups { get; set; }
        public virtual ICollection<BarnameProducer> BarnameProducers { get; set; }
        public ICollection<BarnameNetwork> BarnameNetworks { get; set; }

    }
}