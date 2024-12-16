using Microsoft.EntityFrameworkCore;

namespace VLCAIAPI.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Commerces> Commerces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commerces>()
                .HasNoKey() // Indique que cette entité n'a pas de clé primaire
                .ToTable("Commerces"); // Le nom de la table dans la base de données
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.,9595;Database=VLCAI;user=sa;Password=Password123456789;TrustServerCertificate=true");
        }
    }
    public class Commerces
    {
        public int Id { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public long osm_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string wheelchair { get; set; }
        public string opening_hours { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string code_insee { get; set; }

    }
}
