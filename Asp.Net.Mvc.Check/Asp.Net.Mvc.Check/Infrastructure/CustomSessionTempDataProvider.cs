using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Properties;

namespace Asp.Net.Mvc.Check.Infrastructure
{
    public class CustomSessionTempDataProvider : ITempDataProvider
    {
        internal const string TempDataSessionStateKey = "__ControllerTempData";

        /// <summary>Loads the temporary data by using the specified controller context.</summary>
        /// <returns>The temporary data.</returns>
        /// <param name="controllerContext">The controller context.</param>
        /// <exception cref="T:System.InvalidOperationException">An error occurred when the session context was being retrieved.</exception>
        public virtual IDictionary<string, object> LoadTempData(
          ControllerContext controllerContext)
        {
            HttpSessionStateBase session = controllerContext.HttpContext.Session;
            if (session != null)
            {
                Dictionary<string, object> dictionary = session["__ControllerTempData"] as Dictionary<string, object>;
                if (dictionary != null)
                {
                    //session.Remove("__ControllerTempData");
                    return (IDictionary<string, object>)dictionary;
                }
            }
            return (IDictionary<string, object>)new Dictionary<string, object>((IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>Saves the specified values in the temporary data dictionary by using the specified controller context.</summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="values">The values.</param>
        /// <exception cref="T:System.InvalidOperationException">An error occurred the session context was being retrieved.</exception>
        public virtual void SaveTempData(
          ControllerContext controllerContext,
          IDictionary<string, object> values)
        {
            if (controllerContext == null)
                throw new ArgumentNullException(nameof(controllerContext));
            HttpSessionStateBase session = controllerContext.HttpContext.Session;
            bool flag = values != null && values.Count > 0;
            if (session == null)
            {
                if (flag)
                    throw new InvalidOperationException();
            }
            else if (flag)
            {
                session["__ControllerTempData"] = (object)values;
            }
            else
            {
                if (session["__ControllerTempData"] == null)
                    return;
                session.Remove("__ControllerTempData");
            }
        }
    }
}