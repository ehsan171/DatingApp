using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Models
{
    public class Allocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        
        [Display(Name = "Is Accept")]
        public bool? FinalAcceptance { get; set; }

        public int? UsedUnit { get; set; }
        
        public DateTime? RegisterDate {  
            get =>
                _dateCreated ?? DateTime.Now;

            set => this._dateCreated = value;
        }
        private DateTime? _dateCreated = null;

        public virtual Resource Resource { get; set; }
        public int ResourceId { get; set; }        
        

        
        public virtual Barname Barname { get; set; }
        public int BarnameId { get; set; }
    }
}