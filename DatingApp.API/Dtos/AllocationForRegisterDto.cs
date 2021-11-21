using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class AllocationForRegisterDto
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int UsedUnit { get; set; }
        public int ResourceId { get; set; }
        public int BarnameId { get; set; }
        public DateTime RegisterDate { get; set; }
        public Boolean IsDeleted { get; set; }



    }
}