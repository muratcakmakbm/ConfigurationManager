using ConfigurationManager.Application.Commands.SaveConfiguration;
using ConfigurationManager.Application.Dto;
using ConfigurationManager.Application.Queries.GetConfigurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class ConfigurationManager
    {
        private readonly IMediator _mediator;
        private readonly string _applicationName;
        private readonly int _refreshTimerIntervalInMs;
        public ConfigurationManager(
            IServiceProvider serviceProvider,
            int refreshTimerIntervalInMs,
            string applicationName)
        {
            _mediator = (IMediator)serviceProvider.GetService(typeof(IMediator));
            _refreshTimerIntervalInMs = refreshTimerIntervalInMs;
            _applicationName = applicationName;
            Configurations = new List<ConfigurationDto>();
            AutoRefresh();

        }
        public List<ConfigurationDto> Configurations { get; set; }
        public async Task AutoRefresh()
        {
            while (true)
            {
                GetAllConfigurations();
                await Task.Delay(_refreshTimerIntervalInMs);
            }
        }

        public async Task GetAllConfigurations()
        {
            var result = await _mediator.Send(new GetConfigurationsFilter());
            Configurations = result.Configurations;
        }

        public Task<T> GetValue<T>(string key)
        {
            var configuration = Configurations.Where(i => i.name == key &&
            i.IsActive &&
            i.ApplicationName == _applicationName).FirstOrDefault();
            if (configuration != null)
            {
                Type type = Type.GetType(configuration.type);
                var result = (T)(object)configuration.name;
                return Task.FromResult(result);
            }

            return Task.FromResult(default(T));
        }

        public async Task SaveConfiguration(ConfigurationDto configuration)
        {
            configuration.ApplicationName = _applicationName;

            var result = await _mediator.Send(new SaveConfigurationCommand()
            {
                Configuration = configuration
            });
        }
    }
}
