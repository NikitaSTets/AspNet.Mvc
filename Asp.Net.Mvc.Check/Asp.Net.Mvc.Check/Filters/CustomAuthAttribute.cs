using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Asp.Net.Mvc.Check.Filters
{
    public class CustomAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext context)
        {
            var ident = context.Principal.Identity;
            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                context.Result = new HttpUnauthorizedResult();
            }
            context.Result = new EmptyResult();
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext context)
        {
            if (context.Result == null || context.Result is HttpUnauthorizedResult)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    {"controller", "GoogleAccount"},
                    {"action", "Login"},
                    {"returnUrl", context.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}