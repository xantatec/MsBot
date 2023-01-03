using Microsoft.AspNetCore.Mvc;
using MsBot.Infrastructure;
using MsBot.Manage.Web.Models;
using MsBot.Vo.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Diagnostics;

namespace MsBot.Manage.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRealTimeMsgCount(long groupId)
        {
            //1MIN一个计数，缓存30MIN
            var dt = DateTime.Now;
            var min = dt.AddMinutes(-30);
            var ct = dt;
            var dic = new List<KeyValuePair<string, int>>();
            do
            {
                ct = ct.AddMinutes(-1);

                var cacheGpMsgKey = string.Format("_GROUP_MSG_{0}_{1}", groupId, ct.ToString("mmss"));
                CacheHelper.Instance.TryGet<int>(cacheGpMsgKey, out var groupMsgCount);
                dic.Add(new KeyValuePair<string, int>(ct.ToString("mm:ss"), RandomHelper.Instance.RandomInt(100)));
            }
            while(ct >= min);
            dic.Reverse();
            return Json(new ExecuteResult<List<KeyValuePair<string, int>>> { Success = true, Result = dic });
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