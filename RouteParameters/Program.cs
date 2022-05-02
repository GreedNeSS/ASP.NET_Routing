var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/users/{id}/{name?}", (string id, string? name) => $"User\nId: {id};\nName: {name??"Undefined"}");
app.Map("/about", async context => await context.Response.WriteAsync($"{context.Request.Path}{context.Request.QueryString}"));
app.Map("/contact/{**info=/d/}", (string info) => $"{info}");
app.Map("{controller=Home}/{action=Index}/{id?}",
    (string controller, string action, string? id) => $"Controller: {controller};\nAction: {action};\nId: {id}");

app.Run();
