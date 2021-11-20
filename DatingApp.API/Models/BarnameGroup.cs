namespace DatingApp.API.Models
{
    public class ProgramGroup
    {
        public virtual Program Program { get; set; }
        public int ProgramId { get; set; }
        public virtual BasicData BasicData { get; set; }
        public int BasicDataId { get; set; }
    }
}