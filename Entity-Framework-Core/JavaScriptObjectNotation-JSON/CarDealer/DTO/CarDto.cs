using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}
