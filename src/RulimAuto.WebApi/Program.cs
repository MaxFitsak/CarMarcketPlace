using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RulimAuto.Application.Interfaces;
using RulimAuto.Application.Services;
using RulimAuto.Domain.Entities;
using RulimAuto.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Подключение базы данных SQLite
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarContext>(options => 
    options.UseSqlite(connection));

// Регистрация ASP.NET Core Identity (с Guid для ключей пользователя и роли)
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<CarContext>()
    .AddDefaultTokenProviders();

// Настройка путей для редиректа при авторизации (куки)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();

// Регистрация сервисов приложения
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Автоматическое создание схемы БД при старте (вместо миграций на этапе разработки)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CarContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Аутентификация обязательно ПЕРЕД авторизацией
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=RulimAuto}/{action=Index}/{id?}");

app.Run();