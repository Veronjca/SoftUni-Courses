using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string suppliersInfo = File.ReadAllText("Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliersInfo));

            string partsInfo = File.ReadAllText("Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, partsInfo));

            string carInfo = File.ReadAllText("Datasets/cars.xml");
            Console.WriteLine(ImportCars(context, carInfo));

            string customersInfo = File.ReadAllText("Datasets/customers.xml");
            Console.WriteLine(ImportCustomers(context, customersInfo));

            string salesInfo = File.ReadAllText("Datasets/sales.xml");
            Console.WriteLine(ImportSales(context, salesInfo));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        //01. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            List<SupplierDto> supplierDtos = new List<SupplierDto>();
            XmlRootAttribute rootSupplier = new XmlRootAttribute();
            rootSupplier.ElementName = "Suppliers";

            XmlSerializer serializer = new XmlSerializer(typeof(List<SupplierDto>), rootSupplier);

            using (StringReader reader = new StringReader(inputXml))
            {
                supplierDtos = (List<SupplierDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();

            List<Supplier> suppliers = mapper.Map<List<Supplier>>(supplierDtos);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {supplierDtos.Count}";
        }

        //02. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            List<int> existingSupplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            List<PartDto> partDtos = new List<PartDto>();
            XmlRootAttribute rootParts = new XmlRootAttribute();
            rootParts.ElementName = "Parts";

            XmlSerializer serializer = new XmlSerializer(typeof(List<PartDto>), rootParts);

            using (StringReader reader = new StringReader(inputXml))
            {
                partDtos = (List<PartDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();

            List<Part> parts = mapper.Map<List<Part>>(partDtos)
                .Where(x => existingSupplierIds.Contains(x.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //03. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            List<int> existingPartIds = context.Parts
                .Select(p => p.Id)
                .ToList();

            List<CarDto> carDtos = new List<CarDto>();
            XmlRootAttribute carsRoot = new XmlRootAttribute();
            carsRoot.ElementName = "Cars";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CarDto>), carsRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                carDtos = (List<CarDto>)serializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car currentCar = new Car();
                currentCar.Make = carDto.Make;
                currentCar.Model = carDto.Model;
                currentCar.TravelledDistance = carDto.TravelledDistance;

                foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    if(existingPartIds.Contains(partId))
                    {
                        PartCar currentPart = new PartCar();
                        currentPart.PartId = partId;
                        currentPart.CarId = currentCar.Id;

                        currentCar.PartCars.Add(currentPart);
                    }                
                }

                cars.Add(currentCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //04. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            XmlRootAttribute customerRoot = new XmlRootAttribute();
            customerRoot.ElementName = "Customers";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerDto>), customerRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                customerDtos = (List<CustomerDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();

            List<Customer> customers = mapper.Map<List<Customer>>(customerDtos);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //05. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            List<int> exisitngCarsIds = context.Cars
                .Select(c => c.Id)
                .ToList();

            List<SaleDto> saleDtos = new List<SaleDto>();
            XmlRootAttribute salesRoot = new XmlRootAttribute();
            salesRoot.ElementName = "Sales";

            XmlSerializer serializer = new XmlSerializer(typeof(List<SaleDto>), salesRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                saleDtos = (List<SaleDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();

            List<Sale> sales = mapper.Map<List<Sale>>(saleDtos)
                .Where(x => exisitngCarsIds.Contains(x.CarId))
                .ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //06. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<CarsWithDistanceDto> cars = context.Cars
                .ProjectTo<CarsWithDistanceDto>(mapper.ConfigurationProvider)
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            return GenerateOutput<List<CarsWithDistanceDto>>("cars", cars);
        }

        //07. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<CarsFromMakeBMWDto> cars = context.Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<CarsFromMakeBMWDto>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            return GenerateOutput<List<CarsFromMakeBMWDto>>("cars", cars);
                
        }

        //08. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<LocalSuppliersDto> suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<LocalSuppliersDto>(mapper.ConfigurationProvider)
                .ToList();

            return GenerateOutput<List<LocalSuppliersDto>>("suppliers", suppliers);
        }

        //09. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<ExportCarDto> cars = context.Cars
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            return GenerateOutput<List<ExportCarDto>>("cars", cars);

        }

        //10. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<CustomersWithSalesDto> customers = context.Customers
                .Where(c => c.Sales.Any())
                .ProjectTo<CustomersWithSalesDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            return GenerateOutput<List<CustomersWithSalesDto>>("customers", customers);
        }

        //11. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();

            List<ExportSalesWithDiscountDto> sales = context.Sales
                .ProjectTo<ExportSalesWithDiscountDto>(mapper.ConfigurationProvider)
                .ToList();

            return GenerateOutput<List<ExportSalesWithDiscountDto>>("sales", sales);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
        public static string GenerateOutput<T>(string rootName, T dtoParam)
        {
            XmlRootAttribute productRoot = new XmlRootAttribute();
            productRoot.ElementName = rootName;

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(T), productRoot);

            using (TextWriter writer = new StreamWriter("result.xml"))
            {
                serializer.Serialize(writer, dtoParam, namespaces);
            }

            string result = File.ReadAllText("result.xml");
            return result;
        }
    }
}