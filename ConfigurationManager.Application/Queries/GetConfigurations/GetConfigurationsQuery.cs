using AutoMapper;
using ConfigurationManager.Application.Dto;
using ConfigurationManager.Data;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace ConfigurationManager.Application.Queries.GetConfigurations
{
    public class GetConfigurationsQuery : IRequestHandler<GetConfigurationsFilter, GetConfigurationsResult>
    {
        private readonly IConfigurationRepository _repository;
        private readonly IMapper _mapper;
        public GetConfigurationsQuery(IConfigurationRepository repository, IMapper maapper)
        {
            _repository = repository;
            _mapper = maapper;
        }
        public async Task<GetConfigurationsResult> Handle(GetConfigurationsFilter request, CancellationToken cancellationToken)
        {
            var configurationList = _repository.GetAll().Result;
            var list = _mapper.Map<List<ConfigurationDto>>(configurationList);

            var result = new GetConfigurationsResult()
            {
                Configurations = list
            };
            return result;
        }
    }
}
