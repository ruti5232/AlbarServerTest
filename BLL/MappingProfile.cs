using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Log, LogDTO>().ReverseMap();
        }
    }
}
