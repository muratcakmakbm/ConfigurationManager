using ConfigurationManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigurationManager.Data
{
    public interface IConfigurationRepository
    {
        public Task Save(ConfigurationModel model);
        public Task<List<ConfigurationModel>> GetAll();
        public Task<ConfigurationModel> Get(string id);
        public Task<ConfigurationModel> GetByKey(string key);
    }
}
