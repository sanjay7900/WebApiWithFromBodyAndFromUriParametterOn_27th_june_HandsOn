using Microsoft.AspNetCore.Mvc;

namespace WebApiWithFromUriAndFromBodyParameter27thJuneHandsOn.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        public List<Employee> _employees = new List<Employee>();
        [HttpPost]
        public IActionResult AddNewEmployee([FromBody] Employee employee)
        {
            _employees.Add(employee);
            return Ok("Employee Added");
        }
    }
}