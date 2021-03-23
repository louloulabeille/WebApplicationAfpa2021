using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Constraints
{
    public class EtablissementLogConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Regex rgx = new Regex(@"^[0-9]{5}$");
            return rgx.IsMatch(values["id"].ToString());
        }
    }
    public class AventureLogConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Regex rgx = new Regex(@"\d+");
            return rgx.IsMatch(values["id"].ToString());
        }
    }
}
