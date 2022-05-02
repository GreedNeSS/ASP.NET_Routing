namespace CreatingRouteConstraint.Constraints
{
    public class InvalidNamesConstraint : IRouteConstraint
    {
        List<string> _names = new List<string>
        {
            "Bob", "Tom", "Henry"
        };

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return !_names.Contains(values[routeKey]?.ToString() ?? "");
        }
    }
}
