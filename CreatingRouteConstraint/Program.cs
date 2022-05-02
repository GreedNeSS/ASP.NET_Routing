using CreatingRouteConstraint.Constraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("secretcode", typeof(SecretCodeConstraint)));
builder.Services.AddRouting(options => options.ConstraintMap.Add("invalidnames", typeof(InvalidNamesConstraint)));
var app = builder.Build();

app.Map("/user/{token:secretcode(12340987)}", (string token) => $"User token: {token}");
app.Map("users/{name:invalidnames}", (string name) => $"Name: {name}");

app.Run();
