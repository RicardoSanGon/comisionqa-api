using Microsoft.EntityFrameworkCore;

namespace ComisionQA.Models
{
    public class Catalogue
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

        public List<Brand> Brands { get; set; }

        public void updatePropeties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.createdAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.updatedAt)
                .HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Catalogue>()
                .Property(b => b.status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Catalogue>()
                .HasMany<Brand>(c => c.Brands)
                .WithOne(b => b.Catalogue)
                .HasForeignKey(b => b.catalogueId);
        }
    }
}
