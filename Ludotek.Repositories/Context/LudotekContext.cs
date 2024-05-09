using Ludotek.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Ludotek.Repositories.Context
{
    public partial class LudotekContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public LudotekContext(DbContextOptions<LudotekContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ItemTagModel>(entity =>
            //{
            //    entity.HasKey(e => new { e.ItemId, e.TagId });

            //    entity.HasOne(d => d.Item)
            //        .WithMany(p => p.ItemTag)
            //        .HasForeignKey(d => d.ItemId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.Tag)
            //        .WithMany(p => p.ItemTag)
            //        .HasForeignKey(d => d.TagId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
