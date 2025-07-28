using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Repository;
using RunGroopWebApp.Models; // Dodajte ovo ako imate custom AppUser klasu

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// PROVJERITE: Da li koristite IdentityUser (default) ili svoju AppUser klasu?
// Ako koristite AppUser (vašu custom user klasu), onda ide: .AddDefaultIdentity<AppUser>
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // KRITIČNO: Omogućava Razor Pages, uključujući Identity Pages

// Registracija vaših repozitorija
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();

var app = builder.Build();

// Opciono: Seed Data (ako koristite)
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    // Ovdje treba dodati using System; i await Seed.SeedUsersAndRolesAsync(app); ako je async
    // Sačekajmo sa seedovanjem korisnika dok se ne uvjerimo da radi Identity
    Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // <-- KRITIČNO: OMOGUĆAVA AUTENTIFIKACIJU (nedostajalo je!)
app.UseAuthorization();  // Mora biti NAKON UseAuthentication()

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // KRITIČNO: Mapira Identity Razor Pages

app.Run();