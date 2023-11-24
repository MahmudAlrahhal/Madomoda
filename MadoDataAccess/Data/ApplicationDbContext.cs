using MadoModels.Models;
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
        public DbSet<Product> Products { get; set; }

        //adding initial data to the database. Note: Add migration should be invoked to update changes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "FirstCat", DisplayOrder = 2 },
                new Category { Id = 2, Name = "SecondCat", DisplayOrder = 1 },
                new Category { Id = 3, Name = "ThirdCat", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Eternal Journey",
                    Author = "Billy Spark",
                    Description = "Embark on a timeless adventure with 'Eternal Journey.' This captivating tale weaves through the tapestry of existence, offering a mesmerizing blend of mystery and introspection.\r\n\r\nJourney into the unknown as you explore the depths of the human soul.",
                    ISBN = "EJ2023001",
                    ListPrice = 120,
                    Price = 110,
                    Price50 = 105,
                    Price100 = 100,
                    CategoryId = 4,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Whispers in the Shadows",
                    Author = "Nancy Hoover",
                    Description = "Step into the enigmatic world of 'Whispers in the Shadows,' where every page holds secrets untold. Unravel the mysteries that linger in the darkest corners of the mind, and let the shadows reveal their hidden truths.\r\n\r\nDare to uncover the secrets within.",
                    ISBN = "WIS987654321",
                    ListPrice = 50,
                    Price = 40,
                    Price50 = 35,
                    Price100 = 30,
                    CategoryId = 5,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Serenity's Embrace",
                    Author = "Julian Button",
                    Description = "Find solace in the pages of 'Serenity's Embrace,' a tale that unfolds like a gentle breeze. Allow the words to carry you to a world of tranquility and self-discovery, where every moment is a step towards inner peace.\r\n\r\nEmbrace the serenity within.",
                    ISBN = "SE20231234",
                    ListPrice = 65,
                    Price = 60,
                    Price50 = 50,
                    Price100 = 45,
                    CategoryId = 6,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Sweet Symphony",
                    Author = "Abby Muscles",
                    Description = "Indulge in the delightful notes of 'Sweet Symphony,' a harmonious blend of emotions and flavors. Let the story unfold like a sugary melody, leaving a lingering taste of joy and wonder on your literary palate.\r\n\r\nExperience the sweetness of life.",
                    ISBN = "SS123456789",
                    ListPrice = 90,
                    Price = 85,
                    Price50 = 80,
                    Price100 = 75,
                    CategoryId = 5,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Echoes of the Abyss",
                    Author = "Ron Parker",
                    Description = "Plunge into the depths of 'Echoes of the Abyss,' where echoes of forgotten realms resonate. Navigate the mysterious currents of the ocean of time, and let the waves of the narrative carry you to uncharted territories.\r\n\r\nDiscover the echoes that linger beyond the horizon.",
                    ISBN = "EOTA5678901",
                    ListPrice = 40,
                    Price = 37,
                    Price50 = 35,
                    Price100 = 30,
                    CategoryId = 5,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Whispers Among the Leaves",
                    Author = "Laura Phantom",
                    Description = "Listen to the 'Whispers Among the Leaves,' where nature's secrets are revealed. The rustle of leaves tells tales of ancient wonders and timeless beauty. Immerse yourself in the delicate dance of life that unfolds beneath the leafy canopy.\r\n\r\nExperience the magic of nature's whispers.",
                    ISBN = "WAL987654321",
                    ListPrice = 35,
                    Price = 33,
                    Price50 = 32,
                    Price100 = 30,
                    CategoryId = 5,
                    ImageUrl = ""
                }

                );
        }
    }
}
