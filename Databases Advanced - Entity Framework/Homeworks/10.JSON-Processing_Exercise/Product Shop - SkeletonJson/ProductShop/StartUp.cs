
namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    using Data;
    using Models;
    using DTOs.Export;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}";

        public static void Main()
        {
            //var categoriesProductsJson = File.ReadAllText(@"D:\Documents\Visual Studio 2017\DBFundamentals\Product Shop - Skeleton\ProductShop\Datasets\categories-products.json");

            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                var result = GetUsersWithProducts(context);
                Console.WriteLine(result);
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Count(ps => ps.Buyer != null),
                        Products = u.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(ps =>
                                new
                                {
                                    Name = ps.Name,
                                    Price = ps.Price
                                })
                                .ToArray()
                    }
                })
                .ToArray();

            var result = new
            {
                UsersCount = users.Length,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(
                result,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = $"{x.CategoryProducts.Average(c => c.Product.Price):F2}",
                    TotalRevenue = $"{x.CategoryProducts.Sum(c => c.Product.Price)}"
                })
                .ToList();

            string json = JsonConvert.SerializeObject(categories,
                new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(),
                    },

                    Formatting = Formatting.Indented
                }
            );

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var filteredUsers = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                                .Where(ps => ps.Buyer != null)
                                .Select(ps => new
                                {
                                    Name = ps.Name,
                                    Price = ps.Price,
                                    BuyerFirstName = ps.Buyer.FirstName,
                                    BuyerLastName = ps.Buyer.LastName
                                })
                                .ToArray()
                })
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(
                filteredUsers,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ContractResolver = contractResolver
                });

            return json;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            //var validCategoryIds = new HashSet<int>(
            //    context
            //    .Categories
            //    .Select(c => c.Id));

            //var validProductIds = new HashSet<int>(
            //    context
            //    .Products
            //    .Select(p => p.Id));

            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            //var validEntities = new List<CategoryProduct>();

            //foreach (var categoryProduct in categoriesProducts)
            //{
            //    var isValid = validCategoryIds.Contains(categoryProduct.CategoryId) &&
            //                  validProductIds.Contains(categoryProduct.ProductId);


            //    if (isValid)
            //    {
            //        validEntities.Add(categoryProduct);
            //    }
            //}

            context.CategoryProducts.AddRange(categoriesProducts); /*validEntities*/
            context.SaveChanges();

            return string.Format(ImportMessage, categoriesProducts.Length); /*validEntities*/
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name) &&
                            c.Name.Length >= 3 &&
                            c.Name.Length <= 15)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return string.Format(ImportMessage, categories.Length);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return string.Format(ImportMessage, products.Length);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            var validUsers = new List<User>();

            foreach (var user in users)
            {
                if (user.LastName == null || user.LastName.Length < 3)
                {
                    continue;
                }

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return string.Format(ImportMessage, validUsers.Count);
        }
    }
}