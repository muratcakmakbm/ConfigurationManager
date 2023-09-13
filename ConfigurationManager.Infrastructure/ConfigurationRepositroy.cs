using ConfigurationManager.Data;
using ConfigurationManager.Domain;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConfigurationManager.Infrastructure
{
    public class ConfigurationRepositroy : IConfigurationRepository
    {
        private readonly IConnectionMultiplexer _redis;
        public ConfigurationRepositroy(IConnectionMultiplexer redis)
        {
            _redis = redis;
         
        }
        public async Task Save(ConfigurationModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
                model.Id = Guid.NewGuid().ToString();

            if (model == null)
            {
                throw new ArgumentOutOfRangeException(nameof(model));
            }
            var db = _redis.GetDatabase();
            var serializedModel = JsonSerializer.Serialize(model);

            db.StringSet(model.Id, serializedModel);
            db.HashSet("ConfigurationSet", new HashEntry[] { new HashEntry(model.Id, serializedModel) });
        }

        public async Task<ConfigurationModel?> Get(string id)
        {
            var db = _redis.GetDatabase();

            var serializedModel = db.StringGet(id);

            if (!string.IsNullOrEmpty(serializedModel))
                return JsonSerializer.Deserialize<ConfigurationModel>(serializedModel);

            return null;
        }

        public async Task<List<ConfigurationModel>> GetAll()
        {
            var db = _redis.GetDatabase();

            var modelList = db.HashGetAll("ConfigurationSet");

            if (modelList.Length > 0)
            {
                var obj = Array.ConvertAll(modelList, val => JsonSerializer.Deserialize<ConfigurationModel>(val.Value)).ToList();
                return obj;
            }
            return null;
        }

        public Task<ConfigurationModel> GetByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}
