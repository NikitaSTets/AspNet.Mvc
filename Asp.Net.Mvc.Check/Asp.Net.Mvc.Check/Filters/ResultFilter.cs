using System.Diagnostics;
using System.Net;
using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Filters
{
    public class ResultFilter : FilterAttribute, IResultFilter
    {
        private Stopwatch _stopwatch;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _stopwatch = Stopwatch.StartNew();

            filterContext.Result = new EmptyResult();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _stopwatch.Stop();
            filterContext.HttpContext.Response.Write($"<div>Result elapsed time: {_stopwatch.Elapsed.TotalSeconds:F6}</div>");
        }
    }
}