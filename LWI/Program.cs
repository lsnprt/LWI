using LWI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DataService>();

builder.Services.AddHttpContextAccessor();
//builder.Services.ConfigureApplicationCookie(o => o.LoginPath="");

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
