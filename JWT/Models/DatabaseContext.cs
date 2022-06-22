using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Models
{
    public partial class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });
            modelBuilder.Entity<Category>(entity => 
            {
                entity.ToTable("Categories");
                entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasMaxLength(100).IsUnicode(false);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(e => e.ProductID).HasColumnName("ProductID");
                entity.Property(e => e.ProductName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.ProductCost).HasMaxLength(100).IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

     }
}
 