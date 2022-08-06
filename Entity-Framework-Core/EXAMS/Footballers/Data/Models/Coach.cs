using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new List<Footballer>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Nationality { get; set; }

        public List<Footballer> Footballers { get; set; }
    }
}
