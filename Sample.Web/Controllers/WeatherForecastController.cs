using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Events;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICommandBus commandBus)
        {
            _logger = logger;
            this._commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get([FromQuery]CreateOrderRequestModel requestModel)
        {
            await _commandBus.Send(requestModel);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}