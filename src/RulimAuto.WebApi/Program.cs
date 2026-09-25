using RulimAuto.Application;
using RulimAuto.Infrastucture;
using RulimAuto.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація залежностей Clean Architecture
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Реєстрація контролерів
builder.Services.AddControllers();

var app = builder.Build();

// Конвеєр обробки запитів (Pipeline)
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();