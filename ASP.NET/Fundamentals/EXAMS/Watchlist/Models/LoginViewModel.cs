using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
