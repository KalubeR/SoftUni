using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var json = File.ReadAllText(
                @"D:\Projects\C#-DB\C#-DB - Entity Framework\Json_02\CarDealer\Datasets\sales.json");
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => supplierIds.Contains(x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);
            context.Cars.AddRange(cars);
            var result = context.SaveChanges();
            var list = new List<PartCar>();
            foreach (var car in cars)
            {
                foreach (var partCar in car.PartCars)
                {
                    var partCarToDb = new PartCar
                    {
                        PartId = partCar.PartId,
                    };
                    list.Add(partCarToDb);
                }

                context.PartCars.AddRange(list);
                context.SaveChanges();
            }
           
            return $"Successfully imported {result}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            var result = context.SaveChanges();

            return $"Successfully imported {result}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars
                        .Select(y => new
                        {
                            y.Part.Name,
                            Price = $"{y.Part.Price:f2}"
                        })
                        .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(c => c.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var serialized = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            return serialized;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new
                {
                    car = new
                    {
                        x.Car.Make,
                        x.Car.Model,
                        x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:f2}",
                    price = $"{x.Car.PartCars.Sum(c => c.Part.Price):f2}",
                    priceWithDiscount = $"{(x.Car.PartCars.Sum(c => c.Part.Price) - ((x.Car.PartCars.Sum(c => c.Part.Price)) * x.Discount / 100)):f2}"
                })
                .ToList()
                .Take(10);

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }
    }
}