using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string usersData = File.ReadAllText("../../../Datasets/users.json");
            string productsData = File.ReadAllText("../../../Datasets/products.json");
            string categoriesData = File.ReadAllText("../../../Datasets/categories.json");
            string categoryProductsData = File.ReadAllText("../../../Datasets/categories-products.json");

            ImportUsers(context, usersData);
            ImportProducts(context, productsData);
            ImportCategories(context, categoriesData);
            ImportCategoryProducts(context, categoryProductsData);

            Console.WriteLine(GetUsersWithProducts(context));
        }
        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = new List<Product>();
            products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            List<Category> categories = new List<Category>();
            categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, settings)
                                     .Where(x => x.Name != null).ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
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

            var products = context.Products
                .Include(p => p.Seller)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName

                })
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ToList();

            string productsJson = JsonConvert.SerializeObject(products, settings);

            return productsJson;
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
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

            var usersProducts = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(p => p.Buyer)
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Count(p => p.BuyerId != null) > 0)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                    .Where(p => p.BuyerId != null )
                                    .Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price,
                                        BuyerFirstName = p.Buyer.FirstName,
                                        BuyerLastName = p.Buyer.LastName
                                    })
                                    .ToList()
                })                
                 .OrderBy(u => u.LastName)
                 .ThenBy(u => u.FirstName)
                 .ToList();

            string usersSoldProductsJson = JsonConvert.SerializeObject(usersProducts, settings);

            return usersSoldProductsJson;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
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
            var categories = context.Categories
                                    .Include(c => c.CategoryProducts)
                                    .ThenInclude(cp => cp.Product)
                                    .Select(c => new
                                    {
                                        Category = c.Name,
                                        ProductsCount = c.CategoryProducts.Count,
                                        AveragePrice = $"{c.CategoryProducts.Average(p => p.Product.Price):f2}",
                                        TotalRevenue = $"{c.CategoryProducts.Sum(p => p.Product.Price):f2}"
                                    })
                                    .OrderByDescending(c => c.ProductsCount)
                                    .ToList();

            string categoriesJson = JsonConvert.SerializeObject(categories, settings);

            return categoriesJson;
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
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
                },
                NullValueHandling = NullValueHandling.Ignore
            };
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ThenInclude(ps => ps.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .Where(u => u.ProductsSold.Count > 0 && u.ProductsSold.Count(p => p.BuyerId != null) > 0)
                .Select(u => new
                {                   
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                                    .Where(p => p.BuyerId != null)
                                    .Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                    .ToList()
                    }

                })
                .OrderByDescending(u => u.SoldProducts.Products.Count)
                .ToList();

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDto>();
                c.CreateMap<Product, ProductDto>();
            });

            var mapper = config.CreateMapper();

            string usersJson = JsonConvert.SerializeObject(userDto, settings);

            return usersJson;
        }

        public class UserDto
        {
            public int Count { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }
            public List<Product> SoldProducts { get; set; }
        }

        public class ProductDto
        {
            public int Count { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}