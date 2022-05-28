namespace SoftJail.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;

    using Newtonsoft.Json;

    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentsCellsDto[]>(jsonString);

            var sb = new StringBuilder();
            var departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                var isValid = IsValid(departmentDto) &&
                    departmentDto.Cells.All(IsValid);

                var department = new Department
                {
                    Name = departmentDto.Name
                };

                foreach (var cellDto in departmentDto.Cells)
                {
                    department.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (isValid)
                {
                    departments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }

                else
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);

            var sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                var isValid = IsValid(prisonerDto) &&
                    prisonerDto.Mails.All(IsValid);

                if (isValid)
                {
                    //var releaseDate = prisonerDto.ReleaseDate == null
                    //    ? (DateTime?)null  new DateTime?()
                    //    : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var prisoner = new Prisoner
                    {
                        FullName = prisonerDto.FullName,
                        Nickname = prisonerDto.Nickname,
                        Age = prisonerDto.Age,
                        IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Bail = prisonerDto.Bail,
                        CellId = prisonerDto.CellId,
                        Mails = prisonerDto.Mails
                                .Select(m => new Mail
                                {
                                    Description = m.Description,
                                    Sender = m.Sender,
                                    Address = m.Address
                                })
                                .ToArray()
                    };

                    prisoners.Add(prisoner);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]),
                                           new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                var isValidPosition = Enum.TryParse<Position>(officerDto.Position, out Position positionType);
                var isValidWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weaponType);

                var isValid = IsValid(officerDto) && isValidPosition && isValidWeapon;

                if (isValid)
                {
                    var officer = new Officer
                    {
                        FullName = officerDto.Name,
                        Salary = officerDto.Money,
                        Position = positionType,
                        Weapon = weaponType,
                        DepartmentId = officerDto.DepartmentId,
                        OfficerPrisoners = officerDto.Prisoners
                                            .Select(of => new OfficerPrisoner
                                            {
                                                PrisonerId = of.PrisonerId
                                            })
                                            .ToArray()
                    };

                    officers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");

                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }

            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}