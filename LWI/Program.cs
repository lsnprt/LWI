using LWI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentity<CourseCreator, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(o => o.LoginPath = "/login");
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));
var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/");
    app.UseStatusCodePagesWithRedirects("/error/{0}");
}
app.UseEndpoints(o => o.MapControllers());

app.Run();
