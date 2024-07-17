using AutoMapper;
using ExchangeRate.Core.DbModels;
using ExchangeRate.Core.LogModels;
using ExchangeRate.Helpers.Models.Dtos.DbModelDtos;
using ExchangeRate.Helpers.Models.Dtos.LogModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<UserLog, UserLogDto>().ReverseMap();
            CreateMap<ErrorLog, ErrorLogDto>().ReverseMap();
            CreateMap<ApplicationLog, ApplicationLogDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();


        }
    }
}
