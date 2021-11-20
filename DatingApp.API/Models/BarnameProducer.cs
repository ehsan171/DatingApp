namespace DatingApp.API.Models
{
    public class ProgramProducer
    {
        // public int Id { get; set; } 
        public virtual Program Program { get; set; }
        public int ProgramId { get; set; }
        public virtual Person Producer { get; set; }
        public int PersonId { get; set; } 
    }
}