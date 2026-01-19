using GestionMouvementCarte.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


using GestionMouvementCarte.Data;
using Microsoft.AspNetCore.Identity;
namespace GestionMouvementCarte.DBcontextSQL
{
    public class DataDBContext : IdentityDbContext<IdentityUser>
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DataDBContext() { }
        public DbSet<CarteElectronique> CartesElectroniques { get; set; }
        public DbSet<Employe> Employes { get; set; }

        public DbSet<UniteDeProduction> UnitesDeProductions { get; set; }


    }

}