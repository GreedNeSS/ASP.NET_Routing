using DependencyInjection_in_Endpoints.Interfaces;
using DependencyInjection_in_Endpoints.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDateService, LongDateService>();
builder.Services.AddTransient<ITimeService, LongTimeService>();
var app = builder.Build();

app.Map("time", (ITimeService timeService) => $"Time: {timeService.Time()}");
app.Map("date", SendDate);

app.Run();

string SendDate(IDateService dateService) => $"Date: {dateService.Date()}";