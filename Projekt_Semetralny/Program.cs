using Microsoft.EntityFrameworkCore;
using Projekt_Semetralny;

Console.WriteLine("Uruchamiam aplikację...");
var builder = WebApplication.CreateBuilder(args);

// Dodanie konfiguracji połączenia do bazy SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GravityDatabase")));

// Dodanie kontrolerów z widokami (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware dla środowiska produkcyjnego
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}





app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ustawienie domyślnej trasy
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();