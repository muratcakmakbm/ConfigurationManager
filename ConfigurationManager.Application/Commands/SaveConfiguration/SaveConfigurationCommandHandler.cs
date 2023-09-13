using AutoMapper;
using ConfigurationManager.Data;
using ConfigurationManager.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigurationManager.Application.Commands.SaveConfiguration
{
    public class SaveConfigurationCommandHandler : IRequestHandler<SaveConfigurationCommand, SaveConfigurationCommandResult>
    {
        private readonly IConfigurationRepository _repository;
        private readonly IMapper _mapper;
        public SaveConfigurationCommandHandler(IConfigurationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaveConfigurationCommandResult> Handle(SaveConfigurationCommand request, CancellationToken cancellationToken)
        {
            var configuration = new ConfigurationModel();
            _mapper.Map(request.Configuration, configuration);

            await _repository.Save(configuration);
            return new SaveConfigurationCommandResult();
        }
    }
}
