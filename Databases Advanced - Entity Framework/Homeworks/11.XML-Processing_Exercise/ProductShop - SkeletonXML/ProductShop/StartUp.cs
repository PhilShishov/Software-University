
namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using AutoMapper;

    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class StartUp
    {
        private readonly IMapper mapper;
        private const string ImportMessage = "Successfully imported {0}";

        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            var mapper = config.CreateMapper();

            QueryAndExport();
        }

        public static void QueryAndExport()
        {
            using (var context = new ProductShopContext())
            {
                string result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        public void Import()
        {
            //string usersXmlPath = @"../../../Datasets/users.xml";
            //string productsXmlPath = @"../../../Datasets/products.xml";
            //string categoriesXmlPath = @"../../../Datasets/categories.xml";
            string categoriesProductsXmlPath = @"../../../Datasets/categories-products.xml";

            if (File.Exists(categoriesProductsXmlPath))
            {
                var inputXml = File.ReadAllText(categoriesProductsXmlPath);

                using (var context = new ProductShopContext())
                {
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    var output = ImportCategoryProducts(context, inputXml);
                    Console.WriteLine(output);
                }
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
               .Users
               .Where(u => u.ProductsSold.Any())
               .Select(u => new ExportUsersWithProductsDto
               {
                   FirstName = u.FirstName,
                   LastName = u.LastName,
                   Age = u.Age,
                   SoldProductDto = new SoldProductDto
                   {
                       Count = u.ProductsSold.Count,
                       ProductDtos = u.ProductsSold
                               .Select(ps => new ProductDto
                               {
                                   Name = ps.Name,
                                   Price = ps.Price
                               })
                               .OrderByDescending(ps => ps.Price)
                               .ToArray()
                   }
               })
               .OrderByDescending(u => u.SoldProductDto.Count)
               .Take(10)
               .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = context
                    .Users
                    .Count(c => c.ProductsSold.Any()),
                ExportUsersWithProductsDto = users
            };

            var xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto),
                new XmlRootAttribute("Users"));
            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //Get all categories.For each category select its name, the number of products, 
            //the average price of those products and the total revenue(total price sum) 
            //    of those products(regardless if they have a buyer or not). 
            //Order them by the number of products(descending) then by total revenue.

            var categories = context
                .Categories
                .Select(c => new ExportCategoriesByProductsDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsDto[]),
                new XmlRootAttribute("Categories"));
            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item. Order them by last name, then by first name. 
            //    Select the person's first and last name. For each of the sold products, 
            //    select the product's name and price. Take top 5 records.

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new ProductDto
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductDto[]),
                new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            //Get all products in a specified price range between 500 and 1000(inclusive).
            //    Order them by price(from lowest to highest).Select only the product name, 
            //price and the full name of the buyer.Take top 10 records.

            var products = context
                     .Products
                     .Where(p => p.Price >= 500 && p.Price <= 1000)
                     .Select(p => new ExportProductInRangeDto
                     {
                         Name = p.Name,
                         Price = p.Price,
                         Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                     })
                     .OrderBy(p => p.Price)
                     .Take(10)
                     .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]),
                new XmlRootAttribute("Products"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductsDto[]),
                                            new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductsDto[])xmlSerializer
                .Deserialize(new StringReader(inputXml));
            var categoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var product = context.Products.Find(categoryProductDto.ProductId);
                var category = context.Categories.Find(categoryProductDto.CategoryId);

                if (product == null || category == null)
                {
                    continue;
                }

                var categoryProduct = this.mapper.Map<CategoryProduct>(categoryProductDto);

                //var categoryProduct = new CategoryProduct
                //{
                //    ProductId = product.Id,
                //    CategoryId = category.Id
                //}
                categoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return string.Format(ImportMessage, categoriesProducts.Count);
        }

        public string ImportCategories(ProductShopContext context, string importData)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                                            new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer
                .Deserialize(new StringReader(importData));
            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {

                if (categoryDto.Name == null)
                {
                    continue;
                }
                var category = this.mapper.Map<Category>(categoryDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return string.Format(ImportMessage, categories.Count);
        }

        public string ImportProducts(ProductShopContext context, string importData)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                                            new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer
                .Deserialize(new StringReader(importData));
            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = this.mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return string.Format(ImportMessage, products.Count);
        }

        public string ImportUsers(ProductShopContext context, string importData)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]),
                                            new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(importData));
            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = this.mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return string.Format(ImportMessage, users.Count);
        }
    }
}