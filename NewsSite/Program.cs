using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using NewsSite.Services.RegistrationServices;
using NewsSite.Services.LoginServices;
using NewsSite.Controllers;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IRegistrationServices, RegistrationServices>();

builder.Services.AddAuthentication(authenticationScheme).AddCookie(opt =>
    {
        opt.LoginPath = "/registration";
        opt.AccessDeniedPath = "/registration";
    });

builder.Services.AddAuthorization(opt => opt.AddPolicy("Admin", pol => pol.RequireClaim(ClaimTypes.Name, "")));

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseMySql(connection, new MySqlServerVersion(new Version(10, 6, 5))));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
