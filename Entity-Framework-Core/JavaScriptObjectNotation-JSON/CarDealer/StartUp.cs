using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersData = File.ReadAllText("../../../Datasets/suppliers.json");
            string partsData = File.ReadAllText("../../../Datasets/parts.json");
            string carsData = File.ReadAllText("../../../Datasets/cars.json");
            string customersData = File.ReadAllText("../../../Datasets/customers.json");
            string salesData = File.ReadAllText("../../../Datasets/sales.json");

            ImportSuppliers(context, suppliersData);
            ImportParts(context, partsData);
            ImportCars(context, carsData);
            ImportCustomers(context, customersData);
            ImportSales(context, salesData);

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            List<Part> parts = new List<Part>();
            parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => supplierIds.Contains(p.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarDto> carDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);
          
            List<Car> cars = new List<Car>();
            List<int> existingPartsIds = context.Parts
                .Select(p => p.Id)
                .ToList();

            var config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<CarDto, Car>();
           });

            var mapper = config.CreateMapper();

            foreach (var car in carDtos)
            {
                List<PartCar> partCars = new List<PartCar>();
                foreach (var id in car.PartsId.Distinct())
                {
                    if (existingPartsIds.Contains(id))
                    {
                        partCars.Add(new PartCar { CarId = car.Id, PartId = id });
                    }             
                }

                Car currentCar = mapper.Map<Car>(car);
                currentCar.PartCars = partCars;
                cars.Add(currentCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var customers = context.Customers
                 .OrderBy(c => c.BirthDate)
                 .ThenBy(c => c.IsYoungDriver)
                 .Select(c => new
                 {
                     Name = c.Name,
                     BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                     IsYoungDriver = c.IsYoungDriver
                 })  
                
                 .ToList();

            string customersJson = JsonConvert.SerializeObject(customers, settings);

            return customersJson;

        }

        //15.  Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string carsJson = JsonConvert.SerializeObject(cars);

            return carsJson;
        }

        //16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string suppliersJson = JsonConvert.SerializeObject(suppliers);

            return suppliersJson;
                
        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}"
                    })
                        .ToList()

                })
                .ToList();

            string carsJson = JsonConvert.SerializeObject(cars, settings);
            return carsJson;
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy
                    {
                        OverrideSpecifiedNames = false
                    }
                }
            };

            var customers = context.Sales
                .Include(s => s.Customer)
                .Select(s => new
                {
                    FullName = s.Customer.Name,
                    BoughtCars = s.Customer.Sales.Count,
                    SpentMoney = s.Customer.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))

                })
                .OrderByDescending(s => s.SpentMoney)
                .ThenByDescending(s => s.BoughtCars)
                .Distinct()
                .ToList();

            string customersJson = JsonConvert.SerializeObject(customers, settings);

            return customersJson;
        }

        //19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var sales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(c => c.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(c => c.Part.Price) - (s.Car.PartCars.Sum(c => c.Part.Price) * (s.Discount / 100)):f2}"
                })
                .Take(10)
                .ToList();

            string salesJson = JsonConvert.SerializeObject(sales, settings);

            return salesJson;

        }
    }
}