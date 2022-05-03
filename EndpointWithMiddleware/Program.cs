var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => "Index Page");
app.Map("/user", () => new {Name = "GreedNeSS", Age = 30});

app.Use(async (context, next) =>
{
    Console.WriteLine("First middleware starts");

    if (context.Request.Path == "/about")
    {
        await context.Response.WriteAsync("About Page");
    }
    else
    {
        await next();
    }

    Console.WriteLine("First middleware ends");
});
app.Use(async (context, next) =>
{
    Console.WriteLine("Second middleware starts");
    await next();
    Console.WriteLine("Second middleware ends");
});
app.Use(async (context, next) =>
{
    Console.WriteLine("Third middleware starts");
    await next();

    if (context.Response.StatusCode == 404)
    {
        await context.Response.WriteAsync("Resource not found");
    }

    Console.WriteLine("Third middleware ends");
});

//app.Run(async context =>
//{
//    context.Response.StatusCode = 404;
//    await context.Response.WriteAsync("Resource not found");
//});
app.Run();
