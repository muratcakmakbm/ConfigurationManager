using ConfigurationManager.Application.Dto;
using ConfigurationManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationManager.Web.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly ILogger<ConfigurationController> _logger;
        public ConfigurationManager _configurationManager;
        public ConfigurationController(ILogger<ConfigurationController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _configurationManager = new ConfigurationManager(
                serviceProvider,
                10, "Example");

        }

        public IActionResult ConfigurationList()
        {
            return View();
        }

        public JsonResult GetConfiguration(string id)
        {
            var configuration = _configurationManager.Configurations.FirstOrDefault(i => i.id == id);
            return Json(configuration);
        }
        [HttpPost]
        public JsonResult SaveConfiguration([FromBody]ConfigurationDto configuration)
        {
            _configurationManager.SaveConfiguration(configuration);
            return Json(configuration);
        }

        public JsonResult GetConfigurationList()
        {
            _configurationManager.GetAllConfigurations();
            return Json(_configurationManager.Configurations);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
