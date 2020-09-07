using System;
using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Filters
{
    public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            {
                filterContext.Result
                    = new RedirectResult("~/Content/RangeErrorPage.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}