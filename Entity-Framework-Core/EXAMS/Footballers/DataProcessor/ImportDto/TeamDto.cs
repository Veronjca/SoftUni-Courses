using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"[A-Za-z0-9 .-]+")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        public List<int> Footballers { get; set; }
    }
}
