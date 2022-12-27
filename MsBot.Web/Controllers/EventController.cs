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
        public IActionResult Handle()
        {
            var strData = "";
            using (var sr = new StreamReader(Request.Body, Encoding.Default))
            {
                strData = sr.ReadToEndAsync().Result;
            }

            Console.WriteLine(strData);

            var result = _botEventHandler.Handle(strData);
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Trim();
                if (result.StartsWith("{"))
                    return Content(result, "application/json");
                else
                    return Content(result);
            }
            return Content("");
        }
    }
}