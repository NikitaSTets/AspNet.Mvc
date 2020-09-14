using System.Diagnostics;
using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class ResultFilter : FilterAttribute, IResultFilter
    {
        private Stopwatch _stopwatch;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();
            filterContext.HttpContext.Response.Write(
                string.Format("<div>Result elapsed time: {0:F6}</div>",
                    _stopwatch.Elapsed.TotalSeconds));
        }
    }
}