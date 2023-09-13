using ConfigurationManager.Domain;
using System.Collections.Generic;

namespace ConfigurationManager.Data
{
    public interface IConfigurationRepository
    {
        void Create(ConfigurationModel model);
        void Update(ConfigurationModel model);
        void Delete(ConfigurationModel model);
        List<ConfigurationModel> GetAll();
        ConfigurationModel Get(string id);
    }
}
