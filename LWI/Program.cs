using LWI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataService>();
builder.Services.AddHttpContextAccessor();
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.ConfigureApplicationCookie(o => o.LoginPath="");
builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(connString));
var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/");
    app.UseStatusCodePagesWithRedirects("/error/{0}");
}
app.UseEndpoints(o => o.MapControllers());

app.Run();
