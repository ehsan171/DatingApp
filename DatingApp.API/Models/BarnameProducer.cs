namespace DatingApp.API.Models
{
    public class BarnameProducer
    {
        // public int Id { get; set; } 
        public virtual Barname Barname { get; set; }
        public int BarnameId { get; set; }
        public virtual Person Producer { get; set; }
        public int PersonId { get; set; } 
    }
}