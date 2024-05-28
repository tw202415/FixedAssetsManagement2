// Data/FixedAssetsDbContext.cs
using Microsoft.EntityFrameworkCore;
using FixedAssetsManagement2.Models;

namespace FixedAssetsManagement2.Data
{
    public class FixedAssetsDbContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=your_server;Database=your_database;User Id=your_username;Password=your_password;Encrypt=false;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Server=192.168.20.136;Database=FixedAssetsDB;User Id=sa;Password=Sql@admin;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}
