using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDto, Supplier>();

            CreateMap<PartDto, Part>();

            CreateMap<CustomerDto, Customer>();

            CreateMap<SaleDto, Sale>();

            CreateMap<Car, CarsWithDistanceDto>();

            CreateMap<Car, CarsFromMakeBMWDto>();

            CreateMap<Supplier, LocalSuppliersDto>()
                .ForMember(dest => dest.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));

            CreateMap<Part, ExportPartDto>();

            CreateMap<Car, ExportCarDto>()
                .ForMember(dest => dest.Parts, opt => opt.MapFrom(src => src.PartCars.Select(pc => pc.Part).OrderByDescending(p => p.Price)));

            CreateMap<Customer, CustomersWithSalesDto>()
                .ForMember(dest => dest.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count()))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(s => s.Car.PartCars.Sum(x => x.Part.Price))));

            CreateMap<Car, ExportCarForSalesWithDiscountDto>();

            CreateMap<Sale, ExportSalesWithDiscountDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(dest => dest.PriceWithDiscount, opt => opt.MapFrom(src => src.Car.PartCars.Sum(pc => pc.Part.Price) - src.Car.PartCars.Sum(pc => pc.Part.Price) * (src.Discount / 100)));
        }
    }
}
