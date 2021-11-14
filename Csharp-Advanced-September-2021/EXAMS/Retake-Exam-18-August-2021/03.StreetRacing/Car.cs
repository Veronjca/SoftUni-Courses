using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
   public  class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }


        public override string ToString()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nLicense Plate: {this.LicensePlate}\nHorse Power: {this.HorsePower}\nWeight: {this.Weight}";
        }
    }
}
