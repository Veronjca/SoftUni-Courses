using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

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

        public static IMapper CreateMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}