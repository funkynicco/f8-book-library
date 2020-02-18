using AutoMapper;
using CarRentals.Areas.Admin.Models;
using CarRentals.Areas.Default.Models;
using CarRentals.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentals
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappings(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarViewModel>().ReverseMap();
                cfg.CreateMap<CreateCarViewModel, CarDetails>().ReverseMap();
                cfg.CreateMap<CreateCarViewModel, Car>().ReverseMap();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
