using DotNet.Core.Config.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DotNet.Core.Config.Controllers
{
    public class HomeController : Controller
    {
        // 1. Strongly Typed Configuration
        private ConnectionStrings ConnectionStrings { get; }

        // 2. String Configuration Values
        private IConfiguration Configuration { get; }

        public HomeController(IOptions<ConnectionStrings> settings, IConfiguration configuration)
        {
            ConnectionStrings = settings.Value;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            // Access the configuration data using configuration class
            ViewData["MongoConnection"] = ConnectionStrings.MongoConnection;
           
            // Access the configuration data using string identification 
            ViewData["SqlConnection"] = Configuration.GetValue<string>("ConnectionStrings:SqlConnection");

            return View();
        }
    }
}
