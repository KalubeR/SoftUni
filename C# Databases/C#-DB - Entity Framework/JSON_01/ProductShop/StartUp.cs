using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //var json = File.ReadAllText(
            //    @"D:\Projects\C#-DB\C#-DB - Entity Framework\JSON_01\ProductShop\Datasets\categories-products.json");
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length >= 3)
                .ToList();

            context.Products.AddRange(products);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(x => new ProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    //Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Select(x => new UserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                        .Where(b => b.Buyer != null)
                        .Select(y => new ProductDto
                        {
                            Name = y.Name,
                            Price = y.Price,
                            //BuyerFirstName = y.Buyer.FirstName,
                            //BuyerLastName = y.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new CategoryDto
                {
                    CategoryName = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = $"{x.CategoryProducts.Average(y => y.Product.Price):f2}",
                    TotalRevenue = $"{x.CategoryProducts.Sum(p => p.Product.Price)}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(y => y.Buyer != null))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold
                            .Count(ps => ps.Buyer != null),
                       Products = x.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var usersCount = new
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var serialized = JsonConvert.SerializeObject(usersCount, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            
            return serialized;
        }
    }
}