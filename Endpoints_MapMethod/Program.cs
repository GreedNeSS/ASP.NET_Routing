using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => "Index");
app.Map("/users", () => "Users");
app.Map("/contact", async context =>
{
    await context.Response.WriteAsync("Contact");
});

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    StringBuilder sb = new StringBuilder();
    var endpoints = endpointSources.SelectMany(x => x.Endpoints);

    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);
    }

    return sb.ToString();
});

app.Run();
