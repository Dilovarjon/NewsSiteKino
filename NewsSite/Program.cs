using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/registration";
        options.AccessDeniedPath = "/registration";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireClaim(ClaimTypes.Name, "");
    });
});
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(
                        "server=localhost;user=root;password=;database=test1db;",
                                    new MySqlServerVersion(new Version(10, 6, 5))));
builder.Services.AddControllers();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IRegistrationServices, RegistrationServices>();

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
