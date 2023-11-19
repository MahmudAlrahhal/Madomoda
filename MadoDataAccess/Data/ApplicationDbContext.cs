using MadoModels;
using Microsoft.EntityFrameworkCore;

namespace MadoDataAccess.Data
{
    //Creating ApplicationDbContext for setting up the database.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //This should be added to migrations using add-migration [migrationName] and should be updated with update-database command
        //This added a table of Categories to the database
        public DbSet<Category> Categories { get; set; }

        //adding initial data to the database. Note: Add migration should be invoked to update changes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "FirstCat", DisplayOrder = 2},
                new Category { Id = 2, Name = "SecondCat", DisplayOrder = 1 },
                new Category { Id = 3, Name = "ThirdCat", DisplayOrder = 3 }
                );
        }
    }
}
