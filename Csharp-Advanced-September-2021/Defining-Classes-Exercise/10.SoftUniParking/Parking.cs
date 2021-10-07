using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }
        public List<Car> Cars { get; set; }
        public int Count { get; private set; }

        public string AddCar (Car car)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return"Car with that registration number, already exists!";
            }
            else if (this.Cars.Count == this.capacity)
            {
               return"Parking is full!";
            }
            else
            {
                this.Cars.Add(car);
                Count++;
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar (string registrationNumber)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                this.Cars.RemoveAll(x => x.RegistrationNumber == registrationNumber);
                Count--;
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar (string registrationNumber)
        {
            return this.Cars.First(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                int removed = this.Cars.RemoveAll(x => x.RegistrationNumber == item);
                Count -= removed;
            }
        }
    }
}
