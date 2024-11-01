using Microsoft.EntityFrameworkCore;
using WAD.CW._16634.Models;

namespace WAD.CW._16634.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //16634 / Application DB Context based on which a local MS SQL database is created. Overall we have 3 table Surveys, Questions and Options
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
        .HasOne<Survey>() 
        .WithMany() 
        .HasForeignKey(q => q.SurveyId)
        .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Option>()
                .HasOne<Question>() 
                .WithMany()
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
