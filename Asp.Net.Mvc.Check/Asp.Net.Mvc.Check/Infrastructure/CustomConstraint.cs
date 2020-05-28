using System.Web;
using System.Web.Routing;

namespace Asp.Net.Mvc.Check.Infrastructure
{
    public class CustomConstraint : IRouteConstraint
    {
        private readonly string _requiredUserAgent;

        public CustomConstraint(string agentParam)
        {
            _requiredUserAgent = agentParam;
        }


        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {

            return httpContext.Request.UserAgent != null && httpContext.Request.UserAgent.Contains(_requiredUserAgent);
        }
    }
}