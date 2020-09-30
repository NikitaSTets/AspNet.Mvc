using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Filters
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext.HttpContext.Request.IsLocal)
            //{
            //    filterContext.Result = new HttpNotFoundResult();
            //}
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}