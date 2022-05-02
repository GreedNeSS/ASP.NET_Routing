var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/{message?}", (string? message) => $"Message: {message}");
app.Map("/", () => "Index.html");
app.Map("/{controller}/index/5", (string controller) => $"Controller: {controller}");
app.Map("/home/{action}/{id:int}", (string action, int id) => $"Action: {action}, Id: {id}");

app.Run();
