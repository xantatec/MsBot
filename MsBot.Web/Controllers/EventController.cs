using Microsoft.AspNetCore.Mvc;
using MsBot.Implementation.Event;
using System.Text;

namespace MsBot.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMsBotEventHandler _botEventHandler;

        public EventController(ILogger<WeatherForecastController> logger, IMsBotEventHandler botEventHandler)
        {
            _logger = logger;
            _botEventHandler = botEventHandler;
        }

        [HttpPost]
        public string Handle()
        {
            var strData = "";
            using (var sr = new StreamReader(Request.Body, Encoding.Default))
            {
                strData = sr.ReadToEndAsync().Result;
            }

            _botEventHandler.Handle(strData);

            return "";
        }
    }
}