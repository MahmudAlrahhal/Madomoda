using System.ComponentModel.DataAnnotations;

namespace Madomoda.Models
{
    //Creating the category model to use it as a table in the database using DbSet in ApplicationDbContext class.
    public class Category
    {
        [Key]
        public int Id { get; set; }
        //Required means to be not null
        [Required]
        public string Name { get; set; }
        public int DisplayOrder{ get; set; }
    }
}
