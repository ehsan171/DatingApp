using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public virtual IList< StudentCourse > StudentCourses { get; set; }
    
}
}