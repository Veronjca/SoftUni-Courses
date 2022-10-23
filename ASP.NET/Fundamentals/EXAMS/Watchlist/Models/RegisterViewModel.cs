using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
