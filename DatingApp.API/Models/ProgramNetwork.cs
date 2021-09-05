namespace DatingApp.API.Models
{
    public class ProgramNetwork
    {
        public virtual Resource Resource { get; set; }
        public int ResourceId { get; set; }
        public virtual BasicData BasicData { get; set; }
        public int BasicDataId { get; set; }
    }
}