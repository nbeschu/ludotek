using System;
using Ludotek.Api.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ludotek.Api
{
    public partial class Context : DbContext
    {
        public virtual DbSet<LudoTagDto> LudoTag { get; set; }
        public virtual DbSet<LudothequeDto> Ludotheque { get; set; }
        public virtual DbSet<TagDto> Tag { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LudoTagDto>(entity =>
            {
                entity.HasKey(e => new { e.LudothequeId, e.TagId });

                entity.HasOne(d => d.Ludotheque)
                    .WithMany(p => p.LudoTag)
                    .HasForeignKey(d => d.LudothequeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LudoTag_Ludotheque");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.LudoTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LudoTag_Tag");
            });

            modelBuilder.Entity<LudothequeDto>(entity =>
            {
                entity.Property(e => e.NomItem)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TagDto>(entity =>
            {
                entity.Property(e => e.NomTag)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
