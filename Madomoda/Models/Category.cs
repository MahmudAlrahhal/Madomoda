using System.ComponentModel;
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
        [MaxLength(20)]
        [DisplayName("Name of Category")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="The number should be in the range between 1 and 100")]
        public int DisplayOrder{ get; set; }
    }
}
