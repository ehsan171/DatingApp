using System.IO.Pipelines;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASGARI-PC\\EHSAN3;Database=ResourceAll4;Trusted_Connection=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<EmployeeProject>().HasKey(sc => new { sc.EmployeeId, sc.ProjectId });
            modelBuilder.Entity<EpisodeConcept>().HasKey(sc => new { sc.EpisodeId, sc.PMDSPSItemItemID });
            modelBuilder.Entity<ScreenplayOrgStructure>().HasKey(sc => new { sc.ScreenplayId, sc.PMDSPSItemItemID });
            modelBuilder.Entity<EpisodeWriter>().HasKey(sc => new { sc.EpisodeId, sc.PersonId });
            modelBuilder.Entity<ScreenplayProducer>().HasKey(sc => new { sc.ScreenplayId, sc.PersonId });
            modelBuilder.Entity<ScreenplayFormat>().HasKey(sc => new { sc.ScreenplayId, sc.PMDSPSItemItemID });
            modelBuilder.Entity<ScreenplayGenre>().HasKey(sc => new { sc.ScreenplayId, sc.PMDSPSItemItemID });
            modelBuilder.Entity<BarnameGroup>().HasKey(sc => new { sc.BarnameId, sc.BasicDataId });
            modelBuilder.Entity<BarnameNetwork>().HasKey(sc => new { sc.BarnameId, sc.BasicDataId });
            modelBuilder.Entity<BarnameProducer>().HasKey(sc => new { sc.BarnameId, sc.PersonId });
            modelBuilder.Entity<ResourceOccasion>().HasKey(sc => new { sc.ResourceId, sc.OccasionId });
            modelBuilder.Entity<RRequestResource>().HasKey(sc => new { sc.ResourceId, sc.RRequestId });
            modelBuilder.Entity<Allocation>().HasKey(sc => new { sc.Id });
            


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Value> Values { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeConcept> EpisodeConcepts { get; set; }
        public DbSet<EpisodeWriter> EpisodeWriters { get; set; }
        public DbSet<OrgStructure> OrgStructures { get; set; }
        public DbSet<ScreenplayOrgStructure> ScreenplayOrgStructures { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Screenplay> Screenplays { get; set; }
        public DbSet<ScreenplayFormat> ScreenplayFormats { get; set; }
        public DbSet<ScreenplayGenre> ScreenplayGenres { get; set; }
        public DbSet<ScreenplayProducer> ScreenplayProducers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Basic> Basic { get; set; }
        public DbSet<BasicData> BasicDatas { get; set; }

        public DbSet<UserTest> UserTests { get; set; }
     
        public DbSet<ProcessDataReg> ProcessDataRegs { get; set; }
        public DbSet<PMDSPSItem> PMDSPSItem { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Occasion> Occasions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<RecordType> RecordTypes { get; set; }

        public DbSet<ResourceOccasion> ResourceOccasions { get; set; }

        public DbSet<RRequest> RRequests { get; set; }

        public DbSet<RRequestResource> RRequestResources { get; set; }

        public DbSet<Barname> Barname { get; set; }

        public DbSet<BarnameGroup> BarnameGroups { get; set; }

        public DbSet<BarnameNetwork> BarnameNetworks { get; set; }

        public DbSet<BarnameProducer> BarnameProducers { get; set; }

        public DbSet<Allocation> Allocations { get; set; }

        public DbSet<TimeSection> TimeSections { get; set; }
        
        
        
    }


}