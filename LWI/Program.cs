var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/exception");
    app.UseStatusCodePagesWithRedirects("/error/http/{0}");
}
app.UseEndpoints(o => o.MapControllers());

app.Run();
