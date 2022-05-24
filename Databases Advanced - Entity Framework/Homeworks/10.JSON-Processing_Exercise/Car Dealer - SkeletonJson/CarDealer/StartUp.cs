
namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        private readonly IMapper mapper;

        public StartUp(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public static void Main()
        {
            //using (var context = new CarDealerContext())
            //{

            //}

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            QueryAndExport();
        }

        public static void QueryAndExport()
        {
            using (var context = new CarDealerContext())
            {
                string result = GetSalesWithAppliedDiscount(context);
                Console.WriteLine(result);
            }
        }

        private static bool IsValid(object @object)
        {
            var validations = new List<ValidationResult>();

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(@object);

            bool isValid = Validator.TryValidateObject(@object, validationContext, validations, true);

            return isValid;
        }

        public static void Insert()
        {
            string carsPath = @"../../../Datasets/cars.json";
            string customersPath = @"../../../Datasets/customers.json";
            string partsPath = @"../../../Datasets/parts.json";
            string salesPath = @"../../../Datasets/sales.json";
            string suppliersPath = @"../../../Datasets/suppliers.json";

            if (File.Exists(salesPath))
            {
                var importData = File.ReadAllText(salesPath);

                using (var context = new CarDealerContext())
                {
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    string output = ImportSales(context, importData);
                    Console.WriteLine(output);
                }
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var existingSuppliers = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => existingSuppliers.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<CarInsertDto[]>(inputJson);
            var mappedCars = new List<Car>();

            foreach (var car in cars)
            {
                var vehicle = this.mapper.Map<CarInsertDto, Car>(car);
                mappedCars.Add(vehicle);

                var partIds = car
                .PartsId
                .Distinct()
                .ToList();

                if (partIds == null)
                    continue;

                partIds.ForEach(pid =>
                {
                    var currentPair = new PartCar()
                    {
                        Car = vehicle,
                        PartId = pid
                    };

                    vehicle.PartCars.Add(currentPair);
                }
                );

            }

            context.Cars.AddRange(mappedCars);

            context.SaveChanges();
            int affectedRows = context.Cars.Count();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {

            var customers = context.Customers
                .ToList()
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();


            string json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,

                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {

            var toyotas = context.Cars
                .Where(c => string.Compare(c.Make, "Toyota", true) == 0)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string json = JsonConvert.SerializeObject(toyotas, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });


            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },

                    parts = c.PartCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .Where(c => c.Sales.Count >= 1)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .ToList()
                .OrderByDescending(a => a.SpentMoney)
                .ThenBy(a => a.BoughtCars)
                .ToList();


            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:F2}",
                    price = $"{x.Car.PartCars.Sum(y => y.Part.Price):F2}",
                    priceWithDiscount = $"{x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount / 100)):F2}",
                })
                .ToList();

            var json = JsonConvert.SerializeObject(sales, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                //ContractResolver = new DefaultContractResolver()
                //{
                //    NamingStrategy = new CamelCaseNamingStrategy()
                //}
            });

            return json;
        }
    }
}