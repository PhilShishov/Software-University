
namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using CarDealer.DTO;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<CarInsertDto, Car>();
        }
    }
}
