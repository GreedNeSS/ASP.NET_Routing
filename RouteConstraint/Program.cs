var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/user/{name:alpha:length(2,20)}/{age:int:range(1,115)}",
    (string name, int age) => $"Name: {name}, Age: {age}");
app.Map("/phone/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}",
    (string phone) => $"Phone Number: {phone}");

app.Run();
