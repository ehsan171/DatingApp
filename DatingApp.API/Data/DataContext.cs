using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext( DbContextOptions<DataContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q2C2TQL;Database=datingapp;Trusted_Connection=True");
        }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity< StudentCourse >().HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity< EmployeeProject >().HasKey(sc => new { sc.EmployeeId, sc.ProjectId });
  

 

       
    var museumEntity = modelBuilder.Entity<Museum>();

    museumEntity.HasMany(museum => museum.Genres)
    .WithOne(genre => genre.Museum).IsRequired()
        .HasForeignKey(genre => genre.MuseumId)
        ;

    museumEntity.HasMany(museum => museum.Artists)
        .WithOne(artist => artist.Museum).IsRequired()
        .HasForeignKey(artist => artist.MuseumId)
        ;

    base.OnModelCreating(modelBuilder);
}

        public DbSet<Value> Values { get; set; }
        

        public DbSet<User> Users { get; set; }

        public DbSet<ScreenplayInfo> ScreenplayInfo { get; set; }
        
        public DbSet< Student > Students { get; set; }
    
        public DbSet< Course > Courses { get; set; }
    
        public DbSet< StudentCourse > StudentCourses { get; set; }
        public DbSet< Employee > Employee { get; set; }
        public DbSet< Project > Project { get; set; }
        public DbSet< EmployeeProject > EmployeeProject { get; set; }

        public DbSet<Museum> Museums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }

        
    }


}