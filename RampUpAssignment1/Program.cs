using Microsoft.EntityFrameworkCore;
using RampUpAssignment1.Data;
using RampUpAssignment1.Interface;
using RampUpAssignment1.Models;
using RampUpAssignment1.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using RampUpAssignment1.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
);
builder.Services.AddTransient<IEmployee, EmployeeRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//JWT Authentication


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Access/Login";
   options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
