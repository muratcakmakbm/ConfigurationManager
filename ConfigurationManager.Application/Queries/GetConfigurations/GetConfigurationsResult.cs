using ConfigurationManager.Application.Dto;
using System.Collections.Generic;

namespace ConfigurationManager.Application.Queries.GetConfigurations
{
    public class GetConfigurationsResult
    {
        public GetConfigurationsResult()
        {
            Configurations = new List<ConfigurationDto>();
        }
        public List<ConfigurationDto> Configurations { get; set; }
    }
}
