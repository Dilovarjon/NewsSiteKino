using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using NewsSite.Services.RegistrationServices;
using NewsSite.Services.LoginServices;
using NewsSite.Controllers;
using NewsSite.Services.AdminServices.IAdminServices.IFileMovieServices;
using NewsSite.Services.AdminServices.AdminServices.FileMovieServices;
using NewsSite.Services.AdminServices.IAdminServices.IUserServices;
using NewsSite.Services.AdminServices.AdminServices.UserServices;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

var authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddTransient<ILoginServices, LoginServices>();
/// <summary>
/// ��������� ������ �����������
/// </summary>
builder.Services.AddTransient<IRegistrationServices, RegistrationServices>();
/// <summary>
/// ��������� �������� �������
/// </summary>
builder.Services.AddTransient<IFileMovieAddServices, FileMovieAddServices>();
builder.Services.AddTransient<IFileMovie�hangesServices, FileMovie�hangesServices>();
builder.Services.AddTransient<IFileMovieDeleteServices, FileMovieDeleteServices>();
/// <summary>
/// ��������� ����� �������
/// </summary>
builder.Services.AddTransient<IUserUpdateService, UserUpdateService>();
builder.Services.AddAuthentication(authenticationScheme).AddCookie(opt =>
    {
        opt.LoginPath = "/Login";
        opt.AccessDeniedPath = "/";
    });
builder.Services.AddAuthorization();
//builder.Services.AddAuthorization(opt => opt.AddPolicy("Admin", pol => pol.RequireClaim(ClaimTypes.Name, "")));


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
