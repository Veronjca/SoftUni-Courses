using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
