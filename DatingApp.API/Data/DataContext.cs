using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext( DbContextOptions<DataContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q2C2TQL;Database=datingapp2;Trusted_Connection=True");
        }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity< StudentCourse >().HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity< EmployeeProject >().HasKey(sc => new { sc.EmployeeId, sc.ProjectId });
            modelBuilder.Entity< EpisodeConcept >().HasKey(sc => new { sc.EpisodeId, sc.BasicDataId });
            modelBuilder.Entity< EpisodeWriter >().HasKey(sc => new { sc.EpisodeId, sc.PersonId });
            modelBuilder.Entity< ScreenplayProducer >().HasKey(sc => new { sc.ScreenplayId, sc.PersonId });
            modelBuilder.Entity< ScreenplayFormat >().HasKey(sc => new { sc.ScreenplayId, sc.BasicDataId });
            modelBuilder.Entity< ScreenplayGenre >().HasKey(sc => new { sc.ScreenplayId, sc.BasicDataId });


    base.OnModelCreating(modelBuilder);
}

        public DbSet<Value> Values { get; set; }
        

        public DbSet<User> Users { get; set; }

        public DbSet< Student > Students { get; set; }
    
        public DbSet< Employee > Employee { get; set; }
        public DbSet< Project > Project { get; set; }
        public DbSet< EmployeeProject > EmployeeProject { get; set; }
        public DbSet< Episode> Episodes { get; set; }
        public DbSet< EpisodeConcept> EpisodeConcepts { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet< Person> Persons { get; set; }
        public DbSet< Screenplay> Screenplays { get; set; }
        public DbSet< ScreenplayFormat> ScreenplayFormats { get; set; }
        public DbSet< ScreenplayGenre> ScreenplayGenres { get; set; }
        public DbSet< ScreenplayProducer> ScreenplayProducers { get; set; }
        public DbSet< Status> Statuses { get; set; }
        public DbSet< Basic> Basic { get; set; }
        public DbSet< BasicData > BasicDatas{ get; set;}


     

        
    }


}