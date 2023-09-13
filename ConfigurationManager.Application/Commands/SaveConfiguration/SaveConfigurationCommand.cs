using ConfigurationManager.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace ConfigurationManager.Application.Commands.SaveConfiguration
{
    public class SaveConfigurationCommand : IRequest<SaveConfigurationCommandResult>
    {
        public ConfigurationDto Configuration { get; set; }
    }
}
