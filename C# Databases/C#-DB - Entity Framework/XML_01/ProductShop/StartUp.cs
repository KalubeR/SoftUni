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

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());

            var context = new ProductShopContext();

            var xml = File.ReadAllText(
                @"D:\Projects\C#-DB\C#-DB - Entity Framework\XML_01\ProductShop\Datasets\categories-products.xml");
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]),
                new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                //var userr = Mapper.Map<User>(userDto);
                User user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.FirstName,
                    Age = userDto.Age
                };
                users.Add(user);
            }

            context.Users.AddRange(users);
            var result = context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]),
                new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                products.Add(product);
            }

            context.Products.AddRange(products);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]),
                new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var importCategoryDto in categoriesDto)
            {
                if (importCategoryDto.Name == null)
                {
                    continue;
                }

                var category = new Category
                {
                    Name = importCategoryDto.Name
                };
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto =
                (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            var validCategoryIds = context.Categories.Select(x => x.Id);
            var validProductIds = context.Products.Select(x => x.Id);

            foreach (var importCategoryProductDto in categoryProductsDto)
            {
                if (!validCategoryIds.Contains(importCategoryProductDto.CategoryId) ||
                    !validProductIds.Contains(importCategoryProductDto.ProductId))
                {
                    continue;
                }

                var categoryProduct = new CategoryProduct
                {
                    CategoryId = importCategoryProductDto.CategoryId,
                    ProductId = importCategoryProductDto.ProductId
                };
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductDto[]),
                new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new ExportUserDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Where(p => p.Buyer != null)
                        .Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]),
                new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
               new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new ExportCategoryDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]),
                new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .OrderByDescending(x => x.ProductsSold.Count(p => p.Buyer != null))
                .Select(x => new ExportUserAndProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductDto
                        {
                            Count = x.ProductsSold.Count,
                            Products = x.ProductsSold.Where(p => p.Buyer != null).Select(y => new ProductDto
                                {
                                    Name = y.Name,
                                    Price = y.Price
                                })
                                .OrderByDescending(n => n.Price)
                                .ToArray()
                        }
                })
                .Take(10)
                .ToArray();

            var usersToExport = new UsersDto
            {
                Count = context.Users
                    .Count(x => x.ProductsSold.Any(y => y.Buyer != null)),
                Users = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersDto),
                new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new []
            {
                new XmlQualifiedName("",""),
            });

            xmlSerializer.Serialize(new StringWriter(sb), usersToExport, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}