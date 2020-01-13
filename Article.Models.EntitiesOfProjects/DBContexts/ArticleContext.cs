using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Models.EntitiesOfProjects.DBContexts
{
    #region Internal usings
    using Entities;

    #endregion Internal usings

    public class ArticleContext : DbContext
    {
        public ArticleContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)

            {
                optionsBuilder.UseSqlServer("Server=(local); Initial Catalog=ArticleDB; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Name).IsRequired().HasMaxLength(20);

                entity.HasIndex(c => c.Name).IsUnique();

                entity.Property(c => c.CreationDate).HasDefaultValueSql("GETDATE()");
                
                entity.HasMany(p => p.Posts)
                    .WithOne(c => c.Category)

                    .HasForeignKey(p => p.CategoryId)

                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(20);

                entity.Property(u => u.LastName).IsRequired().HasMaxLength(30);

                entity.Property(u => u.UserName).IsRequired().HasMaxLength(20);

                entity.HasIndex(u => u.UserName).IsUnique();

                entity.Property(u => u.CreationDate).HasDefaultValueSql("GETDATE()");

                entity.HasMany(p => p.Posts)

                    .WithOne(u => u.User)

                    .HasForeignKey(p => p.UserId)

                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(p => p.Title).IsRequired().HasMaxLength(20);

                entity.Property(p => p.Description).IsRequired().HasMaxLength(100);

                entity.Property(p => p.CreationDate).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
