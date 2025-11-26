using Microsoft.EntityFrameworkCore;
using mvcRawail2312170.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureServices((context, services) =>
{
    // 1. Read the connection string from appsettings.json
    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

    // 2. Pass the connectionString variable to UseSqlServer
    services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(connectionString));
});


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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