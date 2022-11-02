using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using NewsSite.Services.RegistrationServices;
using NewsSite.Services.LoginServices;
using NewsSite.Controllers;
using NewsSite.Services.AdminServices.IAdminServices;
using NewsSite.Services.AdminServices.AdminServices;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IRegistrationServices, RegistrationServices>();
builder.Services.AddTransient<IFileMovieAddServices, FileMovieAddServices>();
builder.Services.AddTransient<IFileMovieÑhangesServices, FileMovieÑhangesServices>();
builder.Services.AddTransient<IFileMovieDeleteServices, FileMovieDeleteServices>();

builder.Services.AddAuthentication(authenticationScheme).AddCookie(opt =>
    {
        opt.LoginPath = "/Login";
        opt.AccessDeniedPath = "/";
    });
builder.Services.AddAuthorization();
//builder.Services.AddAuthorization(opt => opt.AddPolicy("Admin", pol => pol.RequireClaim(ClaimTypes.Name, "")));

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseMySql(connection, new MySqlServerVersion(new Version(10, 6, 5))));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
