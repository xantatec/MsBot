using Microsoft.AspNetCore.Mvc;
using MsBot.Implementation.MySql.Repositories;
using MsBot.Infrastructure;
using MsBot.Manage.Web.Models;
using MsBot.Vo.Common;
using System.Diagnostics;

namespace MsBot.Manage.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MsgSummaryRepository _msgSummaryRepository;

        private long GROUP_ID = 1009861616l;

        public MemberController(ILogger<HomeController> logger, MsgSummaryRepository msgSummaryRepository)
        {
            _logger = logger;
            _msgSummaryRepository = msgSummaryRepository;
        }

        public IActionResult Index()
        {
            var dt = DateTime.Now;
            #region Today

            var todayMsgCount = _msgSummaryRepository.GetTodayCount(GROUP_ID, dt.Year, dt.Month, dt.Day);
            var today = new MsgChartData<long>
            {
                Categories = new List<string>(),
                Values = new List<long>()
            };
            for(var i = 0; i <= DateTime.Now.Hour; i++)
            {
                today.Categories.Add(i.ToString() + "时");
                today.Values.Add(todayMsgCount.ContainsKey(i) ? todayMsgCount[i] : 0);
            }

            ViewBag.TodayMsgCount = today;

            #endregion

            #region Month

            var monthMsgCount = _msgSummaryRepository.GetMonthCount(GROUP_ID, dt.Year, dt.Month);
            var month = new MsgChartData<long>
            {
                Categories = new List<string>(),
                Values = new List<long>()
            };
            for(var i = 1; i <= DateTime.DaysInMonth(dt.Year, dt.Month); i++)
            {
                month.Categories.Add("Day" + i.ToString());
                month.Values.Add(monthMsgCount.ContainsKey(i) ? monthMsgCount[i] : 0);
            }

            ViewBag.MonthMsgCount = month;

            #endregion

            #region Month

            var yearMsgCount = _msgSummaryRepository.GetYearCount(GROUP_ID, dt.Year);
            var year = new MsgChartData<long>
            {
                Categories = new List<string>(),
                Values = new List<long>()
            };
            for(var i = 1; i <= 12; i++)
            {
                year.Categories.Add(i.ToString() + "月");
                year.Values.Add(yearMsgCount.ContainsKey(i) ? yearMsgCount[i] : 0);
            }

            ViewBag.YearMsgCount = year;
            #endregion

            return View();
        }

        [HttpGet]
        public JsonResult GetRealTimeMsgCount(long groupId = 1009861616)
        {
            //1MIN一个计数，缓存30MIN
            var dt = DateTime.Now;
            var min = dt.AddMinutes(-30);
            var ct = dt;
            var dic = new List<KeyValuePair<int, int>>();
            do
            {
                var cacheGpMsgKey = string.Format("_GROUP_MSG_{0}_{1}", groupId, ct.ToString("HHmm"));
                CacheHelper.Instance.TryGet<int>(cacheGpMsgKey, out var groupMsgCount);
                dic.Add(new KeyValuePair<int, int>(Convert.ToInt32(ct.ToString("HHmm")), groupMsgCount));
                ct = ct.AddMinutes(-1);
            }
            while(ct >= min);
            dic.Reverse();
            return Json(new ExecuteResult<List<KeyValuePair<int, int>>> { Success = true, Result = dic });
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