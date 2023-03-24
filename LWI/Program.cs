using LWI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataService>();

builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureApplicationCookie(o => o.LoginPath="");

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(o => o.MapControllers());
app.Run();
