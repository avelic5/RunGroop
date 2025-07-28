using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // <-- DODANO

namespace RunGroopWebApp.Data;

// PROVJERITE: Ako ste kreirali svoju custom klasu korisnika (npr. AppUser), ovdje bi umjesto IdentityUser išla AppUser
public class ApplicationDbContext : IdentityDbContext<IdentityUser> // <-- PROMIJENJENO
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Race> Races { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Address> Adresses { get; set; }

    // Ne morate dodavati DbSet za IdentityUser ili IdentityRole,
    // IdentityDbContext to radi automatski.
}