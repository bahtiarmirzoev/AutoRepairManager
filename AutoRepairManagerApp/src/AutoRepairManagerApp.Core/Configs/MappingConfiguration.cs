using AutoMapper;
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;

namespace AutoRepairManagerApp.Core.Configs;


public class MappingConfiguration
{
    public static Mapper InitializeConfig()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MakeOrderRequest, MakeOrderRequestDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.TechnicalPassport, opt => opt.MapFrom(src => src.TechnicalPassport))
                    .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
                    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dest => dest.ProblemDescription, opt => opt.MapFrom(src => src.ProblemDescription));

                cfg.CreateMap<MakeOrderRequestDTO, MakeOrderRequest>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                    .ForMember(dest => dest.TechnicalPassport, opt => opt.MapFrom(src => src.TechnicalPassport))
                    .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
                    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dest => dest.ProblemDescription, opt => opt.MapFrom(src => src.ProblemDescription));
            });

            var mapper = new Mapper(mapperConfig);
            return mapper;
        }
}