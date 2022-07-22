using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersData = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(context, usersData));

            string productsData = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(context, productsData));

            string categoriesData = File.ReadAllText("../../../Datasets/categories.xml");
            Console.WriteLine(ImportCategories(context, categoriesData));

            string categoriesProductsData = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(context, categoriesProductsData));

            Console.WriteLine(GetUsersWithProducts(context));


        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            List<UserDto> usersDtos = new List<UserDto>();
            XmlRootAttribute rootUser = new XmlRootAttribute();
            rootUser.ElementName = "Users";

            XmlSerializer serializer = new XmlSerializer(typeof(List<UserDto>), rootUser);

            using (StringReader reader = new StringReader(inputXml))
            {
                usersDtos = (List<UserDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();
            List<User> users = mapper.Map<List<User>>(usersDtos);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02.Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            List<ProductDto> productsDtos = new List<ProductDto>();
            XmlRootAttribute productsRoot = new XmlRootAttribute();
            productsRoot.ElementName = "Products";

            XmlSerializer serializer = new XmlSerializer(typeof(List<ProductDto>), productsRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                productsDtos = (List<ProductDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();
            List<Product> products = mapper.Map<List<Product>>(productsDtos);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            XmlRootAttribute categoryRoot = new XmlRootAttribute();
            categoryRoot.ElementName = "Categories";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryDto>), categoryRoot);

            using(StringReader reader = new StringReader(inputXml))
            {
                categoryDtos = (List<CategoryDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();
            List<Category> categories = mapper.Map<List<Category>>(categoryDtos)
                .Where(x => x.Name != null)
                .ToList();

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            List<int> existingCategoryIds = context.Categories
                .Select(c => c.Id)
                .ToList();

            List<int> existingProductsIds = context.Products
                .Select(p => p.Id)
                .ToList();

            List<CategoryProductDto> categoryProductDtos = new List<CategoryProductDto>();
            XmlRootAttribute categoryProductRoot = new XmlRootAttribute();
            categoryProductRoot.ElementName = "CategoryProducts";

            XmlSerializer serializer = new XmlSerializer(typeof(List<CategoryProductDto>), categoryProductRoot);

            using (StringReader reader = new StringReader(inputXml))
            {
                categoryProductDtos = (List<CategoryProductDto>)serializer.Deserialize(reader);
            }

            IMapper mapper = CreateMapper();
            List<CategoryProduct> categoriesProducts = mapper.Map<List<CategoryProduct>>(categoryProductDtos)
                .Where(x => existingCategoryIds.Contains(x.CategoryId) && existingProductsIds.Contains(x.ProductId))
                .ToList();

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";

        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var products = context.Products
              .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)             
              .Where(p => p.Price >= 500 && p.Price <= 1000)
              .OrderBy(p => p.Price)
              .Take(10)
              .ToList();

            return GenerateOutput<List<ExportProductDto>>("Products", products);                   
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            return GenerateOutput<List<ExportUserDto>>("Users", users);
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var categories = context.Categories
                .ProjectTo<ExportCategoryDto>(mapper.ConfigurationProvider)
                 .OrderByDescending(c => c.Count)
                 .ThenBy(c => c.TotalRevenue)
                 .ToList();

            return GenerateOutput<List<ExportCategoryDto>>("Categories", categories);

        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDto
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .OrderByDescending(x => x.Price)
                        .Select(x => new ExportSoldProductsDto
                        {
                            Name = x.Name,
                            Price = $"{x.Price}"
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Products.Count)
                .Take(10)
                .ToList();

            var resultObj = new
            {
                count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = users

            };

            return GenerateOutput<T>("Users", resultObj);
        }
        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
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