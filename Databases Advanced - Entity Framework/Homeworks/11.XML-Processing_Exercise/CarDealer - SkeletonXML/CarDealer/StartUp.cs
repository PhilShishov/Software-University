
namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}";
        private readonly IMapper mapper;
        public static XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            QueryAndExport();
        }

        public static void QueryAndExport()
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                string result = GetSalesWithAppliedDiscount(context);
                //File.WriteAllText("../../../result.xml", result);
                Console.WriteLine(result);
            }
        }

        public void ImportXml()
        {
            //string suppliersXmlPath = @"../../../Datasets/suppliers.xml";
            //string partsXmlPath = @"../../../Datasets/parts.xml";
            //string carsXmlPath = @"../../../Datasets/cars.xml";
            //string customersXmlPath = @"../../../Datasets/customers.xml";
            string salesXmlPath = @"../../../Datasets/sales.xml";

            if (File.Exists(salesXmlPath))
            {
                var inputXml = File.ReadAllText(salesXmlPath);

                using (CarDealerContext context = new CarDealerContext())
                {
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    var output = ImportSales(context, inputXml);
                    Console.WriteLine(output);
                }
            }
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //<sales>
            //<sale>
            //  <car make = "BMW" model="M5 F10" travelled-distance="435603343" />
            //  <discount>30.00</discount>
            //  <customer-name>Hipolito Lamoreaux</customer-name>
            //  <price>707.97</price>
            //  <price-with-discount>495.58</price-with-discount>
            //</ExportSaleDiscount>

            var sb = new StringBuilder();

            var sales = context.Sales
                .Select(s => new ExportSalesWithAppliedDiscountDto
                {
                    Car = new ExportCarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Select(p => p.Part.Price).Sum(),
                    PriceWithDiscount = (s.Car.PartCars.Select(p => p.Part.Price).Sum() * (1 - s.Discount / 100)).ToString("G29")
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportSalesWithAppliedDiscountDto>), new XmlRootAttribute("sales"));

            serializer.Serialize(new StringWriter(sb), sales, Namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportTotalSalesByCustomerDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts.For the car get only make, 
            //    model and travelled distance and for the parts get only name 
            //    and price and sort all pars by price(descending).
            //    Sort all cars by travelled distance(descending) 
            //    then by model(ascending).Select top 5 records.

            var cars = context
                .Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new ExportCarsWithTheirListOfPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    PartDtos = context.PartCars
                            .Where(pc => pc.CarId == c.Id)
                            .Select(pc => new PartDto
                            {
                                Name = pc.Part.Name,
                                Price = pc.Part.Price
                            })
                            .OrderByDescending(pc => pc.Price)
                            .ToArray()
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithTheirListOfPartsDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Get all suppliers that do not import parts from abroad.
            //Get their id, name and the number of parts they can offer to supply.

            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            //Get all cars from make BMW and order them by model a
            //    lphabetically and by travelled distance descending.

            var cars = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarsFromMakeBmwDto
                {
                    CarId = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMakeBmwDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            //Get all cars with distance more than 2,000,000.
            //Order them by make, then by model alphabetically. Take top 10 records.

            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }


        public string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]),
                                            new XmlRootAttribute("Sales"));

            var salesDto = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                var carsIds = context.Cars.Select(c => c.Id).ToArray();

                if (!carsIds.Contains(saleDto.CarId))
                {
                    continue;
                }

                var sale = this.mapper.Map<Sale>(saleDto);

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return string.Format(ImportMessage, sales.Count);
        }

        public string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]),
                                            new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = this.mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return string.Format(ImportMessage, customers.Count);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsParsed = XDocument.Parse(inputXml)
                           .Root
                           .Elements()
                           .ToList();

            var cars = new List<Car>();

            var existingPartsIds = context.Parts
                .Select(x => x.Id)
                .ToArray();

            foreach (var x in carsParsed)
            {
                Car currentCar = new Car()
                {
                    Make = x.Element("make").Value,
                    Model = x.Element("model").Value,
                    TravelledDistance = Convert.ToInt64(x.Element("TraveledDistance").Value)
                };

                var partIds = new HashSet<int>();

                foreach (var id in x.Element("parts").Elements())
                {
                    var pid = Convert.ToInt32(id.Attribute("id").Value);
                    partIds.Add(pid);
                }

                foreach (var pid in partIds)
                {
                    PartCar currentPair = new PartCar()
                    {
                        Car = currentCar,
                        PartId = pid
                    };

                    if (existingPartsIds.Contains(pid) == false)
                        continue;

                    currentCar.PartCars.Add(currentPair);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]),
                                            new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                var suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

                if (!suppliersIds.Contains(partDto.SupplierId))
                {
                    continue;
                }
                var part = this.mapper.Map<Part>(partDto);

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return string.Format(ImportMessage, parts.Count);
        }

        public string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]),
                                            new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = this.mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return string.Format(ImportMessage, suppliers.Count);
        }
    }
}