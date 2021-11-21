using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class PMDSPSItem
    {
        [Key]
        public int ItemID {get; set;}
        public string Title { get; set; }
        public string CleanTitle { get; set;}
        public int?  Sys_Title_FirstAscii{ get; set;}
        public int? Sys_Title_Lenght { get; set; }
        public int TypeID { get; set; }
        public int? ParentID { get; set; }
        public string MyProperty { get; set; }
        public bool? IsSys { get; set; }
        public int? Order { get; set; }
        public int? Value { get; set; }
        public bool? IsActive { get; set; }
        public int RUserID { get; set; }
        public DateTime? RDate { get; set; }
        public DateTime? EDate { get; set; }
        public int? EUserID { get; set; }
 
  
    }
}