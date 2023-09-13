using AutoMapper;
using ConfigurationManager.Application.Dto;
using ConfigurationManager.Domain;

namespace ConfigurationManager.Application
{
    public class ConfigurationAutoMapping : Profile
    {
        public ConfigurationAutoMapping()
        {
            CreateMap<ConfigurationModel, ConfigurationDto>().ReverseMap();
        }
    }
}
